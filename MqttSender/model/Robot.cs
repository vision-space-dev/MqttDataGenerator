using System.Collections.Generic;
using System.Text;

namespace MqttSender.model
{
    public class Robot : IRobot<RobotTask>
    {
        //Stores list of tasks in order
        private LinkedList<RobotTask> RobotTasks { get; }
        //string - taskSid, RobotTask
        private Dictionary<string, RobotTask> RobotTasksDict { get; }
        
        private string RobotSid { get; }
        private string RobotModelName { get; }
        private string RobotName { get; }

        private string locationId = null;

        private string facilityId = null;

        protected Robot()
        {
            //For serialization purposes only
        }
        
        protected Robot(string robotSid,
            string robotModelName,
            string robotName)
        {
            this.RobotSid = robotSid;
            this.RobotModelName = robotModelName;
            this.RobotName = robotName;
            RobotTasks = new LinkedList<RobotTask>();
            RobotTasksDict = new Dictionary<string, RobotTask>();
        }

        public RobotTask GetTask(string taskSid)
        {
            return RobotTasksDict[taskSid];
        }
        
        public bool AddTask(RobotTask robotTask)
        {
            if (robotTask == null || robotTask.TaskId == null)
            {
                return false;
            }

            if (RobotTasksDict.ContainsKey(robotTask.TaskId))
            {
                return false;
            }
            
            RobotTasks.AddLast(robotTask);
            RobotTasksDict.Add(robotTask.TaskId, robotTask);
            return true;
        }

        //Worst time complexity of O(n)
        //returns true on successful removal, returns false on not found
        public bool RemoveTask(string taskSid)
        {
            if (taskSid == null)
            {
                return false;
            }

            
            var node = RobotTasks.First;
            while (node != null)
            {
                if (node.Value.TaskId == taskSid)
                {
                    RobotTasks.Remove(node);
                    RobotTasksDict.Remove(taskSid);
                    return true;
                }
                node = node.Next;
            }

            return false;
        }
        
        public void RemoveTask(RobotTask robotTask)
        {
            RobotTasks.Remove(robotTask);
            RobotTasksDict.Remove(robotTask.TaskId);
        }
        
        public LinkedList<RobotTask> GetRobotTasks()
        {
            return RobotTasks;
        }

        public RobotTask GetRobotTask(string taskSid)
        {
            return RobotTasksDict[taskSid];
        }

        public string GetRobotTasksStr()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n");
            foreach (var task in RobotTasks)
            {
                sb.AppendLine("\t");
                sb.AppendLine(task.ToString());
            }

            return sb.ToString();
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

        public string GetLocationId()
        {
            return this.locationId;
        }

        public void SetLocationId(string locationSId)
        {
            this.locationId = locationSId;
        }

        public string GetFacilityId()
        {
            return facilityId;
        }

        public void SetFacilityId(string facilitySId)
        {
            this.facilityId = facilitySId;
        }
    }
}