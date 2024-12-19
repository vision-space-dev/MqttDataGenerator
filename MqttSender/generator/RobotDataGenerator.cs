using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MqttSender.model;
using Newtonsoft.Json;
using static Newtonsoft.Json.Formatting;

namespace MqttSender.generator
{
    public class RobotDataGenerator
    {

        Queue<RobotTask> robotTaskQueue;
        private RobotTask currentTask;
        List<RobotTask> tasks;
        private float currentTaskTimeInMilli = 0;

        public RobotDataGenerator(Queue<RobotTask> robotTaskQueue)
        {
            if (robotTaskQueue == null || robotTaskQueue.Count == 0)
            {
                this.tasks = new List<RobotTask>();
                this.robotTaskQueue = null;
                this.currentTask = null;
            }
            else
            {
                this.robotTaskQueue = robotTaskQueue;
                this.tasks = robotTaskQueue.ToList();
                this.currentTask = this.robotTaskQueue.Dequeue();
                Console.WriteLine("Deuqueu the first task. Remaining tasks count=" + robotTaskQueue.Count);
                this.currentTask.Status = "in_progress";
            }
        }
        
        public Position GeneratePositionMoving(RobotTask task, float currentTaskMillis)
        {
            // Convert movingTime from seconds to milliseconds for accurate calculations
            float totalMoveTimeMilli = task.moveTimeSeconds * 1000;

            // Validate inputs
            if (task.moveTimeSeconds < 0 || currentTaskMillis > totalMoveTimeMilli)
            {
                throw new ArgumentException("Invalid moving time or current tick. currentTaskMillis=" + currentTaskMillis + ". totalMoveTimeMilli= " + totalMoveTimeMilli);
            }

            // Compute the fractional time progressed
            // Fraction represents the percentage of time elapsed out of the total moving time
            double fraction;
            if (totalMoveTimeMilli == 0)
            {
                fraction = 0; // No moving time means no movement occurs
            }
            else
            {
                fraction = currentTaskMillis / totalMoveTimeMilli;
                //Console.WriteLine($"currentTaskMillis={currentTaskMillis}, totalMoveTimeMilli={totalMoveTimeMilli}, fraction={fraction}");
                //Console.WriteLine($"(task.TargetLocation.X - task.Origin.X)={(task.TargetLocation.X - task.Origin.X)}");
            }

            // Ensure fraction value is clamped between 0 and 1
            fraction = Math.Max(0, Math.Min(fraction, 1));

            // Interpolate each coordinate linearly using the computed fraction
            double transitiveX = Math.Round(task.Origin.X + (task.TargetLocation.X - task.Origin.X) * fraction, 4);
            double transitiveY = Math.Round(task.Origin.Y + (task.TargetLocation.Y - task.Origin.Y) * fraction, 4);
            double transitiveZ = Math.Round(task.Origin.Z + (task.TargetLocation.Z - task.Origin.Z) * fraction, 4);

            // Return the interpolated position
            return new Position
            {
                X = transitiveX,
                Y = transitiveY,
                Z = transitiveZ,
                Orientation = 0, // Assuming starting orientation
                Timestamp = DateTime.Now // Attach the current timestamp
            };
        }
        
        public Position GeneratePositionWorking(Position lastPosition)
        {

            // Interpolating each coordinate linearly
            double transitiveX = lastPosition.X;
            double transitiveY = lastPosition.Y;
            double transitiveZ = lastPosition.Z;
            
            return new Position
            {
                X = transitiveX,
                Y = transitiveY,
                Z = transitiveZ,
                Orientation = 0, // Assuming starting orientation
                Timestamp = DateTime.Now
            };
        }
        
        //generate robot data based on current tick, when current task is completed, dequeue the next task an use it as current task
        public string GenerateRobotDataJson(List<AMRRobotInputObject> amrInputObjects, int delayTimeMilli)
        {
            
            //Calculate current tick to reset based on actualCurrent Tick == total tick
            var robotDataCollection = new RobotDataCollection
            {
                RobotData = new List<RobotEvent>()
            };

            foreach (var amrInput in amrInputObjects)
            {
                Position position;
                if (currentTask == null)
                {
                    Console.WriteLine("curent task is null");
                    return null;
                }
                else
                {
                    int currentTaskTotalTimeMilli = (currentTask.moveTimeSeconds + currentTask.workTimeSeconds) * 1000;
                    Console.WriteLine($"currentTaskTotalTimeMilli= {currentTaskTotalTimeMilli}, " +
                                      $"delayTimeMilli = {delayTimeMilli}, currentTaskTimeInMilli = {currentTaskTimeInMilli}, " +
                                      $"currentTaskTotalTimeMilli={currentTaskTotalTimeMilli}, robotTaskQueue.Count={robotTaskQueue.Count}," +
                                      $" currentTask={currentTask.TaskId}");
                    
                    //Next task
                    //if current tick matches the currentTask's moving plus working time, then dequeue to the next task
                    if (currentTaskTimeInMilli >= currentTaskTotalTimeMilli && currentTask != null)
                    {
                        foreach (var robotTask in tasks)
                        {
                            //Set previous task to complete
                            if (robotTask.TaskId == currentTask.TaskId)
                            {
                                robotTask.Status = "completed";
                            }
                        }

                        if (robotTaskQueue.Count > 0)
                        {
                            currentTaskTimeInMilli = 0;
                            position = GeneratePositionMoving(currentTask, currentTaskTimeInMilli);
                            currentTask = robotTaskQueue.Dequeue();
                            currentTask.Status = "in_progress";
                            Console.WriteLine($"Taking the next task. Generated moving position: {position.ToString()}");
                        }
                        else
                        {
                            currentTask = null;
                            return null;
                        }
                    }
                    //when moving
                    else if (currentTaskTimeInMilli < currentTask.moveTimeSeconds * 1000)
                    {
                        Console.WriteLine("Moving position");
                        position = GeneratePositionMoving(currentTask, currentTaskTimeInMilli);
                        Console.WriteLine($"Generated moving position: {position.ToString()}");
                    }
                    //when working
                    else if (currentTaskTimeInMilli >= currentTask.workTimeSeconds * 1000 && currentTaskTimeInMilli < currentTaskTotalTimeMilli)
                    {
                        Console.WriteLine("Working position");
                        position = GeneratePositionWorking(currentTask.TargetLocation);
                        Console.WriteLine($"Generated working position: {position.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Logic error");
                        throw new Exception();
                    }
                }
                
                
                var robotData = new RobotData
                {
                    RobotId = amrInput.RobotSid,
                    Status = "active", // Example status
                    RobotType = "AMR_ROBOT", // Assuming AMR for all
                    RobotModel = amrInput.RobotModelName,
                    Position = position,
                    Battery = new Battery // Example Battery data
                    {
                        Level = 80.0,
                        Charging = false,
                        Voltage = 24.0,
                        Current = 5.0,
                        Temperature = 35.0,
                        Health = "Good"
                    },
                    Tasks = tasks, // Can add tasks if needed
                };

                var robotEvent = new RobotEvent
                {
                    EventType = amrInput.EventType,
                    RobotData = robotData
                };

                robotDataCollection.RobotData.Add(robotEvent);
            }
            currentTaskTimeInMilli += delayTimeMilli;

            return JsonConvert.SerializeObject(robotDataCollection, Indented);
        }
    }
}