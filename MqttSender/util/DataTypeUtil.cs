using System;

namespace MqttSender.util
{
    public class DataTypeUtil
    {
        public static float ParseStringToFloat(string input)
        {
            if (float.TryParse(input, out float result))
            {
                return (float)Math.Round(result, 4);
            }
            else
            {
                throw new InvalidOperationException("좌표 값을 넣어주세요");
            }
        }
        
        public static int ParseStringToInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException("메시지 기능 값을 넣어 주세요");
            }
        }
    }
}