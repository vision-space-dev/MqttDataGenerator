using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MqttSender.model;

namespace MqttSender.service
{
    public class TaskHandler
    {
        private List<RobotTask> taskList;
        private Queue<RobotTask> taskQueue;
        private int totalTaskDuration = 0;

        public TaskHandler()
        {
            taskQueue = new Queue<RobotTask>();
            taskList = new List<RobotTask>();
        }

        // Enqueue all tasks from a list maintaining the order
        public void EnqueueAll()
        {
            if (taskList == null || taskList.Count == 0)
            {
                MessageBox.Show("작업 큐 없이 설정 합니다.");
                return;
            }

            totalTaskDuration = 0;
            foreach (var task in taskList)
            {
                totalTaskDuration += (task.workTimeSeconds + task.moveTimeSeconds);
                taskQueue.Enqueue(task);
            }
        }

        public void DequeueTask()
        {
            taskQueue.Dequeue();
        }

        public void DequeueAllTask()
        {
            while (taskQueue.Count > 0)
            {
                taskQueue.Dequeue();
            }
        }

        public Queue<RobotTask> getTaskQueue()
        {
            return taskQueue;
        }
        
        // returns true if it's a valid add, returns false when taskId exists
        public bool AddTask(RobotTask task)
        {
            foreach (var robotTask in taskList)
            {
                if (robotTask.TaskId == task.TaskId)
                {
                    return false;
                }
            }
            
            taskList.Add(task);
            return true;
        }

        public bool RemoveTask(string taskId)
        {
            foreach (var robotTask in taskList) 
            {
                if (robotTask.TaskId == taskId)
                {
                    taskList.Remove(robotTask);
                    Console.WriteLine("Removed: " + robotTask);
                    return true;
                }
            }

            return false;
        }

        public int getTotalTaskDurationInSeconds()
        {
            return totalTaskDuration;
        }
    }
}