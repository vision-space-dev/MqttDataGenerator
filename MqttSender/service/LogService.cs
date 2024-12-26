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
        }
    }
}