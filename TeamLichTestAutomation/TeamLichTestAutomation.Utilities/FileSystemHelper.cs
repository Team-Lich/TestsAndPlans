namespace TeamLichTestAutomation.Utilities
{
    using System;
    using System.IO;
    using System.Linq;

    public class FileSystemHelper
    {
        public static bool FilePresentInUserDownloadsDirectory(string fileName)
        {
            bool result;

            string userDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            var files = Directory.GetFiles(userDirectoryPath);

            result = files.Contains(userDirectoryPath + "\\" + fileName);

            return result;
        }

        public static string GetExpectedFileName(string prefix)
        {
            string fileNameFormat = "{0}_Export-{1}-{2}_{3}-";
            DateTime currentTime = DateTime.Now;

            int year = currentTime.Year;
            int month = currentTime.Month;
            int day = currentTime.Day;
            int hours = currentTime.Hour;

            return string.Format(fileNameFormat, prefix, year, month, year, day, hours);
        }
    }
}