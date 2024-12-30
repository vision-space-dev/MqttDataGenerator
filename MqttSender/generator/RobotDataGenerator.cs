using System;
using System.Collections.Generic;
using MqttSender.model;
using MqttSender.util;

namespace MqttSender.generator
{
    
    public class RobotDataGenerator
    {

        public RobotDataGenerator(Queue<RobotTask> robotTaskQueue)
        {

        }
        
        //Todo: accept various robot types
        //Generate robot messages by the number of robots
        public static RobotData GenerateRobotData(AmrRobot amrRobot, RobotTask currentTask, 
            int workingTimeInMilli, int currentTimeInMillis, bool isIdle)
        {
            // Validate amrRobot
            if (amrRobot == null)
            {
                throw new ArgumentNullException(nameof(amrRobot), "amrRobot cannot be null.");
            }
   
            // Validate currentTask
            if (currentTask == null)
            {
                throw new ArgumentNullException(nameof(currentTask), "currentTask cannot be null.");
            }
            
            // Get start and end positions with validation
            Position startPosition = currentTask.Origin;
            if (startPosition == null)
            {
                throw new InvalidOperationException("GetOriginPosition returned null.");
            }
   
            Position endPosition = currentTask.TargetLocation;
            if (endPosition == null)
            {
                throw new InvalidOperationException("TargetLocation is null in currentTask.");
            }
            
            // Initialize the current position
            Position currentPosition;
            //Produce current location as endPosition
            if (isIdle)
            {
                currentPosition = endPosition;
                currentPosition.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
            else //calculate position based on the (end point - start point)
            {
                // Calculate progress ratio (current time over total working time)
                double progress;
                if (workingTimeInMilli == 0)
                {
                    progress = 1;
                }
                else
                {
                    progress = Math.Min((double)currentTimeInMillis / workingTimeInMilli, 1.0);
                }
                // Interpolate the current position based on the progress ratio
                double currentX = startPosition.X + progress * (endPosition.X - startPosition.X);
                double currentY = startPosition.Y + progress * (endPosition.Y - startPosition.Y);
                double currentZ = 0;
                
                currentPosition = new Position
                {
                    X = currentX,
                    Y = currentY,
                    Z = currentZ
                };
                currentPosition.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
            
            double orientation = AngleGenerator.CalculateAngleEndPivot(currentPosition, endPosition);
            currentPosition.Orientation = orientation;
            
            //initialize location
            Location location = new Location();
            if (amrRobot.GetLocationId() != null)
            {
                location.locationSid = amrRobot.GetLocationId();
                if (amrRobot.GetFacilityId() != null)
                {
                    Location.Facility facility = new Location.Facility();
                    facility.facilitySid = amrRobot.GetFacilityId();
                    location.facility = facility;
                }
            }
            
            // Log the robot data to the console or debug output
            RobotData robotData = new RobotData
            {
                RobotId = amrRobot.GetRobotSid(),
                Status = "in_progress",
                RobotType = "AMR_ROBOT",
                RobotModel = amrRobot.GetRobotModelName(),
                Position = currentPosition,
                Tasks = new List<RobotTask> { currentTask },
                Location = location
            };

            
            return robotData;
        }
        
    }
}