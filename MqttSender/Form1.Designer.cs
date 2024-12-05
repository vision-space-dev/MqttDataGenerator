/**
 * 제작자: marcobackman (Tony Baek)
 */

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
            this.publishMsgBtn = new System.Windows.Forms.Button();
            this.showExampleDataBtn = new System.Windows.Forms.Button();
            this.validateBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.amrTabPage = new System.Windows.Forms.TabPage();
            this.additionalDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.autoSendDurationInputF = new System.Windows.Forms.TextBox();
            this.autoRunTimeLabel = new System.Windows.Forms.Label();
            this.msgDelayTimeLabel = new System.Windows.Forms.Label();
            this.msgDelayTimeInputF = new System.Windows.Forms.TextBox();
            this.msgEventTypeLabel = new System.Windows.Forms.Label();
            this.dynamicLocVariantLabel = new System.Windows.Forms.Label();
            this.msgPerSecGenerateLabel = new System.Windows.Forms.Label();
            this.eventTypeInputF = new System.Windows.Forms.TextBox();
            this.locationVariantInputF = new System.Windows.Forms.TextBox();
            this.msgPerSecondInputF = new System.Windows.Forms.TextBox();
            this.robotDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.robotNameLabel = new System.Windows.Forms.Label();
            this.robotModelLabel = new System.Windows.Forms.Label();
            this.robotSidLabel = new System.Windows.Forms.Label();
            this.robotNameInputField = new System.Windows.Forms.TextBox();
            this.robotModelInputField = new System.Windows.Forms.TextBox();
            this.robotSidInputField = new System.Windows.Forms.TextBox();
            this.maxCoordGroupBox = new System.Windows.Forms.GroupBox();
            this.maxCoordLabelZ = new System.Windows.Forms.Label();
            this.maxCoordLabelY = new System.Windows.Forms.Label();
            this.maxCoordLabelX = new System.Windows.Forms.Label();
            this.maxZValInputF = new System.Windows.Forms.TextBox();
            this.maxYValInputF = new System.Windows.Forms.TextBox();
            this.maxXValInputF = new System.Windows.Forms.TextBox();
            this.minCoordGroupBox = new System.Windows.Forms.GroupBox();
            this.mingCoordLabelZ = new System.Windows.Forms.Label();
            this.minCoordLabelY = new System.Windows.Forms.Label();
            this.minXCoordLabelX = new System.Windows.Forms.Label();
            this.minZValInputF = new System.Windows.Forms.TextBox();
            this.minYValInputF = new System.Windows.Forms.TextBox();
            this.minXValInputF = new System.Windows.Forms.TextBox();
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
            this.tabControl1.SuspendLayout();
            this.amrTabPage.SuspendLayout();
            this.additionalDetailGroupBox.SuspendLayout();
            this.robotDetailGroupBox.SuspendLayout();
            this.maxCoordGroupBox.SuspendLayout();
            this.minCoordGroupBox.SuspendLayout();
            this.mqttConnectTabPage.SuspendLayout();
            this.mqttScurityInfoGroup.SuspendLayout();
            this.mqttBasicInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            
            /********************************************************
             *                         FORM                         *
             ********************************************************/
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.showExampleDataBtn);
            this.Controls.Add(this.publishMsgBtn);
            this.Name = "Form1";
            this.Text = "MQTT 송신기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.amrTabPage.ResumeLayout(false);
            this.additionalDetailGroupBox.ResumeLayout(false);
            this.additionalDetailGroupBox.PerformLayout();
            this.robotDetailGroupBox.ResumeLayout(false);
            this.robotDetailGroupBox.PerformLayout();
            this.maxCoordGroupBox.ResumeLayout(false);
            this.maxCoordGroupBox.PerformLayout();
            this.minCoordGroupBox.ResumeLayout(false);
            this.minCoordGroupBox.PerformLayout();
            this.mqttConnectTabPage.ResumeLayout(false);
            this.mqttScurityInfoGroup.ResumeLayout(false);
            this.mqttScurityInfoGroup.PerformLayout();
            this.mqttBasicInfoGroupBox.ResumeLayout(false);
            this.mqttBasicInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            
            /********************************************************
             *                  General BUTTONS                     *
             ********************************************************/

            this.showExampleDataBtn.Location = new System.Drawing.Point(544, 408);
            this.showExampleDataBtn.Name = "showExampleDataBtn";
            this.showExampleDataBtn.Size = new System.Drawing.Size(107, 21);
            this.showExampleDataBtn.TabIndex = 1;
            this.showExampleDataBtn.Text = "예시 데이터 보기";
            this.showExampleDataBtn.UseVisualStyleBackColor = true;
            
            this.publishMsgBtn.Location = new System.Drawing.Point(657, 408);
            this.publishMsgBtn.Name = "publishMsgBtn";
            this.publishMsgBtn.Size = new System.Drawing.Size(106, 21);
            this.publishMsgBtn.TabIndex = 0;
            this.publishMsgBtn.Text = "자동 PUBLUSH";
            this.publishMsgBtn.UseVisualStyleBackColor = true;

            this.validateBtn.Location = new System.Drawing.Point(446, 408);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(92, 21);
            this.validateBtn.TabIndex = 2;
            this.validateBtn.Text = "Validate";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.button3_Click);

            /**
             * TAB 컨트롤
             */
            this.tabControl1.Controls.Add(this.amrTabPage);
            this.tabControl1.Controls.Add(this.mqttConnectTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 379);
            this.tabControl1.TabIndex = 4;
            
            /**************************************************************
             *                        AMR TAB PAGE                        *
             **************************************************************/
            this.amrTabPage.Controls.Add(this.additionalDetailGroupBox);
            this.amrTabPage.Controls.Add(this.robotDetailGroupBox);
            this.amrTabPage.Controls.Add(this.maxCoordGroupBox);
            this.amrTabPage.Controls.Add(this.minCoordGroupBox);
            this.amrTabPage.Location = new System.Drawing.Point(4, 22);
            this.amrTabPage.Name = "amrTabPage";
            this.amrTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.amrTabPage.Size = new System.Drawing.Size(768, 353);
            this.amrTabPage.TabIndex = 0;
            this.amrTabPage.Text = "AMR 기본 정보 입력";
            this.amrTabPage.UseVisualStyleBackColor = true;
            this.amrTabPage.Click += new System.EventHandler(this.tabPage1_Click);

            /**************************************************************
             *                   Robot detail group box                   *
             **************************************************************/
            
            this.robotDetailGroupBox.Controls.Add(this.robotNameLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotModelLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotSidLabel);
            this.robotDetailGroupBox.Controls.Add(this.robotNameInputField);
            this.robotDetailGroupBox.Controls.Add(this.robotModelInputField);
            this.robotDetailGroupBox.Controls.Add(this.robotSidInputField);
            this.robotDetailGroupBox.Location = new System.Drawing.Point(17, 20);
            this.robotDetailGroupBox.Name = "robotDetailGroupBox";
            this.robotDetailGroupBox.Size = new System.Drawing.Size(314, 133);
            this.robotDetailGroupBox.TabIndex = 18;
            this.robotDetailGroupBox.TabStop = false;
            this.robotDetailGroupBox.Text = "로봇 정보 입력";
            
            /**************************************************************
             *              Robot detail configuration labels             *
             **************************************************************/

            this.robotSidLabel.AutoSize = true;
            this.robotSidLabel.Location = new System.Drawing.Point(6, 26);
            this.robotSidLabel.Name = "robotSidLabel";
            this.robotSidLabel.Size = new System.Drawing.Size(52, 12);
            this.robotSidLabel.TabIndex = 12;
            this.robotSidLabel.Text = "로봇 SID";
            
            this.robotModelLabel.AutoSize = true;
            this.robotModelLabel.Location = new System.Drawing.Point(6, 64);
            this.robotModelLabel.Name = "robotModelLabel";
            this.robotModelLabel.Size = new System.Drawing.Size(85, 12);
            this.robotModelLabel.TabIndex = 13;
            this.robotModelLabel.Text = "로봇 모델 이름";
            
            this.robotNameLabel.AutoSize = true;
            this.robotNameLabel.Location = new System.Drawing.Point(6, 100);
            this.robotNameLabel.Name = "robotNameLabel";
            this.robotNameLabel.Size = new System.Drawing.Size(97, 12);
            this.robotNameLabel.TabIndex = 14;
            this.robotNameLabel.Text = "사용자 정의 이름";
            
            /************************************************************
             *           Robot detail configuration input fields        *
             ************************************************************/
            
            this.robotSidInputField.Location = new System.Drawing.Point(109, 23);
            this.robotSidInputField.Name = "robotSidInputField";
            this.robotSidInputField.Size = new System.Drawing.Size(111, 21);
            this.robotSidInputField.TabIndex = 9;
            this.robotSidInputField.TextChanged += new System.EventHandler(this.robotSidInputField_TextChanged);
            
            this.robotModelInputField.Location = new System.Drawing.Point(109, 61);
            this.robotModelInputField.Name = "robotModelInputField";
            this.robotModelInputField.Size = new System.Drawing.Size(111, 21);
            this.robotModelInputField.TabIndex = 10;
            this.robotModelInputField.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            
            this.robotNameInputField.Location = new System.Drawing.Point(109, 97);
            this.robotNameInputField.Name = "robotNameInputField";
            this.robotNameInputField.Size = new System.Drawing.Size(111, 21);
            this.robotNameInputField.TabIndex = 11;
            
            /**************************************************************
             *            Min coordinate configuration group box          *
             **************************************************************/
            
            this.minCoordGroupBox.Controls.Add(this.mingCoordLabelZ);
            this.minCoordGroupBox.Controls.Add(this.minCoordLabelY);
            this.minCoordGroupBox.Controls.Add(this.minXCoordLabelX);
            this.minCoordGroupBox.Controls.Add(this.minZValInputF);
            this.minCoordGroupBox.Controls.Add(this.minYValInputF);
            this.minCoordGroupBox.Controls.Add(this.minXValInputF);
            this.minCoordGroupBox.Location = new System.Drawing.Point(337, 20);
            this.minCoordGroupBox.Name = "minCoordGroupBox";
            this.minCoordGroupBox.Size = new System.Drawing.Size(203, 133);
            this.minCoordGroupBox.TabIndex = 15;
            this.minCoordGroupBox.TabStop = false;
            this.minCoordGroupBox.Text = "좌표 최소 값 설정";
            
            /**************************************************************
             *             Min coordinate configuration labels           *
             **************************************************************/
            
            this.minXCoordLabelX.AutoSize = true;
            this.minXCoordLabelX.Location = new System.Drawing.Point(6, 26);
            this.minXCoordLabelX.Name = "minXCoordLabelX";
            this.minXCoordLabelX.Size = new System.Drawing.Size(40, 12);
            this.minXCoordLabelX.TabIndex = 12;
            this.minXCoordLabelX.Text = "x 좌표";

            this.minCoordLabelY.AutoSize = true;
            this.minCoordLabelY.Location = new System.Drawing.Point(6, 64);
            this.minCoordLabelY.Name = "minCoordLabelY";
            this.minCoordLabelY.Size = new System.Drawing.Size(40, 12);
            this.minCoordLabelY.TabIndex = 13;
            this.minCoordLabelY.Text = "y 좌표";

            this.mingCoordLabelZ.AutoSize = true;
            this.mingCoordLabelZ.Location = new System.Drawing.Point(6, 100);
            this.mingCoordLabelZ.Name = "mingCoordLabelZ";
            this.mingCoordLabelZ.Size = new System.Drawing.Size(40, 12);
            this.mingCoordLabelZ.TabIndex = 14;
            this.mingCoordLabelZ.Text = "z 좌표";
            
            /**************************************************************
             *          Min coordinate configuration input fields         *
             **************************************************************/
            
            //min x
            this.minXValInputF.Location = new System.Drawing.Point(80, 23);
            this.minXValInputF.Name = "minXValInputF";
            this.minXValInputF.Size = new System.Drawing.Size(111, 21);
            this.minXValInputF.TabIndex = 9;
            
            //min y
            this.minYValInputF.Location = new System.Drawing.Point(80, 61);
            this.minYValInputF.Name = "minYValInputF";
            this.minYValInputF.Size = new System.Drawing.Size(111, 21);
            this.minYValInputF.TabIndex = 10;
            
            //min z
            this.minZValInputF.Location = new System.Drawing.Point(80, 97);
            this.minZValInputF.Name = "minZValInputF";
            this.minZValInputF.Size = new System.Drawing.Size(111, 21);
            this.minZValInputF.TabIndex = 11;
            
            /**************************************************************
             *            Max coordinate configuration group box          *
             **************************************************************/
            
            this.maxCoordGroupBox.Controls.Add(this.maxCoordLabelZ);
            this.maxCoordGroupBox.Controls.Add(this.maxCoordLabelY);
            this.maxCoordGroupBox.Controls.Add(this.maxCoordLabelX);
            this.maxCoordGroupBox.Controls.Add(this.maxZValInputF);
            this.maxCoordGroupBox.Controls.Add(this.maxYValInputF);
            this.maxCoordGroupBox.Controls.Add(this.maxXValInputF);
            this.maxCoordGroupBox.Location = new System.Drawing.Point(546, 20);
            this.maxCoordGroupBox.Name = "maxCoordGroupBox";
            this.maxCoordGroupBox.Size = new System.Drawing.Size(203, 133);
            this.maxCoordGroupBox.TabIndex = 16;
            this.maxCoordGroupBox.TabStop = false;
            this.maxCoordGroupBox.Text = "좌표 최대 값 설정";
            
            /**************************************************************
             *             Min coordinate configuration labels            *
             **************************************************************/
            
            this.maxCoordLabelX.AutoSize = true;
            this.maxCoordLabelX.Location = new System.Drawing.Point(6, 26);
            this.maxCoordLabelX.Name = "maxCoordLabelX";
            this.maxCoordLabelX.Size = new System.Drawing.Size(40, 12);
            this.maxCoordLabelX.TabIndex = 12;
            this.maxCoordLabelX.Text = "x 좌표";
            
            this.maxCoordLabelY.AutoSize = true;
            this.maxCoordLabelY.Location = new System.Drawing.Point(6, 64);
            this.maxCoordLabelY.Name = "maxCoordLabelY";
            this.maxCoordLabelY.Size = new System.Drawing.Size(40, 12);
            this.maxCoordLabelY.TabIndex = 13;
            this.maxCoordLabelY.Text = "y 좌표";
            
            this.maxCoordLabelZ.AutoSize = true;
            this.maxCoordLabelZ.Location = new System.Drawing.Point(6, 100);
            this.maxCoordLabelZ.Name = "maxCoordLabelZ";
            this.maxCoordLabelZ.Size = new System.Drawing.Size(40, 12);
            this.maxCoordLabelZ.TabIndex = 14;
            this.maxCoordLabelZ.Text = "z 좌표";
            
            /**************************************************************
             *           Min coordinate configuration input fields        *
             **************************************************************/
            
            //max x
            this.maxXValInputF.Location = new System.Drawing.Point(80, 23);
            this.maxXValInputF.Name = "maxXValInputF";
            this.maxXValInputF.Size = new System.Drawing.Size(111, 21);
            this.maxXValInputF.TabIndex = 9;
            
            //max y
            this.maxYValInputF.Location = new System.Drawing.Point(80, 61);
            this.maxYValInputF.Name = "maxYValInputF";
            this.maxYValInputF.Size = new System.Drawing.Size(111, 21);
            this.maxYValInputF.TabIndex = 10;
            
            //max z
            this.maxZValInputF.Location = new System.Drawing.Point(80, 97);
            this.maxZValInputF.Name = "maxZValInputF";
            this.maxZValInputF.Size = new System.Drawing.Size(111, 21);
            this.maxZValInputF.TabIndex = 11;


            
            /**************************************************************
             *           Message publish configuration group box          *
             **************************************************************/
            
            this.additionalDetailGroupBox.Controls.Add(this.autoSendDurationInputF);
            this.additionalDetailGroupBox.Controls.Add(this.autoRunTimeLabel);
            this.additionalDetailGroupBox.Controls.Add(this.msgDelayTimeLabel);
            this.additionalDetailGroupBox.Controls.Add(this.msgDelayTimeInputF);
            this.additionalDetailGroupBox.Controls.Add(this.msgEventTypeLabel);
            this.additionalDetailGroupBox.Controls.Add(this.dynamicLocVariantLabel);
            this.additionalDetailGroupBox.Controls.Add(this.msgPerSecGenerateLabel);
            this.additionalDetailGroupBox.Controls.Add(this.eventTypeInputF);
            this.additionalDetailGroupBox.Controls.Add(this.locationVariantInputF);
            this.additionalDetailGroupBox.Controls.Add(this.msgPerSecondInputF);
            this.additionalDetailGroupBox.Location = new System.Drawing.Point(17, 159);
            this.additionalDetailGroupBox.Name = "additionalDetailGroupBox";
            this.additionalDetailGroupBox.Size = new System.Drawing.Size(732, 188);
            this.additionalDetailGroupBox.TabIndex = 19;
            this.additionalDetailGroupBox.TabStop = false;
            this.additionalDetailGroupBox.Text = "부가 기능 입력";
            this.additionalDetailGroupBox.Enter += new System.EventHandler(this.groupBox4_Enter);
            
            
            /**************************************************************
             *           Message publish configuration labels             *
             **************************************************************/
            
            this.msgPerSecGenerateLabel.AutoSize = true;
            this.msgPerSecGenerateLabel.Location = new System.Drawing.Point(6, 26);
            this.msgPerSecGenerateLabel.Name = "msgPerSecGenerateLabel";
            this.msgPerSecGenerateLabel.Size = new System.Drawing.Size(151, 12);
            this.msgPerSecGenerateLabel.TabIndex = 12;
            this.msgPerSecGenerateLabel.Text = "초당 메시지 생성 개수 (초)";
            
            this.msgDelayTimeLabel.AutoSize = true;
            this.msgDelayTimeLabel.Location = new System.Drawing.Point(6, 66);
            this.msgDelayTimeLabel.Name = "msgDelayTimeLabel";
            this.msgDelayTimeLabel.Size = new System.Drawing.Size(119, 12);
            this.msgDelayTimeLabel.TabIndex = 17;
            this.msgDelayTimeLabel.Text = "전송 딜레이 시간(초)";
            
            this.msgEventTypeLabel.AutoSize = true;
            this.msgEventTypeLabel.Location = new System.Drawing.Point(6, 136);
            this.msgEventTypeLabel.Name = "msgEventTypeLabel";
            this.msgEventTypeLabel.Size = new System.Drawing.Size(69, 12);
            this.msgEventTypeLabel.TabIndex = 14;
            this.msgEventTypeLabel.Text = "이벤트 유형";

            this.dynamicLocVariantLabel.AutoSize = true;
            this.dynamicLocVariantLabel.Location = new System.Drawing.Point(6, 103);
            this.dynamicLocVariantLabel.Name = "dynamicLocVariantLabel";
            this.dynamicLocVariantLabel.Size = new System.Drawing.Size(101, 12);
            this.dynamicLocVariantLabel.TabIndex = 13;
            this.dynamicLocVariantLabel.Text = "동적 위치 변동 값";
            
            this.autoRunTimeLabel.AutoSize = true;
            this.autoRunTimeLabel.Location = new System.Drawing.Point(287, 26);
            this.autoRunTimeLabel.Name = "autoRunTimeLabel";
            this.autoRunTimeLabel.Size = new System.Drawing.Size(83, 12);
            this.autoRunTimeLabel.TabIndex = 18;
            this.autoRunTimeLabel.Text = "실행 주기 (초)";
            this.autoRunTimeLabel.Click += new System.EventHandler(this.label20_Click);
         
            /*************************************************************
             *         Message publish configuration input fields        *
             *************************************************************/
            this.msgPerSecondInputF.Location = new System.Drawing.Point(163, 23);
            this.msgPerSecondInputF.Name = "msgPerSecondInputF";
            this.msgPerSecondInputF.Size = new System.Drawing.Size(111, 21);
            this.msgPerSecondInputF.TabIndex = 9;
            
            this.msgDelayTimeInputF.Location = new System.Drawing.Point(163, 57);
            this.msgDelayTimeInputF.Name = "msgDelayTimeInputF";
            this.msgDelayTimeInputF.Size = new System.Drawing.Size(111, 21);
            this.msgDelayTimeInputF.TabIndex = 16;

            this.locationVariantInputF.Location = new System.Drawing.Point(163, 94);
            this.locationVariantInputF.Name = "locationVariantInputF";
            this.locationVariantInputF.Size = new System.Drawing.Size(111, 21);
            this.locationVariantInputF.TabIndex = 10;
            
            this.eventTypeInputF.Location = new System.Drawing.Point(163, 133);
            this.eventTypeInputF.Name = "eventTypeInputF";
            this.eventTypeInputF.Size = new System.Drawing.Size(111, 21);
            this.eventTypeInputF.TabIndex = 11;
            
            this.autoSendDurationInputF.Location = new System.Drawing.Point(376, 20);
            this.autoSendDurationInputF.Name = "autoSendDurationInputF";
            this.autoSendDurationInputF.Size = new System.Drawing.Size(111, 21);
            this.autoSendDurationInputF.TabIndex = 19;
            
            /**************************************************************
             *                        CONNECT TAB PAGE                     *
             **************************************************************/
            this.mqttConnectTabPage.Controls.Add(this.mqttScurityInfoGroup);
            this.mqttConnectTabPage.Controls.Add(this.mqttBasicInfoGroupBox);
            this.mqttConnectTabPage.Location = new System.Drawing.Point(4, 22);
            this.mqttConnectTabPage.Name = "mqttConnectTabPage";
            this.mqttConnectTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mqttConnectTabPage.Size = new System.Drawing.Size(768, 353);
            this.mqttConnectTabPage.TabIndex = 1;
            this.mqttConnectTabPage.Text = "접속 설정";
            this.mqttConnectTabPage.UseVisualStyleBackColor = true;
            
            
            /**************************************************************
             *                    MQTT BASIC INFO GROUP                   *
             **************************************************************/

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
            
            /**************************************************************
             *                    MQTT BASIC INFO labels                   *
             **************************************************************/
            
            this.mqttBrokerIpLabel.AutoSize = true;
            this.mqttBrokerIpLabel.Location = new System.Drawing.Point(6, 26);
            this.mqttBrokerIpLabel.Name = "mqttBrokerIpLabel";
            this.mqttBrokerIpLabel.Size = new System.Drawing.Size(56, 12);
            this.mqttBrokerIpLabel.TabIndex = 12;
            this.mqttBrokerIpLabel.Text = "브로커 IP";
            
            this.mqttBrokerPortLabel.AutoSize = true;
            this.mqttBrokerPortLabel.Location = new System.Drawing.Point(6, 64);
            this.mqttBrokerPortLabel.Name = "mqttBrokerPortLabel";
            this.mqttBrokerPortLabel.Size = new System.Drawing.Size(78, 12);
            this.mqttBrokerPortLabel.TabIndex = 13;
            this.mqttBrokerPortLabel.Text = "브로커 PORT";
            
            this.mqttTopicLabel.AutoSize = true;
            this.mqttTopicLabel.Location = new System.Drawing.Point(6, 100);
            this.mqttTopicLabel.Name = "mqttTopicLabel";
            this.mqttTopicLabel.Size = new System.Drawing.Size(69, 12);
            this.mqttTopicLabel.TabIndex = 14;
            this.mqttTopicLabel.Text = "MQTT 토픽";
            
            this.mqttClientNameLabel.AutoSize = true;
            this.mqttClientNameLabel.Location = new System.Drawing.Point(6, 133);
            this.mqttClientNameLabel.Name = "mqttClientNameLabel";
            this.mqttClientNameLabel.Size = new System.Drawing.Size(93, 12);
            this.mqttClientNameLabel.TabIndex = 16;
            this.mqttClientNameLabel.Text = "클라이언트 이름";
            
            /**************************************************************
             *                 MQTT BASIC INFO input fields               *
             **************************************************************/
            
            //ip
            this.mqttIpInputF.Location = new System.Drawing.Point(109, 23);
            this.mqttIpInputF.Name = "mqttIpInputF";
            this.mqttIpInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttIpInputF.TabIndex = 9;
            this.mqttIpInputF.TextChanged += new System.EventHandler(this.mqttIpInputF_TextChanged);
            
            //port
            this.mqttPortInputF.Location = new System.Drawing.Point(109, 61);
            this.mqttPortInputF.Name = "mqttPortInputF";
            this.mqttPortInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttPortInputF.TabIndex = 10;
            this.mqttPortInputF.TextChanged += new System.EventHandler(this.mqttPortInputF_TextChanged);
            
            //topic
            this.mqttTopicInputF.Location = new System.Drawing.Point(109, 97);
            this.mqttTopicInputF.Name = "mqttTopicInputF";
            this.mqttTopicInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttTopicInputF.TabIndex = 11;
            this.mqttTopicInputF.TextChanged += new System.EventHandler(this.mqttTopicInputF_TextChanged);
            
            //client Id
            this.mqttClientIdF.Location = new System.Drawing.Point(109, 130);
            this.mqttClientIdF.Name = "mqttClientIdF";
            this.mqttClientIdF.Size = new System.Drawing.Size(111, 21);
            this.mqttClientIdF.TabIndex = 17;
            this.mqttClientIdF.TextChanged += new System.EventHandler(this.mqttClientIdF_TextChanged);
            
            
            /**************************************************************
             *                      Conn Test Button                      *
             **************************************************************/

            this.connectionTestBtn1.Font = new System.Drawing.Font("굴림", 7F);
            this.connectionTestBtn1.Location = new System.Drawing.Point(242, 152);
            this.connectionTestBtn1.Name = "connectionTestBtn1";
            this.connectionTestBtn1.Size = new System.Drawing.Size(66, 18);
            this.connectionTestBtn1.TabIndex = 15;
            this.connectionTestBtn1.Text = "접속 테스트";
            this.connectionTestBtn1.UseVisualStyleBackColor = true;
            this.connectionTestBtn1.Click += new System.EventHandler(this.connectionTestBtn1_Click);
            
            /**************************************************************
             *                    MQTT Security INFO GROUP                   *
             **************************************************************/
            this.mqttScurityInfoGroup.Controls.Add(this.isCredentialEnabledCheckbox);
            this.mqttScurityInfoGroup.Controls.Add(this.isSSLConnectCheckBox);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttPassLabel);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttUserNameLabel);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttPassInputF);
            this.mqttScurityInfoGroup.Controls.Add(this.mqttUserNameInputF);
            this.mqttScurityInfoGroup.Location = new System.Drawing.Point(347, 19);
            this.mqttScurityInfoGroup.Name = "mqttScurityInfoGroup";
            this.mqttScurityInfoGroup.Size = new System.Drawing.Size(314, 176);
            this.mqttScurityInfoGroup.TabIndex = 20;
            this.mqttScurityInfoGroup.TabStop = false;
            this.mqttScurityInfoGroup.Text = "보안 정보 입력 (선택)";

            /**************************************************************
             *                MQTT security info checkboxes               *
             **************************************************************/
            
            this.isSSLConnectCheckBox.AutoSize = true;
            this.isSSLConnectCheckBox.Location = new System.Drawing.Point(108, 28);
            this.isSSLConnectCheckBox.Name = "isSSLConnectCheckBox";
            this.isSSLConnectCheckBox.Size = new System.Drawing.Size(75, 16);
            this.isSSLConnectCheckBox.TabIndex = 16;
            this.isSSLConnectCheckBox.Text = "SSL 연결";
            this.isSSLConnectCheckBox.UseVisualStyleBackColor = true;
            this.isSSLConnectCheckBox.CheckedChanged += new System.EventHandler(this.isSSLConnectCheckBox_CheckedChanged);
            
            this.isCredentialEnabledCheckbox.AutoSize = true;
            this.isCredentialEnabledCheckbox.Location = new System.Drawing.Point(109, 64);
            this.isCredentialEnabledCheckbox.Name = "isCredentialEnabledCheckbox";
            this.isCredentialEnabledCheckbox.Size = new System.Drawing.Size(76, 16);
            this.isCredentialEnabledCheckbox.TabIndex = 17;
            this.isCredentialEnabledCheckbox.Text = "암호 허용";
            this.isCredentialEnabledCheckbox.UseVisualStyleBackColor = true;
            this.isCredentialEnabledCheckbox.CheckedChanged += new System.EventHandler(this.isCredentialEnabledCheckBox_CheckedChange);
            
            /**************************************************************
             *                   MQTT security info labels                *
             **************************************************************/
            this.mqttUserNameLabel.AutoSize = true;
            this.mqttUserNameLabel.Location = new System.Drawing.Point(6, 103);
            this.mqttUserNameLabel.Name = "mqttUserNameLabel";
            this.mqttUserNameLabel.Size = new System.Drawing.Size(69, 12);
            this.mqttUserNameLabel.TabIndex = 13;
            this.mqttUserNameLabel.Text = "사용자 이름";
            
            this.mqttPassLabel.AutoSize = true;
            this.mqttPassLabel.Location = new System.Drawing.Point(6, 139);
            this.mqttPassLabel.Name = "mqttPassLabel";
            this.mqttPassLabel.Size = new System.Drawing.Size(53, 12);
            this.mqttPassLabel.TabIndex = 14;
            this.mqttPassLabel.Text = "비밀번호";

            /**************************************************************
             *               MQTT security info input fields              *
             **************************************************************/
            this.mqttUserNameInputF.Location = new System.Drawing.Point(109, 100);
            this.mqttUserNameInputF.Name = "mqttUserNameInputF";
            this.mqttUserNameInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttUserNameInputF.TabIndex = 10;
            this.mqttUserNameInputF.TextChanged += new System.EventHandler(this.mqttUserNameInputF_TextChanged);
            
            this.mqttPassInputF.Location = new System.Drawing.Point(109, 136);
            this.mqttPassInputF.Name = "mqttPassInputF";
            this.mqttPassInputF.Size = new System.Drawing.Size(111, 21);
            this.mqttPassInputF.TabIndex = 11;
            this.mqttPassInputF.TextChanged += new System.EventHandler(this.mqttPassInputF_TextChanged);


         
            /**************************************************************
             *                        Progress Bar                        *
             **************************************************************/
            this.progressBar1.Location = new System.Drawing.Point(16, 408);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 21);
            this.progressBar1.TabIndex = 5;
            

        }

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
        private System.Windows.Forms.GroupBox maxCoordGroupBox;
        private System.Windows.Forms.Label maxCoordLabelZ;
        private System.Windows.Forms.Label maxCoordLabelY;
        private System.Windows.Forms.Label maxCoordLabelX;
        private System.Windows.Forms.TextBox maxZValInputF;
        private System.Windows.Forms.TextBox maxYValInputF;
        private System.Windows.Forms.TextBox maxXValInputF;
        private System.Windows.Forms.GroupBox minCoordGroupBox;
        private System.Windows.Forms.Label mingCoordLabelZ;
        private System.Windows.Forms.Label minCoordLabelY;
        private System.Windows.Forms.Label minXCoordLabelX;
        private System.Windows.Forms.TextBox minZValInputF;
        private System.Windows.Forms.TextBox minYValInputF;
        private System.Windows.Forms.TextBox minXValInputF;
        private System.Windows.Forms.GroupBox additionalDetailGroupBox;
        private System.Windows.Forms.Label msgEventTypeLabel;
        private System.Windows.Forms.Label dynamicLocVariantLabel;
        private System.Windows.Forms.Label msgPerSecGenerateLabel;
        private System.Windows.Forms.TextBox eventTypeInputF;
        private System.Windows.Forms.TextBox locationVariantInputF;
        private System.Windows.Forms.TextBox msgPerSecondInputF;
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
        private System.Windows.Forms.Label autoRunTimeLabel;
        private System.Windows.Forms.TextBox autoSendDurationInputF;
        private System.Windows.Forms.TextBox mqttClientIdF;
        private System.Windows.Forms.Label mqttClientNameLabel;
    }
}

