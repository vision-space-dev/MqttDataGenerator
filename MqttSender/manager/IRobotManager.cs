using System.Collections.Generic;
using MqttSender.model;

namespace MqttSender.manager
{
    public interface IRobotManager<T> where T : Robot
    {
        List<T> GetRobots();
        T GetRobot(string robotSid);
    }
}