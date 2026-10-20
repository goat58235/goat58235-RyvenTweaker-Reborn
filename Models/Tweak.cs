
namespace RyvenTweaker.Models
{
    public enum TweakRisk
    {
        Low,
        Medium,
        High
    }

    public sealed class Tweak
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string ExpectedBenefit { get; set; } = string.Empty;

        public TweakRisk Risk { get; set; } = TweakRisk.Low;

        public bool RequiresAdministrator { get; set; }

        public bool RequiresRestart { get; set; }

        public bool IsApplied { get; set; }

        public bool IsCompatible { get; set; } = true;

        public string Status { get; set; } = "Not applied";
    }
}
