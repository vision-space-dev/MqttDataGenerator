using System;
using System.Collections.Generic;
using System.Threading;
using MqttSender.generator;
using MqttSender.model;

namespace MqttSender.manager
{
    /**
     * Manages all tasks from a single robot
     *
     * Feature 1: based on the series of task from a robot,
     *  tracts which task is completed or which task should be taken next.
     *
     * - This should maintain the order of the queue
     * - This should me only used when user attempts to publish messages based on the given robot tasks
     * Todo: handle all types of robots - use Robot type
     * 
     */
    public class TaskManager
    {
        private AmrRobot Robot;
        private Queue<RobotTask> RobotTaskQueue;
        private RobotTask CurrentRobotTask;
        private int CurrentTaskTimeInMilliseconds = 0;
        private int TotalTaskTimeInMilliseconds = 0;
        private int CurrentProcessedTimeInMilliseconds = 0;
        private int DelayTimeMilli;

        public TaskManager(AmrRobot robot, int delayTimeInMilliSeconds)
        {
            Robot = robot ?? throw new ArgumentNullException(nameof(robot), "amrRobot cannot be null.");
            RobotTaskQueue = new Queue<RobotTask>();

            // Enqueue robot tasks and calculate time
            foreach (var robotTask in robot.GetRobotTasks())
            {
                if (robotTask != null)
                {
                    RobotTaskQueue.Enqueue(robotTask);
                    TotalTaskTimeInMilliseconds += (robotTask.IdleTimeInSeconds * 1000) +
                                                   (robotTask.MoveTimeInSeconds * 1000);
                }
                else
                {
                    Console.WriteLine("Error: RobotTask is null");
                }
            }

            // Calculate delay time between message ticks based on user configuration
            if (delayTimeInMilliSeconds > 0)
            {
                DelayTimeMilli = delayTimeInMilliSeconds;
            }
            else
            {
                throw new ArgumentException("Amount of messages per second must be greater than 0.");
            }
        }

        // Lock object for thread safety
        
        public void FlushTasks()
        {
            RobotTaskQueue.Clear();
        }
        
        public int GetTotalTaskTimeInMilliseconds()
        {
            return TotalTaskTimeInMilliseconds;
        }

        public int GetCurrentTaskTimeInMilliseconds()
        {
            return CurrentTaskTimeInMilliseconds;
        }

        public int GetCurrentTimeInMilliseconds()
        {
            return CurrentProcessedTimeInMilliseconds;
        }

        public AmrRobot GetRobot()
        {
            return Robot;
        }

        // Processes tasks and generates messages
        public RobotData ProcessTask()
        {
            // Check for task completion
            if (TaskCompleted())
            {
                Console.WriteLine($"All tasks for robot: {Robot.GetRobotSid()} are completed.");
                return null;
            }

            // Initialize the next task if necessary
            if (CurrentRobotTask == null)
            {
                CurrentRobotTask = RobotTaskQueue.Dequeue();
                CurrentTaskTimeInMilliseconds = (CurrentRobotTask.IdleTimeInSeconds * 1000)
                                                + (CurrentRobotTask.MoveTimeInSeconds * 1000);
                CurrentProcessedTimeInMilliseconds = 0; // Reset processed time
                Console.WriteLine($"Starting new task for robot: {Robot.GetRobotSid()}");
            }
            
            CurrentProcessedTimeInMilliseconds += DelayTimeMilli;

            // Check if the task has completed
            if (CurrentProcessedTimeInMilliseconds >= CurrentTaskTimeInMilliseconds)
            {
                Console.WriteLine($"Completed task for robot: {Robot.GetRobotSid()}");

                CurrentRobotTask = null; // Mark the task as completed
                if (RobotTaskQueue.Count == 0)
                {
                    return null; // No tasks remaining
                }
            }

            if (CurrentRobotTask == null)
            {
                Console.WriteLine("Error: RobotTask is null");
                return null;
            }

            bool isIdle = CurrentProcessedTimeInMilliseconds >= CurrentRobotTask.MoveTimeInSeconds * 1000;
            
            // Simulate message generation for the current tick
            return RobotDataGenerator.GenerateRobotData(Robot, CurrentRobotTask, CurrentRobotTask.MoveTimeInSeconds * 1000, CurrentProcessedTimeInMilliseconds, isIdle);
        }
        
        //Task is concidered completed when queue is empty and current Process is done (current process duration matches the total duration)
        public bool TaskCompleted()
        {
            if (RobotTaskQueue.Count == 0 && CurrentTaskTimeInMilliseconds <= CurrentProcessedTimeInMilliseconds)
            {
                return true;
            }

            return false;
        }
    }
}