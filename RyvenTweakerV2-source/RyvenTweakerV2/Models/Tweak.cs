namespace RyvenTweaker.Models;
public enum TweakRisk { Low, Medium, High }
public sealed class Tweak
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public string ExpectedBenefit { get; set; } = "";
    public TweakRisk Risk { get; set; } = TweakRisk.Low;
    public bool RequiresAdministrator { get; set; }
    public bool RequiresRestart { get; set; }
    public bool IsApplied { get; set; }
    public bool IsCompatible { get; set; } = true;
    public string Status { get; set; } = "Not applied";
}
