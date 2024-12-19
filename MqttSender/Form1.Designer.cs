/**
 * 제작자: marcobackman (Tony Baek)
 */

using System.Windows.Forms;

namespace MqttSender
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.validateBtn = new System.Windows.Forms.Button();
            this.showExampleDataBtn = new System.Windows.Forms.Button();
            this.publishMsgBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.amrTabPage = new System.Windows.Forms.TabPage();
            this.taskListPanel = new System.Windows.Forms.Panel();
            this.editTaskBtn = new System.Windows.Forms.Button();
            this.taskListView = new System.Windows.Forms.ListView();
            this.RemoveTaskBtn = new System.Windows.Forms.Button();
            this.seeTaskDetailBtn = new System.Windows.Forms.Button();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.workTimeInputField = new System.Windows.Forms.TextBox();
            this.moveTimeInputField = new System.Windows.Forms.TextBox();
            this.workTimeLabel = new System.Windows.Forms.Label();
            this.moveTimeLabel = new System.Windows.Forms.Label();
            this.destLocInputField = new System.Windows.Forms.TextBox();
            this.endLocLabel = new System.Windows.Forms.Label();
            this.startLocInputField = new System.Windows.Forms.TextBox();
            this.startLocLabel = new System.Windows.Forms.Label();
            this.taskIdLabel = new System.Windows.Forms.Label();
            this.taskIdInputField = new System.Windows.Forms.TextBox();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.additionalDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.msgDelayTimeLabel = new System.Windows.Forms.Label();
            this.msgDelayTimeInputF = new System.Windows.Forms.TextBox();
            this.msgEventTypeLabel = new System.Windows.Forms.Label();
            this.msgTickPerDelay = new System.Windows.Forms.Label();
            this.eventTypeInputF = new System.Windows.Forms.TextBox();
            this.tickPerDelayTime = new System.Windows.Forms.TextBox();
            this.robotDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.robotListView = new System.Windows.Forms.ListView();
            this.removeRobotBtn = new System.Windows.Forms.Button();
            this.addRobotBtn = new System.Windows.Forms.Button();
            this.robotNameLabel = new System.Windows.Forms.Label();
            this.robotModelLabel = new System.Windows.Forms.Label();
            this.robotSidLabel = new System.Windows.Forms.Label();
            this.robotNameInputField = new System.Windows.Forms.TextBox();
            this.robotModelInputField = new System.Windows.Forms.TextBox();
            this.robotSidInputField = new System.Windows.Forms.TextBox();
            this.mqttConnectTabPage = new System.Windows.Forms.TabPage();
            this.mqttScurityInfoGroup = new System.Windows.Forms.GroupBox();
            this.isCredentialEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.isSSLConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.mqttPassLabel = new System.Windows.Forms.Label();
            this.mqttUserNameLabel = new System.Windows.Forms.Label();
            this.mqttPassInputF = new System.Windows.Forms.TextBox();
            this.mqttUserNameInputF = new System.Windows.Forms.TextBox();
            this.mqttBasicInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.mqttClientIdF = new System.Windows.Forms.TextBox();
            this.mqttClientNameLabel = new System.Windows.Forms.Label();
            this.connectionTestBtn1 = new System.Windows.Forms.Button();
            this.mqttTopicLabel = new System.Windows.Forms.Label();
            this.mqttBrokerPortLabel = new System.Windows.Forms.Label();
            this.mqttBrokerIpLabel = new System.Windows.Forms.Label();
            this.mqttTopicInputF = new System.Windows.Forms.TextBox();
            this.mqttPortInputF = new System.Windows.Forms.TextBox();
            this.mqttIpInputF = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.processCancelBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.tabControl1.SuspendLayout();
            this.amrTabPage.SuspendLayout();
            this.taskListPanel.SuspendLayout();
            this.taskGroupBox.SuspendLayout();
            this.additionalDetailGroupBox.SuspendLayout();
            this.robotDetailGroupBox.SuspendLayout();
            this.mqttConnectTabPage.SuspendLayout();
            this.mqttScurityInfoGroup.SuspendLayout();
            this.mqttBasicInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(596, 645);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(152, 24);
            this.validateBtn.TabIndex = 2;
            this.validateBtn.Text = "Check user input";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // showExampleDataBtn
            // 
            this.showExampleDataBtn.Location = new System.Drawing.Point(755, 645);
            this.showExampleDataBtn.Name = "showExampleDataBtn";
            this.showExampleDataBtn.Size = new System.Drawing.Size(138, 23);
            this.showExampleDataBtn.TabIndex = 1;
            this.showExampleDataBtn.Text = "Example data";
            this.showExampleDataBtn.UseVisualStyleBackColor = true;
            this.showExampleDataBtn.Click += new System.EventHandler(this.showExampleDataBtn_Click);
            // 
            // publishMsgBtn
            // 
            this.publishMsgBtn.Location = new System.Drawing.Point(899, 645);
            this.publishMsgBtn.Name = "publishMsgBtn";
            this.publishMsgBtn.Size = new System.Drawing.Size(135, 23);
            this.publishMsgBtn.TabIndex = 0;
            this.publishMsgBtn.Text = "Publish Message";
            this.publishMsgBtn.UseVisualStyleBackColor = true;
            this.publishMsgBtn.Click += new System.EventHandler(this.publishMsgBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.amrTabPage);
            this.tabControl1.Controls.Add(this.mqttConnectTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1032, 413);
            this.tabControl1.TabIndex = 4;
            // 
            // amrTabPage
            // 
            this.amrTabPage.Controls.Add(this.taskListPanel);
            this.amrTabPage.Controls.Add(this.taskGroupBox);
            this.amrTabPage.Controls.Add(this.additionalDetailGroupBox);
            this.amrTabPage.Controls.Add(this.robotDetailGroupBox);
            this.amrTabPage.Location = new System.Drawing.Point(4, 22);
            this.amrTabPage.Name = "amrTabPage";
            this.amrTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.amrTabPage.Size = new System.Drawing.Size(1024, 387);
            this.amrTabPage.TabIndex = 0;
            this.amrTabPage.Text = "AMR 기본 정보 입력";
            this.amrTabPage.UseVisualStyleBackColor = true;
            this.amrTabPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // taskListPanel
            // 
            this.taskListPanel.Controls.Add(this.editTaskBtn);
            this.taskListPanel.Controls.Add(this.taskListView);
            this.taskListPanel.Controls.Add(this.RemoveTaskBtn);
            this.taskListPanel.Controls.Add(this.seeTaskDetailBtn);
            this.taskListPanel.Location = new System.Drawing.Point(335, 203);
            this.taskListPanel.Name = "taskListPanel";
            this.taskListPanel.Size = new System.Drawing.Size(681, 188);
            this.taskListPanel.TabIndex = 21;
            // 
            // editTaskBtn
            // 
            this.editTaskBtn.Location = new System.Drawing.Point(525, 39);
            this.editTaskBtn.Name = "editTaskBtn";
            this.editTaskBtn.Size = new System.Drawing.Size(141, 26);
            this.editTaskBtn.TabIndex = 4;
            this.editTaskBtn.Text = "Edit Task";
            this.editTaskBtn.UseVisualStyleBackColor = true;
            // 
            // taskListView
            // 
            this.taskListView.HideSelection = false;
            this.taskListView.Location = new System.Drawing.Point(17, 10);
            this.taskListView.Name = "taskListView";
            this.taskListView.Size = new System.Drawing.Size(503, 168);
            this.taskListView.TabIndex = 3;
            this.taskListView.UseCompatibleStateImageBehavior = false;
            this.taskListView.View = System.Windows.Forms.View.Details;
            // 
            // RemoveTaskBtn
            // 
            this.RemoveTaskBtn.Location = new System.Drawing.Point(525, 152);
            this.RemoveTaskBtn.Name = "RemoveTaskBtn";
            this.RemoveTaskBtn.Size = new System.Drawing.Size(141, 26);
            this.RemoveTaskBtn.TabIndex = 2;
            this.RemoveTaskBtn.Text = "Remove Task";
            this.RemoveTaskBtn.UseVisualStyleBackColor = true;
            this.RemoveTaskBtn.Click += new System.EventHandler(this.RemoveTaskBtn_Click);
            // 
            // seeTaskDetailBtn
            // 
            this.seeTaskDetailBtn.Location = new System.Drawing.Point(525, 12);
            this.seeTaskDetailBtn.Name = "seeTaskDetailBtn";
            this.seeTaskDetailBtn.Size = new System.Drawing.Size(141, 23);
            this.seeTaskDetailBtn.TabIndex = 1;
            this.seeTaskDetailBtn.Text = "See task detail";
            this.seeTaskDetailBtn.UseVisualStyleBackColor = true;
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Controls.Add(this.workTimeInputField);
            this.taskGroupBox.Controls.Add(this.moveTimeInputField);
            this.taskGroupBox.Controls.Add(this.workTimeLabel);
            this.taskGroupBox.Controls.Add(this.moveTimeLabel);
            this.taskGroupBox.Controls.Add(this.destLocInputField);
            this.taskGroupBox.Controls.Add(this.endLocLabel);
            this.taskGroupBox.Controls.Add(this.startLocInputField);
            this.taskGroupBox.Controls.Add(this.startLocLabel);
            this.taskGroupBox.Controls.Add(this.taskIdLabel);
            this.taskGroupBox.Controls.Add(this.taskIdInputField);
            this.taskGroupBox.Controls.Add(this.addTaskBtn);
            this.taskGroupBox.Location = new System.Drawing.Point(730, 6);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(288, 192);
            this.taskGroupBox.TabIndex = 20;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Add Task";
            // 
            // workTimeInputField
            // 
            this.workTimeInputField.Location = new System.Drawing.Point(153, 127);
            this.workTimeInputField.Name = "workTimeInputField";
            this.workTimeInputField.Size = new System.Drawing.Size(111, 21);
            this.workTimeInputField.TabIndex = 21;
            // 
            // moveTimeInputField
            // 
            this.moveTimeInputField.Location = new System.Drawing.Point(153, 103);
            this.moveTimeInputField.Name = "moveTimeInputField";
            this.moveTimeInputField.Size = new System.Drawing.Size(111, 21);
            this.moveTimeInputField.TabIndex = 20;
            // 
            // workTimeLabel
            // 
            this.workTimeLabel.AutoSize = true;
            this.workTimeLabel.Location = new System.Drawing.Point(15, 130);
            this.workTimeLabel.Name = "workTimeLabel";
            this.workTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.workTimeLabel.TabIndex = 19;
            this.workTimeLabel.Text = "Idle time";
            // 
            // moveTimeLabel
            // 
            this.moveTimeLabel.AutoSize = true;
            this.moveTimeLabel.Location = new System.Drawing.Point(16, 106);
            this.moveTimeLabel.Name = "moveTimeLabel";
            this.moveTimeLabel.Size = new System.Drawing.Size(64, 12);
            this.moveTimeLabel.TabIndex = 18;
            this.moveTimeLabel.Text = "Move time";
            // 
            // destLocInputField
            // 
            this.destLocInputField.Location = new System.Drawing.Point(153, 79);
            this.destLocInputField.Name = "destLocInputField";
            this.destLocInputField.Size = new System.Drawing.Size(111, 21);
            this.destLocInputField.TabIndex = 17;
            // 
            // endLocLabel
            // 
            this.endLocLabel.AutoSize = true;
            this.endLocLabel.Location = new System.Drawing.Point(16, 82);
            this.endLocLabel.Name = "endLocLabel";
            this.endLocLabel.Size = new System.Drawing.Size(70, 12);
            this.endLocLabel.TabIndex = 16;
            this.endLocLabel.Text = "Target Dest";
            // 
            // startLocInputField
            // 
            this.startLocInputField.Location = new System.Drawing.Point(153, 55);
            this.startLocInputField.Name = "startLocInputField";
            this.startLocInputField.Size = new System.Drawing.Size(111, 21);
            this.startLocInputField.TabIndex = 15;
            // 
            // startLocLabel
            // 
            this.startLocLabel.AutoSize = true;
            this.startLocLabel.Location = new System.Drawing.Point(15, 58);
            this.startLocLabel.Name = "startLocLabel";
            this.startLocLabel.Size = new System.Drawing.Size(82, 12);
            this.startLocLabel.TabIndex = 14;
            this.startLocLabel.Text = "Start Location";
            // 
            // taskIdLabel
            // 
            this.taskIdLabel.AutoSize = true;
            this.taskIdLabel.Location = new System.Drawing.Point(16, 31);
            this.taskIdLabel.Name = "taskIdLabel";
            this.taskIdLabel.Size = new System.Drawing.Size(48, 12);
            this.taskIdLabel.TabIndex = 13;
            this.taskIdLabel.Text = "Task ID";
            // 
            // taskIdInputField
            // 
            this.taskIdInputField.Location = new System.Drawing.Point(153, 31);
            this.taskIdInputField.Name = "taskIdInputField";
            this.taskIdInputField.Size = new System.Drawing.Size(111, 21);
            this.taskIdInputField.TabIndex = 10;
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(198, 163);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(73, 23);
            this.addTaskBtn.TabIndex = 2;
            this.addTaskBtn.Text = "Add";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // additionalDetailGroupBox
            // 
            this.additionalDetailGroupBox.Controls.Add(this.msgDelayTimeLabel);
            this.additionalDetailGroupBox.Controls.Add(this.msgDelayTimeInputF);
            this.additionalDetailGroupBox.Controls.Add(this.msgEventTypeLabel);
            this.additionalDetailGroupBox.Controls.Add(this.msgTickPerDelay);
            this.additionalDetailGroupBox.Controls.Add(this.eventTypeInputF);
            this.additionalDetailGroupBox.Controls.Add(this.tickPerDelayTime);
            this.additionalDetailGroupBox.Location = new System.Drawing.Point(17, 203);
            this.additionalDetailGroupBox.Name = "additionalDetailGroupBox";
            this.additionalDetailGroupBox.Size = new System.Drawing.Size(312, 178);
            this.additionalDetailGroupBox.TabIndex = 19;
            this.additionalDetailGroupBox.TabStop = false;
            this.additionalDetailGroupBox.Text = "Additional Input Field";
            this.additionalDetailGroupBox.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // msgDelayTimeLabel
            // 
            this.msgDelayTimeLabel.AutoSize = true;
            this.msgDelayTimeLabel.Location = new System.Drawing.Point(6, 47);
            this.msgDelayTimeLabel.Name = "msgDelayTimeLabel";
            this.msgDelayTimeLabel.Size = new System.Drawing.Size(119, 12);
            this.msgDelayTimeLabel.TabIndex = 17;
            this.msgDelayTimeLabel.Text = "전송 딜레이 시간(초)";
            // 
            // msgDelayTimeInputF
            // 
            this.msgDelayTimeInputF.Location = new System.Drawing.Point(163, 44);
            this.msgDelayTimeInputF.Name = "msgDelayTimeInputF";
            this.msgDelayTimeInputF.Size = new System.Drawing.Size(111, 21);
            this.msgDelayTimeInputF.TabIndex = 16;
            // 
            // msgEventTypeLabel
            // 
            this.msgEventTypeLabel.AutoSize = true;
            this.msgEventTypeLabel.Location = new System.Drawing.Point(7, 74);
            this.msgEventTypeLabel.Name = "msgEventTypeLabel";
            this.msgEventTypeLabel.Size = new System.Drawing.Size(69, 12);
            this.msgEventTypeLabel.TabIndex = 14;
            this.msgEventTypeLabel.Text = "이벤트 유형";
            // 
            // msgTickPerDelay
            // 
            this.msgTickPerDelay.AutoSize = true;
            this.msgTickPerDelay.Location = new System.Drawing.Point(6, 20);
            this.msgTickPerDelay.Name = "msgTickPerDelay";
            this.msgTickPerDelay.Size = new System.Drawing.Size(85, 12);
            this.msgTickPerDelay.TabIndex = 12;
            this.msgTickPerDelay.Text = "딜레이당 틱 수";
            // 
            // eventTypeInputF
            // 
            this.eventTypeInputF.Location = new System.Drawing.Point(163, 74);
            this.eventTypeInputF.Name = "eventTypeInputF";
            this.eventTypeInputF.Size = new System.Drawing.Size(111, 21);
            this.eventTypeInputF.TabIndex = 11;
            // 
            // tickPerDelayTime
            // 
            this.tickPerDelayTime.Location = new System.Drawing.Point(163, 17);
            this.tickPerDelayTime.Name = "tickPerDelayTime";
            this.tickPerDelayTime.Size = new System.Drawing.Size(111, 21);
            this.tickPerDelayTime.TabIndex = 9;
            // 
            // robotDetailGroupBox
            // 
            this.robotDetailGroupBox.Controls.Add(this.robotListView);
            this.robotDetailGroupBox.Controls.Add(this.removeRobotBtn);
            this.robotDetailGroupBox.Controls.Add(this.addRobotBtn);
            this.robotDetailGroupBox.Controls.Add(this.robotNameLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotModelLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotSidLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotNameInputField);
            this.robotDetailGroupBox.Controls.Add(this.robotModelInputField);
            this.robotDetailGroupBox.Controls.Add(this.robotSidInputField);
            this.robotDetailGroupBox.Location = new System.Drawing.Point(17, 6);
            this.robotDetailGroupBox.Name = "robotDetailGroupBox";
            this.robotDetailGroupBox.Size = new System.Drawing.Size(706, 192);
            this.robotDetailGroupBox.TabIndex = 18;
            this.robotDetailGroupBox.TabStop = false;
            this.robotDetailGroupBox.Text = "Add Robot Data";
            // 
            // robotListView
            // 
            this.robotListView.HideSelection = false;
            this.robotListView.Location = new System.Drawing.Point(395, 18);
            this.robotListView.MultiSelect = false;
            this.robotListView.Name = "robotListView";
            this.robotListView.Size = new System.Drawing.Size(303, 169);
            this.robotListView.TabIndex = 18;
            this.robotListView.UseCompatibleStateImageBehavior = false;
            this.robotListView.SelectedIndexChanged += new System.EventHandler(this.robotListView_SelectedIndexChanged);
            // 
            // removeRobotBtn
            // 
            this.removeRobotBtn.Location = new System.Drawing.Point(227, 42);
            this.removeRobotBtn.Name = "removeRobotBtn";
            this.removeRobotBtn.Size = new System.Drawing.Size(163, 21);
            this.removeRobotBtn.TabIndex = 17;
            this.removeRobotBtn.Text = "Remove Robot";
            this.removeRobotBtn.UseVisualStyleBackColor = true;
            this.removeRobotBtn.Click += new System.EventHandler(this.removeRobotBtn_Click);
            // 
            // addRobotBtn
            // 
            this.addRobotBtn.Location = new System.Drawing.Point(227, 18);
            this.addRobotBtn.Name = "addRobotBtn";
            this.addRobotBtn.Size = new System.Drawing.Size(163, 21);
            this.addRobotBtn.TabIndex = 15;
            this.addRobotBtn.Text = "Add Robot";
            this.addRobotBtn.UseVisualStyleBackColor = true;
            this.addRobotBtn.Click += new System.EventHandler(this.addRobotBtn_Click);
            // 
            // robotNameLabel
            // 
            this.robotNameLabel.AutoSize = true;
            this.robotNameLabel.Location = new System.Drawing.Point(7, 66);
            this.robotNameLabel.Name = "robotNameLabel";
            this.robotNameLabel.Size = new System.Drawing.Size(91, 12);
            this.robotNameLabel.TabIndex = 14;
            this.robotNameLabel.Text = "User Def Name";
            // 
            // robotModelLabel
            // 
            this.robotModelLabel.AutoSize = true;
            this.robotModelLabel.Location = new System.Drawing.Point(6, 47);
            this.robotModelLabel.Name = "robotModelLabel";
            this.robotModelLabel.Size = new System.Drawing.Size(76, 12);
            this.robotModelLabel.TabIndex = 13;
            this.robotModelLabel.Text = "Robot Model";
            // 
            // robotSidLabel
            // 
            this.robotSidLabel.AutoSize = true;
            this.robotSidLabel.Location = new System.Drawing.Point(6, 26);
            this.robotSidLabel.Name = "robotSidLabel";
            this.robotSidLabel.Size = new System.Drawing.Size(60, 12);
            this.robotSidLabel.TabIndex = 12;
            this.robotSidLabel.Text = "Robot SID";
            // 
            // robotNameInputField
            // 
            this.robotNameInputField.Location = new System.Drawing.Point(108, 63);
            this.robotNameInputField.Name = "robotNameInputField";
            this.robotNameInputField.Size = new System.Drawing.Size(111, 21);
            this.robotNameInputField.TabIndex = 11;
            // 
            // robotModelInputField
            // 
            this.robotModelInputField.Location = new System.Drawing.Point(108, 41);
            this.robotModelInputField.Name = "robotModelInputField";
            this.robotModelInputField.Size = new System.Drawing.Size(111, 21);
            this.robotModelInputField.TabIndex = 10;
            this.robotModelInputField.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // robotSidInputField
            // 
            this.robotSidInputField.Location = new System.Drawing.Point(108, 18);
            this.robotSidInputField.Name = "robotSidInputField";
            this.robotSidInputField.Size = new System.Drawing.Size(111, 21);
            this.robotSidInputField.TabIndex = 9;
            this.robotSidInputField.TextChanged += new System.EventHandler(this.robotSidInputField_TextChanged);
            // 
            // mqttConnectTabPage
            // 
            this.mqttConnectTabPage.Controls.Add(this.mqttScurityInfoGroup);
            this.mqttConnectTabPage.Controls.Add(this.mqttBasicInfoGroupBox);
            this.mqttConnectTabPage.Location = new System.Drawing.Point(4, 22);
            this.mqttConnectTabPage.Name = "mqttConnectTabPage";
            this.mqttConnectTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mqttConnectTabPage.Size = new System.Drawing.Size(1024, 373);
            this.mqttConnectTabPage.TabIndex = 1;
            this.mqttConnectTabPage.Text = "접속 설정";
            this.mqttConnectTabPage.UseVisualStyleBackColor = true;
            // 
            // mqttScurityInfoGroup
            // 
            this.mqttScurityInfoGroup.Controls.Add(this.isCredentialEnabledCheckbox);
            this.mqttScurityInfoGroup.Controls.Add(this.isSSLConnectCheckBox);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttPassLabel);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttUserNameLabel);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttPassInputF);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttUserNameInputF);
            this.mqttScurityInfoGroup.Location = new System.Drawing.Point(346, 19);
            this.mqttScurityInfoGroup.Name = "mqttScurityInfoGroup";
            this.mqttScurityInfoGroup.Size = new System.Drawing.Size(314, 176);
            this.mqttScurityInfoGroup.TabIndex = 20;
            this.mqttScurityInfoGroup.TabStop = false;
            this.mqttScurityInfoGroup.Text = "보안 정보 입력 (선택)";
            // 
            // isCredentialEnabledCheckbox
            // 
            this.isCredentialEnabledCheckbox.AutoSize = true;
            this.isCredentialEnabledCheckbox.Location = new System.Drawing.Point(108, 64);
            this.isCredentialEnabledCheckbox.Name = "isCredentialEnabledCheckbox";
            this.isCredentialEnabledCheckbox.Size = new System.Drawing.Size(76, 16);
            this.isCredentialEnabledCheckbox.TabIndex = 17;
            this.isCredentialEnabledCheckbox.Text = "암호 허용";
            this.isCredentialEnabledCheckbox.UseVisualStyleBackColor = true;
            this.isCredentialEnabledCheckbox.CheckedChanged += new System.EventHandler(this.isCredentialEnabledCheckBox_CheckedChange);
            // 
            // isSSLConnectCheckBox
            // 
            this.isSSLConnectCheckBox.AutoSize = true;
            this.isSSLConnectCheckBox.Location = new System.Drawing.Point(108, 28);
            this.isSSLConnectCheckBox.Name = "isSSLConnectCheckBox";
            this.isSSLConnectCheckBox.Size = new System.Drawing.Size(75, 16);
            this.isSSLConnectCheckBox.TabIndex = 16;
            this.isSSLConnectCheckBox.Text = "SSL 연결";
            this.isSSLConnectCheckBox.UseVisualStyleBackColor = true;
            this.isSSLConnectCheckBox.CheckedChanged += new System.EventHandler(this.isSSLConnectCheckBox_CheckedChanged);
            // 
            // mqttPassLabel
            // 
            this.mqttPassLabel.AutoSize = true;
            this.mqttPassLabel.Location = new System.Drawing.Point(6, 139);
            this.mqttPassLabel.Name = "mqttPassLabel";
            this.mqttPassLabel.Size = new System.Drawing.Size(53, 12);
            this.mqttPassLabel.TabIndex = 14;
            this.mqttPassLabel.Text = "비밀번호";
            // 
            // mqttUserNameLabel
            // 
            this.mqttUserNameLabel.AutoSize = true;
            this.mqttUserNameLabel.Location = new System.Drawing.Point(6, 103);
            this.mqttUserNameLabel.Name = "mqttUserNameLabel";
            this.mqttUserNameLabel.Size = new System.Drawing.Size(69, 12);
            this.mqttUserNameLabel.TabIndex = 13;
            this.mqttUserNameLabel.Text = "사용자 이름";
            // 
            // mqttPassInputF
            // 
            this.mqttPassInputF.Location = new System.Drawing.Point(108, 136);
            this.mqttPassInputF.Name = "mqttPassInputF";
            this.mqttPassInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttPassInputF.TabIndex = 11;
            this.mqttPassInputF.TextChanged += new System.EventHandler(this.mqttPassInputF_TextChanged);
            // 
            // mqttUserNameInputF
            // 
            this.mqttUserNameInputF.Location = new System.Drawing.Point(108, 100);
            this.mqttUserNameInputF.Name = "mqttUserNameInputF";
            this.mqttUserNameInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttUserNameInputF.TabIndex = 10;
            this.mqttUserNameInputF.TextChanged += new System.EventHandler(this.mqttUserNameInputF_TextChanged);
            // 
            // mqttBasicInfoGroupBox
            // 
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttClientIdF);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttClientNameLabel);
            this.mqttBasicInfoGroupBox.Controls.Add(this.connectionTestBtn1);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttTopicLabel);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttBrokerPortLabel);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttBrokerIpLabel);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttTopicInputF);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttPortInputF);
            this.mqttBasicInfoGroupBox.Controls.Add(this.mqttIpInputF);
            this.mqttBasicInfoGroupBox.Location = new System.Drawing.Point(6, 19);
            this.mqttBasicInfoGroupBox.Name = "mqttBasicInfoGroupBox";
            this.mqttBasicInfoGroupBox.Size = new System.Drawing.Size(314, 176);
            this.mqttBasicInfoGroupBox.TabIndex = 19;
            this.mqttBasicInfoGroupBox.TabStop = false;
            this.mqttBasicInfoGroupBox.Text = "MQTT 정보 입력";
            // 
            // mqttClientIdF
            // 
            this.mqttClientIdF.Location = new System.Drawing.Point(108, 130);
            this.mqttClientIdF.Name = "mqttClientIdF";
            this.mqttClientIdF.Size = new System.Drawing.Size(111, 21);
            this.mqttClientIdF.TabIndex = 17;
            this.mqttClientIdF.TextChanged += new System.EventHandler(this.mqttClientIdF_TextChanged);
            // 
            // mqttClientNameLabel
            // 
            this.mqttClientNameLabel.AutoSize = true;
            this.mqttClientNameLabel.Location = new System.Drawing.Point(6, 133);
            this.mqttClientNameLabel.Name = "mqttClientNameLabel";
            this.mqttClientNameLabel.Size = new System.Drawing.Size(93, 12);
            this.mqttClientNameLabel.TabIndex = 16;
            this.mqttClientNameLabel.Text = "클라이언트 이름";
            // 
            // connectionTestBtn1
            // 
            this.connectionTestBtn1.Font = new System.Drawing.Font("굴림", 7F);
            this.connectionTestBtn1.Location = new System.Drawing.Point(241, 152);
            this.connectionTestBtn1.Name = "connectionTestBtn1";
            this.connectionTestBtn1.Size = new System.Drawing.Size(66, 18);
            this.connectionTestBtn1.TabIndex = 15;
            this.connectionTestBtn1.Text = "접속 테스트";
            this.connectionTestBtn1.UseVisualStyleBackColor = true;
            this.connectionTestBtn1.Click += new System.EventHandler(this.connectionTestBtn1_Click);
            // 
            // mqttTopicLabel
            // 
            this.mqttTopicLabel.AutoSize = true;
            this.mqttTopicLabel.Location = new System.Drawing.Point(6, 100);
            this.mqttTopicLabel.Name = "mqttTopicLabel";
            this.mqttTopicLabel.Size = new System.Drawing.Size(69, 12);
            this.mqttTopicLabel.TabIndex = 14;
            this.mqttTopicLabel.Text = "MQTT 토픽";
            // 
            // mqttBrokerPortLabel
            // 
            this.mqttBrokerPortLabel.AutoSize = true;
            this.mqttBrokerPortLabel.Location = new System.Drawing.Point(6, 64);
            this.mqttBrokerPortLabel.Name = "mqttBrokerPortLabel";
            this.mqttBrokerPortLabel.Size = new System.Drawing.Size(78, 12);
            this.mqttBrokerPortLabel.TabIndex = 13;
            this.mqttBrokerPortLabel.Text = "브로커 PORT";
            // 
            // mqttBrokerIpLabel
            // 
            this.mqttBrokerIpLabel.AutoSize = true;
            this.mqttBrokerIpLabel.Location = new System.Drawing.Point(6, 26);
            this.mqttBrokerIpLabel.Name = "mqttBrokerIpLabel";
            this.mqttBrokerIpLabel.Size = new System.Drawing.Size(56, 12);
            this.mqttBrokerIpLabel.TabIndex = 12;
            this.mqttBrokerIpLabel.Text = "브로커 IP";
            // 
            // mqttTopicInputF
            // 
            this.mqttTopicInputF.Location = new System.Drawing.Point(108, 97);
            this.mqttTopicInputF.Name = "mqttTopicInputF";
            this.mqttTopicInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttTopicInputF.TabIndex = 11;
            this.mqttTopicInputF.TextChanged += new System.EventHandler(this.mqttTopicInputF_TextChanged);
            // 
            // mqttPortInputF
            // 
            this.mqttPortInputF.Location = new System.Drawing.Point(108, 61);
            this.mqttPortInputF.Name = "mqttPortInputF";
            this.mqttPortInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttPortInputF.TabIndex = 10;
            this.mqttPortInputF.TextChanged += new System.EventHandler(this.mqttPortInputF_TextChanged);
            // 
            // mqttIpInputF
            // 
            this.mqttIpInputF.Location = new System.Drawing.Point(108, 23);
            this.mqttIpInputF.Name = "mqttIpInputF";
            this.mqttIpInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttIpInputF.TabIndex = 9;
            this.mqttIpInputF.TextChanged += new System.EventHandler(this.mqttIpInputF_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 646);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 21);
            this.progressBar1.TabIndex = 5;
            // 
            // processCancelBtn
            // 
            this.processCancelBtn.Location = new System.Drawing.Point(429, 646);
            this.processCancelBtn.Name = "processCancelBtn";
            this.processCancelBtn.Size = new System.Drawing.Size(79, 23);
            this.processCancelBtn.TabIndex = 6;
            this.processCancelBtn.Text = "Stop";
            this.processCancelBtn.UseVisualStyleBackColor = true;
            this.processCancelBtn.Click += new System.EventHandler(this.cancelProcessBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 458);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1022, 182);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 678);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.processCancelBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.showExampleDataBtn);
            this.Controls.Add(this.publishMsgBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vision Space MQTT Generator v0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.amrTabPage.ResumeLayout(false);
            this.taskListPanel.ResumeLayout(false);
            this.taskGroupBox.ResumeLayout(false);
            this.taskGroupBox.PerformLayout();
            this.additionalDetailGroupBox.ResumeLayout(false);
            this.additionalDetailGroupBox.PerformLayout();
            this.robotDetailGroupBox.ResumeLayout(false);
            this.robotDetailGroupBox.PerformLayout();
            this.mqttConnectTabPage.ResumeLayout(false);
            this.mqttScurityInfoGroup.ResumeLayout(false);
            this.mqttScurityInfoGroup.PerformLayout();
            this.mqttBasicInfoGroupBox.ResumeLayout(false);
            this.mqttBasicInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.MainMenu mainMenu1;

        private System.Windows.Forms.Button editTaskBtn;

        private System.Windows.Forms.RichTextBox richTextBox1;

        private System.Windows.Forms.ListView robotListView;

        private System.Windows.Forms.Button addRobotBtn;
        private System.Windows.Forms.Button removeRobotBtn;

        private System.Windows.Forms.Button processCancelBtn;

        private System.Windows.Forms.TextBox moveTimeInputField;
        private System.Windows.Forms.TextBox workTimeInputField;
        private System.Windows.Forms.ListView taskListView;

        private System.Windows.Forms.TextBox taskIdInputField;

        private System.Windows.Forms.Label workTimeLabel;
        private System.Windows.Forms.Label taskIdLabel;

        private System.Windows.Forms.Label moveTimeLabel;

        private System.Windows.Forms.Label endLocLabel;
        private System.Windows.Forms.TextBox destLocInputField;

        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.Panel taskListPanel;
        private System.Windows.Forms.Button seeTaskDetailBtn;
        private System.Windows.Forms.Button RemoveTaskBtn;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.TextBox startLocInputField;
        private System.Windows.Forms.Label startLocLabel;

        private System.Windows.Forms.CheckBox isCredentialEnabledCheckbox;

        #endregion

        private System.Windows.Forms.Button publishMsgBtn;
        private System.Windows.Forms.Button showExampleDataBtn;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mqttConnectTabPage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage amrTabPage;
        private System.Windows.Forms.GroupBox robotDetailGroupBox;
        private System.Windows.Forms.Label robotNameLabel;
        private System.Windows.Forms.Label robotModelLabel;
        private System.Windows.Forms.Label robotSidLabel;
        private System.Windows.Forms.TextBox robotNameInputField;
        private System.Windows.Forms.TextBox robotModelInputField;
        private System.Windows.Forms.TextBox robotSidInputField;
        private System.Windows.Forms.GroupBox additionalDetailGroupBox;
        private System.Windows.Forms.Label msgEventTypeLabel;
        private System.Windows.Forms.Label msgTickPerDelay;
        private System.Windows.Forms.TextBox eventTypeInputF;
        private System.Windows.Forms.TextBox tickPerDelayTime;
        private System.Windows.Forms.GroupBox mqttBasicInfoGroupBox;
        private System.Windows.Forms.Label mqttTopicLabel;
        private System.Windows.Forms.Label mqttBrokerPortLabel;
        private System.Windows.Forms.Label mqttBrokerIpLabel;
        private System.Windows.Forms.TextBox mqttTopicInputF;
        private System.Windows.Forms.TextBox mqttPortInputF;
        private System.Windows.Forms.TextBox mqttIpInputF;
        private System.Windows.Forms.Button connectionTestBtn1;
        private System.Windows.Forms.GroupBox mqttScurityInfoGroup;
        private System.Windows.Forms.CheckBox isSSLConnectCheckBox;
        private System.Windows.Forms.Label mqttPassLabel;
        private System.Windows.Forms.Label mqttUserNameLabel;
        private System.Windows.Forms.TextBox mqttPassInputF;
        private System.Windows.Forms.TextBox mqttUserNameInputF;
        private System.Windows.Forms.Label msgDelayTimeLabel;
        private System.Windows.Forms.TextBox msgDelayTimeInputF;
        private System.Windows.Forms.TextBox mqttClientIdF;
        private System.Windows.Forms.Label mqttClientNameLabel;
    }
}

