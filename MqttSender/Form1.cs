using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MqttSender.generator;
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
        private RobotDataGenerator RobotDataGenerator;
        private TaskHandler TaskHandler = new TaskHandler();
        private const string DEFAULT_TASK_TYPE = "GENERATED_TASK";
        private const string DEFAULT_TASK_STATUS = "pending";
        private const int DEFAULT_WORKING_TIME = 5;
        private const int DEFAULT_MOVING_TIME = 5;
        private const string DEFAULT_TASK_ID = "task1";
        private const string DEFAILT_START_LOC = "255, 255, 0";
        private const string DEFAILT_DEST_LOC = "255, 255, 0";
        private readonly object GeneratorLock = new object();
        
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
        }

        public Form1()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                InitializeFields();
            }

            this.mqttUserNameInputF.Enabled = false;
            this.mqttPassInputF.Enabled = false;
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
        
        private AMRRobotInputObject createRobotInputObjectInstance()
        {
            try
            {
                AMRRobotInputObject inputObject = new AMRRobotInputObject(
                    robotSidInputField.Text,
                    robotModelInputField.Text,
                    robotNameInputField.Text,
                    parseStringToInt(tickPerDelayTime.Text),
                    parseStringToInt(msgDelayTimeInputF.Text),
                    eventTypeInputF.Text,
                    TaskHandler.getTaskQueue()
                );

                bool isValid = inputObject.IsValidInputs();
                if (isValid == false)
                {
                    throw new InvalidOperationException("메시지 기능 값을 넣어 주세요");
                }

                return inputObject;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "입력 값 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
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
            var robotInputObject = createRobotInputObjectInstance();
            
            if (robotInputObject != null)
            {
                // If the object was created successfully, perform further actions
                MessageBox.Show("입력 값 정상.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the object was not created (return null), notify the user
                MessageBox.Show("입력 값 오류.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showExampleDataBtn_Click(object sender, EventArgs e)
        {
            TaskHandler.EnqueueAll();
            
            List<AMRRobotInputObject> amrRobotInputObjects = new List<AMRRobotInputObject>();
            AMRRobotInputObject amrRobotInputObject = createRobotInputObjectInstance();
            
            if (amrRobotInputObject != null)
            {
                amrRobotInputObjects.Add(amrRobotInputObject);

                // Generate JSON data from the list of AMRRobotInputObject
                RobotDataGenerator = new RobotDataGenerator(TaskHandler.getTaskQueue());
                string jsonData = RobotDataGenerator.GenerateRobotDataJson(amrRobotInputObjects, 0);
                
                MessageBox.Show(jsonData, "데이터 예시", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the object was not created (return null), notify the user
                MessageBox.Show("입력 값 오류.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaskHandler.DequeueAllTask();
        }
        
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        private async void publishMsgBtn_Click(object sender, EventArgs e)
        {
            
            cancellationTokenSource = new CancellationTokenSource(); // Reset or create a new CancellationTokenSource
            
            // Validate necessary inputs
            int tickPerDelay = int.Parse(tickPerDelayTime.Text); // # of ticks per second
            int msgDelayTimeSeconds = int.Parse(msgDelayTimeInputF.Text); // seconds

            TaskHandler.EnqueueAll();

            List<AMRRobotInputObject> amrRobotInputObjects = new List<AMRRobotInputObject>();
            
            AMRRobotInputObject amrRobotInputObject = createRobotInputObjectInstance();
            int currentTick = 0;
            int passedTimeMilli = 0;
            int totalSeconds = TaskHandler.getTotalTaskDurationInSeconds();
            int totalTicks = (int)((float)totalSeconds / msgDelayTimeSeconds) * tickPerDelay;
            int delayTimeMilli = (int)(1000.0 / tickPerDelay); // Convert ticks per second to milliseconds
            
            Console.WriteLine($"totalseconds= {totalSeconds}, totalTicks={totalTicks}, delayTimeMilli={delayTimeMilli}, passedTimeMilli={passedTimeMilli}");

            if (amrRobotInputObject != null)
            {
                amrRobotInputObjects.Add(amrRobotInputObject);

                // Generate JSON data
                RobotDataGenerator = new RobotDataGenerator(TaskHandler.getTaskQueue());
                MqttPublisher publisher = new MqttPublisher();
                
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalTicks;
                progressBar1.Value = 0;

                try
                {
                    // Connect to the MQTT broker
                    await publisher.ConnectAsync(mqttIpInputF.Text, int.Parse(mqttPortInputF.Text), mqttClientIdF.Text);

                    // Increment tick and send messages
                    while (currentTick <= totalTicks)
                    {
                        
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            MessageBox.Show("Loop cancelled by user", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        
                        //Generate JSON data
                        string jsonData = RobotDataGenerator.GenerateRobotDataJson(amrRobotInputObjects, delayTimeMilli);
                        if (jsonData == null)
                        {
                            break;
                        }
                        //Console.WriteLine(jsonData);
                        await publisher.SendMessageAsync(mqttTopicInputF.Text, jsonData);

                        // Update the progress bar based on delay time increment
                        progressBar1.Value = currentTick;
                        progressBar1.Refresh();

                        await Task.Delay(delayTimeMilli); // Delay between ticks
                        
                        //calculate passed time based on the ticks and delay time
                        passedTimeMilli += delayTimeMilli;
                        currentTick++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Disconnect from the MQTT broker
                    await publisher.DisconnectAsync();
                    MessageBox.Show("메시지 전송 완료", "성공!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                    TaskHandler.DequeueAllTask();
                }
                
            }
            else
            {
                // Notify user of input error
                MessageBox.Show("입력 값 오류.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            RobotTask task = new RobotTask();
            string taskId = taskIdInputField.Text;
            int workTime = int.Parse(workTimeInputField.Text); //working time
            int moveTime = int.Parse(moveTimeInputField.Text); //moving time
            Position startPos = parsePosition(startLocInputField.Text);
            Position destPos = parsePosition(destLocInputField.Text);
            
            task.TaskId = taskId;
            task.Origin = startPos;
            task.TargetLocation = destPos;
            task.Type = DEFAULT_TASK_TYPE;
            task.EstimatedEndTime = DateTime.Now
                .AddSeconds(workTime)
                .AddSeconds(moveTime);
            task.workTimeSeconds = workTime;
            task.moveTimeSeconds = moveTime;
            
            if (TaskHandler.AddTask(task))
            {
                ListViewItem listViewItem = new ListViewItem(task.TaskId);
                listViewItem.SubItems.Add(DEFAULT_TASK_STATUS);
                listViewItem.SubItems.Add(task.Origin.ToString());
                listViewItem.SubItems.Add(task.TargetLocation.ToString());
                listViewItem.SubItems.Add(task.EstimatedEndTime.ToString());
                taskListView.Items.Add(listViewItem);   
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
                foreach (ListViewItem selectedItem in taskListView.SelectedItems)
                {
                    string taskId = selectedItem.SubItems[0].Text; // Retrieve task ID assuming it's at index 1
                    bool removed = TaskHandler.RemoveTask(taskId);
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

        private void addRobotBtn_Click(object sender, EventArgs e)
        {

        }

        private void removeRobotBtn_Click(object sender, EventArgs e)
        {

        }
        
        private void robotListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
