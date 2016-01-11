namespace TeamLichTestAutomation.Utilities
{
    using System;
    using System.IO;
    using System.Linq;

    public class FileSystemHelper
    {
        public static bool FilePresentInUserDownloadsDirectory(string expectedFileName, string expectedFileExtension)
        {
            bool result = false;

            string userDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            var files = Directory.GetFiles(userDirectoryPath);

            foreach (string filePath in files)
            {
                if (filePath.Contains(expectedFileName) && filePath.Contains("." + expectedFileExtension))
                {
                    result = true;
                }
            }

            return result;
        }

        public static string GetExpectedFileName(string prefix)
        {
            string fileNameFormat = "{0}_Export_{1}-{2:00}-{3:00}_{4:00}";
            DateTime currentTime = DateTime.Now;

            int year = currentTime.Year;
            int month = currentTime.Month;
            int day = currentTime.Day;
            int hours = currentTime.Hour;
            string result = string.Format(fileNameFormat, prefix, year, month, day, hours);

            return result;
        }
    }
}