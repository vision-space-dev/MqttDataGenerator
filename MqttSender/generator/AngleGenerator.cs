using System;
using MqttSender.model;

namespace MqttSender.util
{
    public class AngleGenerator
    {
        //Calculates angle based on current position from previous position
        public static double CalculateAngleStartPivot(Position startPos, Position currentPos)
        {
            double x = startPos.X - currentPos.X;
            double y = startPos.Y - currentPos.Y;
            
            double angleInRadians = Math.Atan2(y, x);
            double angleInDegrees = angleInRadians * (180 / Math.PI);
            return Math.Round(angleInDegrees, 2);
        }

        //Calculates angle based on current position to target position
        public static double CalculateAngleEndPivot(Position currentPos, Position targetPos)
        {
            double x = currentPos.X - targetPos.X;
            double y = currentPos.Y - targetPos.Y;

            double angleInRadians = Math.Atan2(y, x);
            double angleInDegrees = angleInRadians * (180 / Math.PI);
            return Math.Round(angleInDegrees, 2);
        }
    }
}