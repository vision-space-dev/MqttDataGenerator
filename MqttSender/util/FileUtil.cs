using System;
using System.IO;

namespace MqttSender.util
{
    
    public class FileUtil
    {
        private const string DEFAULT_FILE_PATH = "../../data/REGISTER_NEW_ROBOT.json";
        
        public static string GetFilePath(string userFilePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath;
            if (string.IsNullOrEmpty(userFilePath))
            {
                filePath = Path.Combine(baseDirectory, @DEFAULT_FILE_PATH);
            }
            else
            {
                filePath = userFilePath;
            }
            
            filePath = Path.Combine(baseDirectory, filePath);
            return Path.GetFullPath(filePath);   
        }
    }
}