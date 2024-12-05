using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MqttSender.service;

namespace MqttSender
{
    public partial class Form1 : Form
    {
        private string _mqttIp = "localhost";
        private string _mqttPort = "1884";
        private string _mqttTopic = "vss-topic-test";
        private string _clientId = "test-client";
        private bool _isSslEnabled = false;
        private bool _iSCredentialEnabled = false;
        
        private void InitializeFields()
        {
            this.mqttIpInputF.Text = _mqttIp;
            this.mqttPortInputF.Text = _mqttPort;
            this.mqttTopicInputF.Text = _mqttTopic;
            this.mqttClientIdF.Text = _clientId;
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
            _mqttTopic = mqttTopicInputF.Text;
        }

        private void mqttPortInputF_TextChanged(object sender, EventArgs e)
        {
            _mqttPort = mqttPortInputF.Text;
        }
        
        private void mqttIpInputF_TextChanged(object sender, EventArgs e)
        {
            _mqttIp = mqttIpInputF.Text;
        }

        private void mqttClientIdF_TextChanged(object sender, EventArgs e)
        {
            _clientId = mqttClientIdF.Text;
        }

        private async void connectionTestBtn1_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

            MqttPublisher mqttPublisher = new MqttPublisher();
            bool useSSL = isSSLConnectCheckBox.Checked;

            try
            {
                if (useSSL)
                {
                    await mqttPublisher.ConnectAsync(_mqttIp, int.Parse(_mqttPort), _clientId, useSSL);   
                }
                await mqttPublisher.SendMessageAsync(_mqttTopic, "Test message from C#");

                // Stop the marquee animation
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = progressBar1.Maximum;

                MessageBox.Show("Connected to MQTT broker and sent a test message successfully!");
            }
            catch (Exception ex)
            {
                // Stop assigning value to progress manually as failed
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;

                MessageBox.Show($"Failed to connect to MQTT broker: {ex.Message}");
            }
            finally
            {
                // Ensure progress bar stops animation regardless of success/failure
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 0;
            }
        }
    }
}
