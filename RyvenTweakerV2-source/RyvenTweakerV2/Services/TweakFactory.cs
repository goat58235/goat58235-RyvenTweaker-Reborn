using RyvenTweaker.Models;
namespace RyvenTweaker.Services;
public static class TweakFactory
{
    public static List<Tweak> CreateDefaultTweaks() => new()
    {
        new() { Id="windows.game-mode", Name="Windows Game Mode", Category="Windows", Description="Enable Windows Game Mode for the current user.", ExpectedBenefit="May improve gaming workload scheduling; results vary.", Risk=TweakRisk.Low },
        new() { Id="windows.transparency", Name="Disable Transparency Effects", Category="Windows", Description="Disable acrylic and transparency effects for the current user.", ExpectedBenefit="Slightly reduces desktop visual overhead.", Risk=TweakRisk.Low },
        new() { Id="input.mouse-acceleration", Name="Disable Mouse Acceleration", Category="Input", Description="Disable Enhance Pointer Precision for Windows cursor movement.", ExpectedBenefit="More consistent Windows pointer movement; games using raw input may be unaffected.", Risk=TweakRisk.Low },
        new() { Id="windows.visual-effects", Name="Visual Effects Review", Category="Windows", Description="Manual review recommended; not automatically modified.", ExpectedBenefit="No automatic change.", Risk=TweakRisk.Medium, IsCompatible=false, Status="Manual review" },
        new() { Id="gaming.fullscreen", Name="Fullscreen Optimization Review", Category="Gaming", Description="Per-game compatibility settings need an explicit game executable.", ExpectedBenefit="No automatic change.", Risk=TweakRisk.Medium, IsCompatible=false, Status="Manual review" }
    };
}
