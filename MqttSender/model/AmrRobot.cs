using System;
using System.Collections.Generic;

namespace MqttSender.model
{
    public class AmrRobot : Robot
    {

        Position originPosition;
        
        public AmrRobot()
        {
            
        }
        
        public AmrRobot(string robotSid,
            string robotModelName,
            string robotName) : base(robotSid, robotModelName, robotName)
        {
            //Todo: add AMR specific data
        }

        
        public Position GetOriginPosition()
        {
            return originPosition;
        }
        
        public void SetOriginPosition(double x, double y, double z)
        {
            Position position = new Position();
            position.X = x;
            position.Y = y;
            position.Z = z;
            originPosition = position;
        }
        
        public void SetOriginPosition(Position position)
        {
            originPosition = position;
        }
        
        public override string ToString()
        {
            // Provide string representation of the AmrRobot
            return $"AmrRobot [SID={GetRobotSid()}, " +
                   $"ModelName={GetRobotModelName()}, " +
                   $"Name={GetRobotName()}, " +
                   $"Position=({originPosition?.X ?? 0}, {originPosition?.Y ?? 0}, {originPosition?.Z ?? 0})]" +
                   $"Tasks({GetRobotTasksStr()})";
        }
        //Todo: implement validation checks - returns false on invalid input, returns true on valid input
    }
}