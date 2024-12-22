using System.Collections.Generic;
using MqttSender.model;

namespace MqttSender.manager
{
    //Creates Robot object and handles list of robots
    //  - this will contain list of tasks
    // T - Robot
    public class RobotManager<T> where T : Robot
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
            return robots[robotSid];
        }

        public bool AddTask(string robotSid, RobotTask task)
        {
            T robot = GetRobot(robotSid);
            if (robot == null)
            {
                return false;
            }
            
            robot.AddTask(task);
            return true;
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
    }
}