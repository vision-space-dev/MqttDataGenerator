﻿using System.Collections.Generic;

namespace MqttSender.model
{
    public interface IRobot<T>
    {
        void AddTask(T task);
        LinkedList<T> GetRobotTasks();
        LinkedList<T> GetRobotTasksCopy();
        
        string GetRobotSid();
        
        string GetRobotModelName();
        
        string GetRobotName();
    }
}