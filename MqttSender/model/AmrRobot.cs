using System;
using System.Collections.Generic;

namespace MqttSender.model
{
    public class AmrRobot : Robot
    {

        public AmrRobot()
        {
            
        }
        
        public AmrRobot(string robotSid,
            string robotModelName,
            string robotName) : base(robotSid, robotModelName, robotName)
        {
            //Todo: add AMR specific data
        }

        public override string ToString()
        {
            // Provide string representation of the AmrRobot
            return $"AmrRobot [SID={GetRobotSid()}, " +
                   $"ModelName={GetRobotModelName()}, " +
                   $"Name={GetRobotName()}, " +
                   $"Tasks({GetRobotTasksStr()})";
        }
        //Todo: implement validation checks - returns false on invalid input, returns true on valid input
    }
}