using System;
using System.Collections.Generic;
using System.Text;
using MqttSender.model;

namespace MqttSender.manager
{
    //Creates Robot object and handles list of robots
    //  - this will contain list of tasks
    // T - Robot
    public class RobotManager<T> : IRobotManager<T> where T : Robot
    {
        
        //string - robotSid, T - Robot object
        private Dictionary<string, T> robots = new Dictionary<string, T>();

        private bool RobotExists(string robotSid)
        {
            return robots.ContainsKey(robotSid);
        }

        public bool AddRobot(string robotSid, T robot)
        {
            if (RobotExists(robotSid))
            {
                return true;
            }
            robots.Add(robotSid, robot);
            return true;
        }

        public T GetRobot(string robotSid)
        {
            try
            {
                // Attempt to retrieve the robot from the dictionary
                return robots[robotSid];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public bool AddTask(string robotSid, RobotTask task)
        {
            T robot = GetRobot(robotSid);
            if (robot == null)
            {
                return false;
            }
            
            //This also checks duplicate task Sid
            return robot.AddTask(task);
        }

        public List<T> GetRobots()
        {
            return new List<T>(robots.Values);
        }

        public bool RemoveRobot(string robotSid)
        {
            return robots.Remove(robotSid);
        }

        public bool RemoveTask(string robotSid, string taskSid)
        {
            T robot = robots[robotSid];
            return robot.RemoveTask(taskSid);
        }
        
        public override string ToString()
        {
            if (robots.Count == 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RobotManager currently managing the following robots:");

            foreach (var kvp in robots)
            {
                string robotSid = kvp.Key;
                T robot = kvp.Value;

                sb.AppendLine($"Robot SID: {robotSid}");
                sb.AppendLine(robot.ToString());
                sb.AppendLine(new string('-', 50)); // Separator for better formatting
            }

            return sb.ToString();
        }
        
    }
}