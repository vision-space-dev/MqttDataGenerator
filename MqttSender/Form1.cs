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
using MqttSender.service;

namespace MqttSender
{
    public partial class Form1 : Form
    {
        private const string MQTT_DEFAULT_IP = "localhost";
        private const string MQTT_DEFAULT_PORT = "1884";
        private const string MQTT_DEFAULT_TOPIC = "vss-topic-test";
        private const string MQTT_DEFAULT_CLIENT_ID = "test-client";
        private const int DEFAULT_MSG_COUNT_PER_SECOND = 5;
        private const int DEFAULT_MSG_DELAY_TIME = 1;
        private const int DEFAULT_LOCATION_VARIANT_VALUE = 5;
        private const string DEFAULT_EVENT_TYPE = "REGISTER_NEW_ROBOT";
        private const int DEFAULT_AUTORUN_TIME = 60; //in seconds
        private const int DEFAUKT_Z_VALUE = 0;
        private const string DEFAULT_ROBOT_SIDE_VALUE = "TEST_SID";
        

        
        private void InitializeFields()
        {
            mqttIpInputF.Text = MQTT_DEFAULT_IP;
            mqttPortInputF.Text = MQTT_DEFAULT_PORT;
            mqttTopicInputF.Text = MQTT_DEFAULT_TOPIC;
            mqttClientIdF.Text = MQTT_DEFAULT_CLIENT_ID;
            msgPerSecondInputF.Text = DEFAULT_MSG_COUNT_PER_SECOND.ToString();
            msgDelayTimeInputF.Text = DEFAULT_MSG_DELAY_TIME.ToString();
            locationVariantInputF.Text = DEFAULT_LOCATION_VARIANT_VALUE.ToString();
            eventTypeInputF.Text = DEFAULT_EVENT_TYPE;
            autoSendDurationInputF.Text = DEFAULT_AUTORUN_TIME.ToString();
            maxZValInputF.Text = DEFAUKT_Z_VALUE.ToString();
            minZValInputF.Text = DEFAUKT_Z_VALUE.ToString();
            robotSidInputField.Text = DEFAULT_ROBOT_SIDE_VALUE;
            msgPerSecondInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            msgDelayTimeInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            locationVariantInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            msgPerSecondInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            autoSendDurationInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
            minXValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            minYValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            minZValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            maxXValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            maxYValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            maxZValInputF.KeyPress += inputF_AllowDoubleOnly_TextChanged;
            mqttPortInputF.KeyPress += inputF_AllowIntegerOnly_TextChanged;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
        

        private void robotSidInputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
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

                MessageBox.Show($"MQTT 브로커 접속 실패: {ex.Message}");
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
    }
}
