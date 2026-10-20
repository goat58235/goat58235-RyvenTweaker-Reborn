
using System;
using System.Management;
using System.Linq;

namespace RyvenTweaker.Services
{
    public sealed class HardwareDetector
    {
        public string GetProcessor()
        {
            return GetWmiValue(
                "Win32_Processor",
                "Name");
        }

        public string GetGraphicsCard()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT Name FROM Win32_VideoController");

                var names = searcher.Get()
                    .Cast<ManagementObject>()
                    .Select(item => item["Name"]?.ToString())
                    .Where(name => !string.IsNullOrWhiteSpace(name));

                return string.Join(", ", names);
            }
            catch
            {
                return "Unable to detect GPU";
            }
        }

        public string GetMemory()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");

                foreach (ManagementObject item in searcher.Get())
                {
                    if (item["TotalPhysicalMemory"] is ulong bytes)
                    {
                        double gb = bytes / 1073741824d;
                        return $"{gb:F0} GB installed";
                    }
                }
            }
            catch
            {
                return "Unable to detect RAM";
            }

            return "RAM information unavailable";
        }

        private static string GetWmiValue(
            string className,
            string propertyName)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $"SELECT {propertyName} FROM {className}");

                foreach (ManagementObject item in searcher.Get())
                {
                    return item[propertyName]?.ToString()
                        ?? "Information unavailable";
                }
            }
            catch
            {
                return "Unable to detect hardware";
            }

            return "Information unavailable";
        }
    }
}
