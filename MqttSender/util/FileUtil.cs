using System;
using System.IO;

namespace MqttSender.util
{
    
    public class FileUtil
    {
        private const string DEFAULT_FILE_PATH = "../../data/REGISTER_NEW_ROBOT.json";
        
        public static string GetFilePath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, @DEFAULT_FILE_PATH);
            return Path.GetFullPath(filePath);
        }
    }
}