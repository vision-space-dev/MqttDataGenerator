using System;
using System.Windows.Forms;
using MqttSender.model;

namespace MqttSender
{
    public partial class EditTaskForm : Form
    {
        private RobotTask _task;
        
        private void InitializeComponent()
        {
             // Initialize form components (textboxes, labels, etc.)
            this.Text = "Edit Task";
            this.Width = 400;
            this.Height = 300;

            Label originLabel = new Label
            {
                Text = "Origin Position",
                Left = 10,
                Top = 20,
                Width = 100
            };
            TextBox originTextBox = new TextBox
            {
                Text = _task.Origin.ToString(),
                Left = 120,
                Top = 20,
                Width = 200
            };

            Label targetLabel = new Label
            {
                Text = "Target Position",
                Left = 10,
                Top = 60,
                Width = 100
            };
            TextBox targetTextBox = new TextBox
            {
                Text = _task.TargetLocation.ToString(),
                Left = 120,
                Top = 60,
                Width = 200
            };

            Label moveTimeLabel = new Label
            {
                Text = "Move Time (s)",
                Left = 10,
                Top = 100,
                Width = 100
            };
            TextBox moveTimeTextBox = new TextBox
            {
                Text = _task.MoveTimeInSeconds.ToString(),
                Left = 120,
                Top = 100,
                Width = 200
            };

            Label idleTimeLabel = new Label
            {
                Text = "Idle Time (s)",
                Left = 10,
                Top = 140,
                Width = 100
            };
            TextBox idleTimeTextBox = new TextBox
            {
                Text = _task.IdleTimeInSeconds.ToString(),
                Left = 120,
                Top = 140,
                Width = 200
            };

            Button saveButton = new Button
            {
                Text = "Save",
                Left = 120,
                Top = 200,
                Width = 100
            };
            saveButton.Click += (sender, e) => SaveTask(originTextBox, targetTextBox, moveTimeTextBox, idleTimeTextBox);

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Left = 230,
                Top = 200,
                Width = 100
            };
            cancelButton.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(originLabel);
            this.Controls.Add(originTextBox);
            this.Controls.Add(targetLabel);
            this.Controls.Add(targetTextBox);
            this.Controls.Add(moveTimeLabel);
            this.Controls.Add(moveTimeTextBox);
            this.Controls.Add(idleTimeLabel);
            this.Controls.Add(idleTimeTextBox);
            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);
        }
        
        public EditTaskForm(RobotTask task)
        {
            _task = task;
            InitializeComponent();
        }
        
        private void SaveTask(TextBox originTextBox, TextBox targetTextBox, TextBox moveTimeTextBox, TextBox idleTimeTextBox)
        {
            try
            {
                // Validate and update the task's properties
                _task.Origin = ParsePosition(originTextBox.Text);
                _task.TargetLocation = ParsePosition(targetTextBox.Text);
                _task.MoveTimeInSeconds = int.Parse(moveTimeTextBox.Text);
                _task.IdleTimeInSeconds = int.Parse(idleTimeTextBox.Text);

                this.DialogResult = DialogResult.OK; // Indicate success
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Position ParsePosition(string position)
        {
            // Remove everything except numbers and commas
            var cleanedPosition = System.Text.RegularExpressions.Regex.Replace(position, "[^0-9,]", "");

            // Split the cleaned string into parts
            var parts = cleanedPosition.Split(',');

            if (parts.Length != 3) 
                throw new FormatException("Position must contain exactly three values.");

            return new Position
            {
                X = int.Parse(parts[0]),
                Y = int.Parse(parts[1]),
                Z = int.Parse(parts[2])
            };
        }
    }
}