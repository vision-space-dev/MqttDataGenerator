using System;

namespace MqttSender.model
{
    public class RobotTask
    {
        public string TaskId { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public string Status { get; set; }
        public Position Origin { get; set; }
        public Position TargetLocation { get; set; }
        public Payload Payload { get; set; }
        
        public RobotTask() {
            this.Priority = MsgPriority.REGULAR_MESSAGE;
            this.Status = "pending";
        }
    }
}