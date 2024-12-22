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

        public RobotDataGenerator(Queue<RobotTask> robotTaskQueue)
        {

        }
        
        public Position GeneratePositionMoving(RobotTask task, float currentTaskMillis)
        {
            return null;
        }
        
        public Position GeneratePositionWorking(Position lastPosition)
        {
            return null;
        }
        
        
        //Generate a single robot position data in json message 
        /*public string GenerateJsonRobotData(
            List<AMRRobot> amrInputObjects,
            int delayTimeMilli)
        {
            //Calculate current tick to reset based on actualCurrent Tick == total tick
            var robotDataCollection = new RobotDataCollection
            {
                RobotData = new List<RobotEvent>()
            };

            //For all robots
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

            }
            currentTaskTimeInMilli += delayTimeMilli;

            return JsonConvert.SerializeObject(robotDataCollection, Indented);
        }*/
    }
}