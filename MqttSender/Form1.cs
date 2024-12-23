using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MqttSender.generator;
using MqttSender.manager;
using MqttSender.model;
using MqttSender.service;

namespace MqttSender
{
    public partial class Form1 : Form
    {
        private const string MQTT_DEFAULT_IP = "localhost";
        private const string MQTT_DEFAULT_PORT = "1884";
        private const string MQTT_DEFAULT_TOPIC = "vss-topic-external";
        private const string MQTT_DEFAULT_CLIENT_ID = "test-client-generator";
        private const int DEFAULT_MSG_COUNT_PER_SECOND = 5;
        private const int DEFAULT_MSG_DELAY_TIME = 1;
        private const int DEFAULT_LOCATION_VARIANT_VALUE = 5;
        private const string DEFAULT_EVENT_TYPE = "REGISTER_NEW_ROBOT";
        private const int DEFAULT_AUTORUN_TIME = 60; //in seconds
        private const int DEFAUKT_Z_VALUE = 0;
        private const string DEFAULT_ROBOT_SIDE_VALUE = "TEST_SID";
        private const string DEFAULT_ROBOT_MODEL_VALUE = "HD1500";
        private const string DEFAULT_ROBOT_NAME_VALUE = "TEST_NAME";
        private const string DEFAULT_TASK_TYPE = "GENERATED_TASK";
        private const string DEFAULT_TASK_STATUS = "pending";
        private const int DEFAULT_WORKING_TIME = 5;
        private const int DEFAULT_MOVING_TIME = 5;
        private const string DEFAULT_TASK_ID = "task1";
        private const string DEFAILT_START_LOC = "255, 255, 0";
        private const string DEFAILT_DEST_LOC = "255, 255, 0";
        private readonly object GeneratorLock = new object();
        
        private RobotDataGenerator RobotDataGenerator;
        private RobotManager<AmrRobot> AmrRobotManager = new RobotManager<AmrRobot>();
        private TaskManager TaskManager = TaskManager.GetInstance();


        private void InitializeRobotListView()
        {
            // Set the View mode to Details to show columns
            robotListView.View = View.Details;

            // Add columns to the robotListView
            robotListView.Columns.Add("SID", 50, HorizontalAlignment.Left);
            robotListView.Columns.Add("Model Name", 100, HorizontalAlignment.Left);
            robotListView.Columns.Add("Robot Name", 100, HorizontalAlignment.Left);

            robotListView.FullRowSelect = true;
            robotListView.GridLines = true; 
            robotListView.MultiSelect = false;
            robotListView.Scrollable = true;
        }
        
        
        private void InitializeRobotTaskView()
        {
            // Set the View mode to Details to show columns
            taskListView.View = View.Details;

            // Add columns to the robotListView
            taskListView.Columns.Add("Task SID", 60, HorizontalAlignment.Left);
            taskListView.Columns.Add("Origin Pos", 110, HorizontalAlignment.Left);
            taskListView.Columns.Add("Target Pos", 110, HorizontalAlignment.Left);
            taskListView.Columns.Add("Move Time", 50, HorizontalAlignment.Left);
            taskListView.Columns.Add("Idle seconds", 50, HorizontalAlignment.Left);
            taskListView.Columns.Add("Estimated Time", 100, HorizontalAlignment.Left);

            taskListView.FullRowSelect = true;
            taskListView.GridLines = true; 
            taskListView.MultiSelect = true;
            taskListView.Scrollable = true;
        }
        
        private void InitializeFields()
        {
            mqttIpInputF.Text = MQTT_DEFAULT_IP;
            mqttPortInputF.Text = MQTT_DEFAULT_PORT;
            mqttTopicInputF.Text = MQTT_DEFAULT_TOPIC;
            mqttClientIdF.Text = MQTT_DEFAULT_CLIENT_ID;
            tickPerDelayTime.Text = DEFAULT_MSG_COUNT_PER_SECOND.ToString();
            msgDelayTimeInputF.Text = DEFAULT_MSG_DELAY_TIME.ToString();
            eventTypeInputF.Text = DEFAULT_EVENT_TYPE;
            robotSidInputField.Text = DEFAULT_ROBOT_SIDE_VALUE;
            robotNameInputField.Text = DEFAULT_ROBOT_NAME_VALUE;
            robotModelInputField.Text = DEFAULT_ROBOT_MODEL_VALUE;
            workTimeInputField.Text = DEFAULT_WORKING_TIME.ToString();
            moveTimeInputField.Text = DEFAULT_MOVING_TIME.ToString();
            startLocInputField.Text = DEFAILT_START_LOC;
            destLocInputField.Text = DEFAILT_DEST_LOC;
            taskIdInputField.Text = DEFAULT_TASK_ID;
            tickPerDelayTime.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            msgDelayTimeInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            tickPerDelayTime.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            mqttPortInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            moveTimeInputField.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            workTimeInputField.KeyPress += inputF_AllowIntegerOnly_TextChanged;

            InitializeRobotListView();
            InitializeRobotTaskView();
        }

        public Form1()
        {
            VSSMenuBar menuBar = new VSSMenuBar(() => AmrRobotManager, updatedManager =>
            {
                AmrRobotManager = updatedManager;
                robotListView?.Items.Clear();
                taskListView?.Items.Clear();
                
                //based on the updated robots, update list
                foreach (var robot in AmrRobotManager.GetRobots())
                {
                    ListViewItem robotListViewItem = new ListViewItem(robot.GetRobotSid());
                    robotListViewItem.SubItems.Add(robot.GetRobotModelName());
                    robotListViewItem.SubItems.Add(robot.GetRobotName());
                    robotListView?.Items.Add(robotListViewItem);   
                }
            });

            this.MainMenuStrip = menuBar;
            this.Controls.Add(menuBar);
            this.Width = 800;
            this.Height = 600;
            
            InitializeComponent();
            if (!this.DesignMode)
            {
                InitializeFields();
            }

            this.mqttUserNameInputF.Enabled = false;
            this.mqttPassInputF.Enabled = false;
        }

        //Todo: add robot types enum as a parameter to create desired Robot.
        private AmrRobot ValidateRobotInputAndCreateAmrRobot()
        {
            string robotSid = robotSidInputField.Text;
            string robotModel = robotModelInputField.Text;
            string robotName = robotNameInputField.Text;

            if (robotSid.Length == 0 || robotModel.Length == 0 || robotName.Length == 0)
            {
                MessageBox.Show("Please fill in all robot fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //Check duplication
            if (AmrRobotManager.GetRobot(robotSid) != null)
            {
                MessageBox.Show("Robot already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            AmrRobot robot = new AmrRobot(robotSid, robotModel, robotName);
            
            return robot;
        }

        private RobotTask ValidateTaskInputAndCreateTask()
        {
            RobotTask task = new RobotTask();
            string taskId = taskIdInputField.Text;
            Position startLocation = parsePosition(startLocInputField.Text);
            Position targetLocation = parsePosition(destLocInputField.Text);

            int moveTimeInSecond = 0;
            int idleTimeInSecond = 0;
            try
            {
                moveTimeInSecond = int.Parse(moveTimeInputField.Text);
                idleTimeInSecond = int.Parse(workTimeInputField.Text);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Please fill in all task fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (FormatException e)
            {
                MessageBox.Show("Start and End location Format is wrong", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            catch (OverflowException e)
            {
                MessageBox.Show("Too large scale", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            
            
            if (taskId.Length == 0 || startLocation == null || targetLocation == null ||
                moveTimeInSecond == 0 || idleTimeInSecond == 0)
            {
                MessageBox.Show("Please fill in all task fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            task.TaskId = taskId;
            task.Origin = startLocation;
            task.TargetLocation = targetLocation;
            task.Type = DEFAULT_TASK_TYPE;
            task.IdleTimeInSeconds = idleTimeInSecond;
            task.MoveTimeInSeconds = moveTimeInSecond;
            task.EstimatedEndTime = DateTime.Now
                .AddSeconds(moveTimeInSecond)
                .AddSeconds(idleTimeInSecond);

            return task;
        }
        
        private float parseStringToFloat(string input)
        {
            if (float.TryParse(input, out float result))
            {
                return (float)Math.Round(result, 4);
            }
            else
            {
                throw new InvalidOperationException("좌표 값을 넣어주세요");
            }
        }
        
        private int parseStringToInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException("메시지 기능 값을 넣어 주세요");
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mqttPassInputF_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void isSSLConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.isSSLConnectCheckBox.Checked;
        }
        
        private void isCredentialEnabledCheckBox_CheckedChange(object sender, EventArgs e)
        {
            bool isChecked = this.isCredentialEnabledCheckbox.Checked;
            this.mqttUserNameInputF.Enabled = isChecked;
            this.mqttPassInputF.Enabled = isChecked;
        }
        
        private void mqttUserNameInputF_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void inputF_AllowDoubleOnly_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                e.Handled = true; // Discard input
            }
        }

        private void inputF_AllowIntegerOnly_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Discard input
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        
        //Button click events
        
        private void validateBtn_Click(object sender, EventArgs e)
        {
            //Todo: Validate robot inputs
            Robot robotInputObject = null;
            
            //Todo: Attempts to create object
            
            if (robotInputObject != null) // If the object was created successfully, perform further actions
            {
                MessageBox.Show("입력 값 정상.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // If the object was not created (return null), notify the user
            {
                MessageBox.Show("입력 값 오류.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Todo: fix this
        private void showExampleDataBtn_Click(object sender, EventArgs e)
        {

            Robot amrRobot = new AmrRobot();
            if (amrRobot != null)
            {
                
                string jsonData = null;
                
                MessageBox.Show(jsonData, "데이터 예시", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the object was not created (return null), notify the user
                MessageBox.Show("입력 값 오류.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        private async void publishMsgBtn_Click(object sender, EventArgs e)
        {
            
        }

       private void robotSidInputField_TextChanged(object sender, EventArgs e)
       {

       }

       private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        
        private void mqttTopicInputF_TextChanged(object sender, EventArgs e)
        {

        }

        private void mqttPortInputF_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void mqttIpInputF_TextChanged(object sender, EventArgs e)
        {

        }

        private void mqttClientIdF_TextChanged(object sender, EventArgs e)
        {

        }

        private async void connectionTestBtn1_Click(object sender, EventArgs e)
        {
            var currentContext = SynchronizationContext.Current;
            
            try
            {
                DisableForm();
                Cursor = Cursors.WaitCursor;
                
                currentContext?.Post(_ => 
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 30;
                }, null);
                
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;

                MqttPublisher mqttPublisher = new MqttPublisher();
                bool useSSL = isSSLConnectCheckBox.Checked;
                
                if (useSSL)
                {
                    await mqttPublisher.ConnectAsync(mqttIpInputF.Text, int.Parse(mqttPortInputF.Text), mqttClientIdF.Text, true, timeoutMilliseconds: 5000);
                }
                else
                {
                    await mqttPublisher.ConnectAsync(mqttIpInputF.Text, int.Parse(mqttPortInputF.Text), mqttClientIdF.Text, false, timeoutMilliseconds: 5000);
                }

                MessageBox.Show("MQTT 브로커 접속 성공");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"MQTT 브로커 접속 실패: \n {ex.Message}");
            }
            finally
            {
                currentContext?.Post(_ => 
                {
                    Cursor = Cursors.Default;
                    EnableForm();
                }, null);
            }
        }
        
        private void DisableForm()
        {
            this.Enabled = false; // Disables the entire form
        }

        private void EnableForm()
        {
            this.Enabled = true;  // Re-enables the entire form
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Value = 0;
        }

        private Position parsePosition(string position)
        {
            var parts = position.Replace(" ", "").Split(',');
            
            if(parts.Length != 3)
            {
                MessageBox.Show(position, "좌표 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw new ArgumentException("Invalid position format: must contain exactly three values separated by commas.");
            }
            
            return new Position
            {
                X = int.Parse(parts[0].Trim()),
                Y = int.Parse(parts[1].Trim()),
                Z = int.Parse(parts[2].Trim())
            };
        }
        
        private void addRobotBtn_Click(object sender, EventArgs e)
        {
            AmrRobot robot = ValidateRobotInputAndCreateAmrRobot();
            
            
            if (robot == null)
            {
                MessageBox.Show("Invalid robot input. Please check your data.");
                return;
            }
            
            if (AmrRobotManager.AddRobot(robot.GetRobotSid(), robot))
            {
                ListViewItem robotListViewItem = new ListViewItem(robot.GetRobotSid());
                robotListViewItem.SubItems.Add(robot.GetRobotModelName());
                robotListViewItem.SubItems.Add(robot.GetRobotName());
                robotListView.Items.Add(robotListViewItem);   
            }
            else
            {
                MessageBox.Show("Robot already exists.");
                return;
            }
            

        }

        private void removeRobotBtn_Click(object sender, EventArgs e)
        {
            // Check if any robot is selected
            if (robotListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a robot to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Retrieve the selected robot's SID
            var selectedRobotItem = robotListView.SelectedItems[0];
            if (selectedRobotItem == null || selectedRobotItem.SubItems.Count == 0 || string.IsNullOrEmpty(selectedRobotItem.SubItems[0].Text))
            {
                MessageBox.Show("Invalid robot selection. Please select a valid robot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedRobotSid = selectedRobotItem.SubItems[0].Text;

            // Confirm the removal action with the user
            var confirmResult = MessageBox.Show($"Are you sure you want to remove the robot with SID '{selectedRobotSid}' and all its tasks?", 
                "Confirm Removal", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            // Remove robot data from the Robot Manager
            bool removed = AmrRobotManager.RemoveRobot(selectedRobotSid);

            if (removed)
            {
                // Successfully removed the robot, now remove its entry from the robotListView
                robotListView.Items.Remove(selectedRobotItem);

                // Also clear the tasks in the taskListView
                taskListView.Items.Clear();

                MessageBox.Show($"Robot with SID '{selectedRobotSid}' and its related tasks have been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Failed to remove robot with SID '{selectedRobotSid}'. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void robotListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the previous tasks in the taskListView
            taskListView.Items.Clear();

            // Check if any robot is selected
            if (robotListView.SelectedItems.Count > 0)
            {
                // Retrieve the selected robot's SID from the robotListView
                string selectedRobotSid = robotListView.SelectedItems[0].SubItems[0].Text; // Assuming SID is in the first column

                // Fetch the tasks for the selected robot
                Robot robot = AmrRobotManager.GetRobot(selectedRobotSid);
                LinkedList<RobotTask> robotTasks = robot.GetRobotTasks();

                if (robotTasks != null && robotTasks.Any()) // Check if tasks exist
                {
                    // Populate the taskListView with the retrieved tasks
                    foreach (var task in robotTasks)
                    {
                        ListViewItem taskListViewItem = new ListViewItem(task.TaskId ?? "Unknown Task");
                        taskListViewItem.SubItems.Add(task.Origin?.ToString());
                        taskListViewItem.SubItems.Add(task.TargetLocation?.ToString());
                        taskListViewItem.SubItems.Add(task.MoveTimeInSeconds.ToString());
                        taskListViewItem.SubItems.Add(task.IdleTimeInSeconds.ToString());
                        taskListViewItem.SubItems.Add(task.EstimatedEndTime.ToLocalTime() != null ? task.EstimatedEndTime.ToLocalTime().ToString() : "");
                        taskListView.Items.Add(taskListViewItem);
                    }
                }
                else
                {
                    MessageBox.Show($"No tasks found for the robot with SID '{selectedRobotSid}'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            RobotTask robotTask = ValidateTaskInputAndCreateTask();

            if (robotTask == null)
            {
                Console.WriteLine("Task is null.");
                return;
            }
            
            // Check if a robot is selected
            if (robotListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a robot first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            // Further validation for the selected robot
            var selectedRobotItem = robotListView.SelectedItems[0];
            if (selectedRobotItem == null || selectedRobotItem.SubItems.Count == 0 || string.IsNullOrEmpty(selectedRobotItem.SubItems[0].Text))
            {
                MessageBox.Show("Please select a valid robot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Check if a robot is selected
            string selectedRobotSid = robotListView.SelectedItems[0].SubItems[0].Text;

            if (String.IsNullOrEmpty(selectedRobotSid))
            {
                MessageBox.Show("Pleaes select a robot first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (AmrRobotManager.AddTask(selectedRobotSid, robotTask))
            {
                Console.WriteLine("Task added successfully.");
                ListViewItem robotTaskListViewItem = new ListViewItem(robotTask.TaskId);
                robotTaskListViewItem.SubItems.Add(robotTask.Origin.ToString());
                robotTaskListViewItem.SubItems.Add(robotTask.TargetLocation.ToString());
                robotTaskListViewItem.SubItems.Add(robotTask.MoveTimeInSeconds.ToString());
                robotTaskListViewItem.SubItems.Add(robotTask.IdleTimeInSeconds.ToString());
                robotTaskListViewItem.SubItems.Add(robotTask.EstimatedEndTime.ToLocalTime() != null ? robotTask.EstimatedEndTime.ToLocalTime().ToString() : "");
                taskListView.Items.Add(robotTaskListViewItem);   
            }
            else
            {
                MessageBox.Show("동일한 task Id가 이미 존재합니다.");
            }
        }

        private void RemoveTaskBtn_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count > 0)
            {
                // Check if a robot is selected
                if (robotListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a robot first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // Further validation for the selected robot
                var selectedRobotItem = robotListView.SelectedItems[0];
                if (selectedRobotItem == null || selectedRobotItem.SubItems.Count == 0 || string.IsNullOrEmpty(selectedRobotItem.SubItems[0].Text))
                {
                    MessageBox.Show("Please select a valid robot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedRobotSid = selectedRobotItem.SubItems[0].Text;
                if (String.IsNullOrEmpty(selectedRobotSid))
                {
                    MessageBox.Show("Pleaes select a robot first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                //Can remove multiple tasks at a same time
                foreach (ListViewItem selectedItem in taskListView.SelectedItems)
                {
                    string taskId = selectedItem.SubItems[0].Text; // Retrieve task ID assuming it's at index 1
                    bool removed = AmrRobotManager.RemoveTask(selectedRobotSid, taskId);
                    if (removed)
                    {
                        taskListView.Items.Remove(selectedItem);   
                    }
                }
            }
        }

        private void taskIdInputField_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cancelProcessBtn_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
        
    }
}
