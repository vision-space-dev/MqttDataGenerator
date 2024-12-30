using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MqttSender.generator;
using MqttSender.manager;
using MqttSender.model;
using MqttSender.service;
using Newtonsoft.Json;

namespace MqttSender
{
    /*internal partial class EditTaskForm : Form
    {
        private void editTaskSaveButton_Click(object sender, EventArgs e)
        {
            
        }
    }*/
    
    public partial class Form1 : Form
    {
        private const string MQTT_DEFAULT_IP = "localhost";
        private const string MQTT_DEFAULT_PORT = "1884";
        private const string MQTT_DEFAULT_TOPIC = "vss-topic-external";
        private const string MQTT_DEFAULT_CLIENT_ID = "test-client-generator";
        private const int DEFAULT_MSG_COUNT_PER_SECOND = 5;
        private const int DEFAULT_MSG_DELAY_TIME = 500;
        private const int DEFAULT_LOCATION_VARIANT_VALUE = 5;
        private const string DEFAULT_EVENT_TYPE = "REGISTER_NEW_ROBOT";
        private const int DEFAULT_AUTORUN_TIME = 60; //in seconds
        private const int DEFAUKT_Z_VALUE = 0;
        private const string DEFAULT_ROBOT_SIDE_VALUE = "TEST_SID";
        private const string DEFAULT_ROBOT_MODEL_VALUE = "HD1500";
        private const string DEFAULT_ROBOT_NAME_VALUE = "TEST_NAME";
        private const string DEFAULT_TASK_TYPE = "GENERATED_TASK";
        private const string DEFAULT_TASK_STATUS = "in_progress";
        private const int DEFAULT_WORKING_TIME = 5;
        private const int DEFAULT_MOVING_TIME = 5;
        private const string DEFAULT_TASK_ID = "task1";
        private const string DEFAILT_START_LOC = "255, 255, 0";
        private const string DEFAILT_DEST_LOC = "255, 255, 0";
        private bool isRepeatProcess = false;
        private MqttPublisher mqttPublisher;
        private const string DEFAULT_LOCATION_SID = "TEST_LOC_0001";
        private const string DEFAULT_FACILITY_SID = "FAC_001";
        
        private RobotDataGenerator RobotDataGenerator;
        private RobotManager<AmrRobot> AmrRobotManager = new RobotManager<AmrRobot>();

        private void InitializeRobotListView()
        {
            // Set the View mode to Details to show columns
            robotListView.View = View.Details;

            // Add columns to the robotListView
            robotListView.Columns.Add("SID", 50, HorizontalAlignment.Left);
            robotListView.Columns.Add("Model Name", 100, HorizontalAlignment.Left);
            robotListView.Columns.Add("Robot Name", 100, HorizontalAlignment.Left);
            robotListView.Columns.Add("Location Sid", 100, HorizontalAlignment.Left);
            robotListView.Columns.Add("Facility Sid", 100, HorizontalAlignment.Left);

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
            locationIdInputField.Text = DEFAULT_LOCATION_SID;
            facilityIdInputField.Text = DEFAULT_FACILITY_SID;
            msgDelayTimeInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            mqttPortInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            moveTimeInputField.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            workTimeInputField.KeyPress += inputF_AllowIntegerOnly_TextChanged;

            InitializeRobotListView();
            InitializeRobotTaskView();
            InitializeMqttConnection();
        }

        private async void InitializeMqttConnection()
        {
            mqttPublisher = new MqttPublisher();
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
                mqttPublisher = null;
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

        private bool validateUserInput()
        {
            //Todo: restrain message delay time
            
            //Todo: restrain coordinate input
            
            
            return false;
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
                    robotListViewItem.SubItems.Add(robot.GetLocationId());
                    robotListViewItem.SubItems.Add(robot.GetFacilityId());
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
            
            if (locationIdInputField.Text != null && facilityIdInputField.Text != null)
            {
                robot.SetLocationId(locationIdInputField.Text);
                robot.SetFacilityId(facilityIdInputField.Text);
            }
            
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
                moveTimeInSecond < 0 || idleTimeInSecond < 0)
            {
                MessageBox.Show("Please fill in all task fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            task.TaskId = taskId;
            task.Origin = startLocation;
            task.TargetLocation = targetLocation;
            task.Type = DEFAULT_TASK_TYPE;
            task.Status = DEFAULT_TASK_STATUS;
            task.IdleTimeInSeconds = idleTimeInSecond;
            task.MoveTimeInSeconds = moveTimeInSecond;
            task.EstimatedEndTime = DateTime.Now
                .AddSeconds(moveTimeInSecond)
                .AddSeconds(idleTimeInSecond);

            return task;
        }

        private void mqttPassInputF_TextChanged(object sender, EventArgs e)
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

        
        //Button click events
        
        private void validateBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
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
        
        //Very important section for generating and publishing robot task handled by taskManager
        //Todo: in the future, try to send off all robot task data in single message rather sending each of them individually
        private async void publishMsgBtn_Click(object sender, EventArgs e)
        {

            if (mqttPublisher == null)
            {
                MessageBox.Show("Failed to establish mqtt connection with the broker. Using developer mode.");
            }
            
            // Reset the CancellationTokenSource if it's already used or disposed
            if (cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = new CancellationTokenSource(); // Create a new one
            }
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            
            //Collects user defined robot & task data
            List<AmrRobot> robotList = AmrRobotManager.GetRobots();
            
            //This will handle all task by individual robot
            List<TaskManager> taskManagerList = new List<TaskManager>();
            
            //user defined setting
            int delayTimeInMilliSecond = int.Parse(msgDelayTimeInputF.Text);

            int largestTotalTaskTimeInMilliSeconds = 0;
            
            //Initialize robot task first by provided robot
            foreach (AmrRobot robot in robotList)
            {
                if (robot.GetRobotTasks().Count > 0)
                {
                    TaskManager taskManager = new TaskManager(robot, delayTimeInMilliSecond);
                    taskManagerList.Add(taskManager);

                    if (taskManager.GetTotalTaskTimeInMilliseconds() > largestTotalTaskTimeInMilliSeconds)
                    {
                        largestTotalTaskTimeInMilliSeconds = taskManager.GetTotalTaskTimeInMilliseconds();
                    }
                }
            }
            
            progressBar1.Maximum = largestTotalTaskTimeInMilliSeconds;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            
            bool taskComplete = taskManagerList.Count == 0;

            //clear screen
            allowMessageSend.Text = "";
            
            //while there's a task manager to still work on
            while (taskComplete == false)
            {
                // Check if cancellation has been requested
                if (cancellationToken.IsCancellationRequested)
                {
                    MessageBox.Show("Process terminated by user");
                    break; // Exit the loop if the process is canceled
                }
                
                
                //Copy the list of taskManagerList so that it can dynamically remove after the round
                foreach (var taskManager in taskManagerList.ToList())
                {
                    //Process and get generated message - possible null
                    RobotData generatedRobotData = taskManager.ProcessTask();
                    LogService.LogRobotDataToRichTextBox(allowMessageSend, generatedRobotData);

                    if (generatedRobotData != null)
                    {
                        //Reform into publisher message
                                    
                        var result = new RobotDataMessage
                        {
                            RobotData = new[]
                            {
                                new RobotDataEntry
                                {
                                    EventType = "REGISTER_NEW_ROBOT",
                                    RobotData = generatedRobotData
                                }
                            }
                        };
                        
                        string jsonString = JsonConvert.SerializeObject(result, Formatting.Indented);
                        Console.WriteLine(jsonString);
                    
                        //Publish message
                        if (mqttPublisher != null && this.messageSendEnabled.Checked)
                        {
                            mqttPublisher.SendMessageAsync(mqttTopicInputF.Text, jsonString);
                        }
                    }
                    
                    if (taskManager.TaskCompleted())
                    {
                        Console.WriteLine("Task is completed");
                        taskManagerList.Remove(taskManager);
                    }
                    
                }

                if (taskManagerList.Count == 0)
                {
                    Console.WriteLine("Task is completed");
                    taskComplete = true;
                }

                if (progressBar1.Value >= largestTotalTaskTimeInMilliSeconds)
                {
                    break;
                }
                progressBar1.Value += delayTimeInMilliSecond;
                
                // Introduce a non-blocking delay to allow user interactions
                await Task.Delay(delayTimeInMilliSecond);
                
            }

            //if it's repeated process, start this process again
            if (isRepeatProcess)
            {
                
            }

            progressBar1.Value =  0;
        }

        private async void connectionTestBtn1_Click(object sender, EventArgs e)
        {
            InitializeMqttConnection();
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
                robotListViewItem.SubItems.Add(robot.GetLocationId());
                robotListViewItem.SubItems.Add(robot.GetFacilityId());
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

        private void cancelProcessBtn_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
                Console.WriteLine("Cancellation requested.");
            }
        }

        private void isRepeatPublish_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                // Assign the boolean value from the `Checked` property of the CheckBox
                isRepeatProcess = checkBox.Checked;
                Console.WriteLine($"Repeat Publish is set to: {isRepeatPublish}");
            }
            else
            {
                Console.WriteLine("Event sender is not a CheckBox.");
            }
        }

        private void tickPerDelayTime_TextChanged(object sender, EventArgs e)
        {
            // Cast sender to TextBox
            TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                // Check if the text is numeric
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[0-9]*$")) // Only digits are allowed
                {
                    // Input is valid, no action needed
                }
                else
                {
                    // Input is invalid, remove the last character or reset to empty
                    MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = new string(textBox.Text.Where(char.IsDigit).ToArray()); // Remove invalid characters
                    textBox.SelectionStart = textBox.Text.Length; // Place the caret at the end
                }
            }
        }

        private void msgDelayTimeInputF_TextChanged(object sender, EventArgs e)
        {
            // Cast sender to TextBox
            TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                // Check if the text is numeric
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[0-9]*$")) // Only digits are allowed
                {
                    // Input is valid, no action needed
                }
                else
                {
                    // Input is invalid, remove the last character or reset to empty
                    MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = new string(textBox.Text.Where(char.IsDigit).ToArray()); // Remove invalid characters
                    textBox.SelectionStart = textBox.Text.Length; // Place the caret at the end
                }
            }
        }

        private void editTaskBtn_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (robotListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one robot to use edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string robotSid = robotListView.SelectedItems[0].SubItems[0].Text;
            string taskSid = taskListView.SelectedItems[0].SubItems[0].Text; // Assuming SID is in the first column
            
            AmrRobot robot = AmrRobotManager.GetRobot(robotSid);
            if (robot == null)
            {
                MessageBox.Show($"Robot with SID '{robotSid}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the RobotTask object
            RobotTask task = robot.GetRobotTask(taskSid);
            if (task == null)
            {
                MessageBox.Show($"Task with SID '{taskSid}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            /*// 1. Prompt Window to Edit Task Parameters
            using (EditTaskForm editTaskForm = new EditTaskForm(task))
            {
                if (editTaskForm.ShowDialog() == DialogResult.OK)
                {
                    // Reflect the updated task details back to the task list view.

                    // Update the task info in the ListView (UI representation)
                    taskListView.SelectedItems[0].SubItems[1].Text = task.Origin.ToString();
                    taskListView.SelectedItems[0].SubItems[2].Text = task.TargetLocation.ToString();
                    taskListView.SelectedItems[0].SubItems[3].Text = task.MoveTimeInSeconds.ToString();
                    taskListView.SelectedItems[0].SubItems[4].Text = task.IdleTimeInSeconds.ToString();

                    MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }*/
        }
    }
}
