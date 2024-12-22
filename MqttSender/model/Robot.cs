using System.Collections.Generic;

namespace MqttSender.model
{
    public class Robot : IRobot<RobotTask>
    {
        //Stores list of tasks in order
        private LinkedList<RobotTask> RobotTasks { get; }
        
        private string RobotSid { get; }
        private string RobotModelName { get; }
        private string RobotName { get; }

        protected Robot()
        {
            //For serialization purposes only
        }
        
        protected Robot(string robotSid,
            string robotModelName,
            string robotName)
        {
            this.RobotSid = robotModelName;
            this.RobotModelName = robotModelName;
            this.RobotName = robotName;
            RobotTasks = new LinkedList<RobotTask>();
        }

        public void AddTask(RobotTask robotTask)
        {
            RobotTasks.AddLast(robotTask);
        }

        //Worst time complexity of O(n)
        //returns true on successful removal, returns false on not found
        public bool RemoveTask(string taskSid)
        {
            var node = RobotTasks.First;
            while (node != null)
            {
                if (node.Value.TaskId == taskSid)
                {
                    RobotTasks.Remove(node);
                    return true;
                }
                node = node.Next;
            }

            return false;
        }
        
        public void RemoveTask(RobotTask robot)
        {
            RobotTasks.Remove(robot);
        }
        
        public LinkedList<RobotTask> GetRobotTasks()
        {
            return RobotTasks;
        }

        public LinkedList<RobotTask> GetRobotTasksCopy()
        {
            return new LinkedList<RobotTask>(RobotTasks);
        }

        public Queue<RobotTask> GetRobotTasksQueue()
        {
            return new Queue<RobotTask>(RobotTasks);
        }

        public string GetRobotSid()
        {
            return RobotSid;
        }

        public string GetRobotModelName()
        {
            return RobotModelName;
        }

        public string GetRobotName()
        {
            return RobotName;
        }
    }
}