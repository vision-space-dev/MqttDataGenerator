using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MqttSender.model;
using Newtonsoft.Json;

namespace MqttSender.service
{
    public class LogService
    {
        public static void LogRobotDataToRichTextBox(RichTextBox richTextBox, RobotData robotData)
        {
            if (robotData == null)
            {
                Console.WriteLine("robotData is null, cannot log this result");
                return; 
            }
            List<RobotTask> robotTasks = robotData.Tasks;
            if (robotTasks == null && robotTasks.Count == 0)
            {
                Console.WriteLine("Invalid data, cannot log this result");
                return;
            }
            
            string robotSid = robotData.RobotId;
            Position startPosition = robotData.Position;
            RobotTask robotTask = robotTasks[0];
            string logContent = $"Timestamp: {startPosition.Timestamp} | Robot ID: {robotSid} | " +
                                $"Start Position: (X: {startPosition.X}, Y: {startPosition.Y}, Z: {startPosition.Z}) | " +
                                $"Target Position: (X: {robotTask.TargetLocation.X}, Y: {robotTask.TargetLocation.Y}, Z: {robotTask.TargetLocation.Z}) | " +
                                $"Status: {robotData.Status}";

            
            // Append the generated JSON to the RichTextBox
            richTextBox.AppendText(logContent + Environment.NewLine);
            
            // Ensure the RichTextBox scrolls to the bottom
            if (!richTextBox.Focused)
            {
                int visibleLines = richTextBox.Height / richTextBox.Font.Height; // Number of visible lines
                int totalLines = richTextBox.Lines.Length; // Total number of lines in the RichTextBox
                int firstVisibleLineIndex = richTextBox.GetLineFromCharIndex(
                    richTextBox.GetCharIndexFromPosition(new System.Drawing.Point(0, 0))
                ); // Index of the first visible line

                // Check if the last visible line is currently in view
                if (firstVisibleLineIndex + visibleLines >= totalLines - 1)
                {
                    // Move to and scroll to the bottom
                    richTextBox.SelectionStart = richTextBox.Text.Length;
                    richTextBox.ScrollToCaret();
                }
            }
        }
    }
}