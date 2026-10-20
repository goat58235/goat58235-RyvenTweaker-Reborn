using System.Management;
namespace RyvenTweaker.Services;
public sealed class HardwareDetector
{
    private static string Read(string cls,string property)
    {
        using var searcher=new ManagementObjectSearcher($"SELECT {property} FROM {cls}");
        foreach(ManagementObject item in searcher.Get()) return item[property]?.ToString() ?? "Unknown";
        return "Unknown";
    }
    public string GetProcessor()=>Read("Win32_Processor","Name");
    public string GetGraphicsCard()=>Read("Win32_VideoController","Name");
    public string GetMemory()=> $"{Math.Round(double.Parse(Read("Win32_ComputerSystem","TotalPhysicalMemory"))/1073741824d):0} GB RAM";
}
