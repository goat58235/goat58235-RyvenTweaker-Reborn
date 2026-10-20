
using System.Collections.Generic;
using RyvenTweaker.Models;

namespace RyvenTweaker.Services
{
    public static class TweakFactory
    {
        public static List<Tweak> CreateDefaultTweaks()
        {
            return new List<Tweak>
            {
                new Tweak
                {
                    Id = "windows.game-mode",
                    Name = "Windows Game Mode",
                    Description =
                        "Review Windows Game Mode settings for gaming.",
                    Category = "Windows",
                    ExpectedBenefit =
                        "May help Windows prioritize gaming workloads.",
                    Risk = TweakRisk.Low,
                    RequiresAdministrator = false,
                    RequiresRestart = false,
                    IsCompatible = true,
                    Status = "Not applied"
                },

                new Tweak
                {
                    Id = "windows.transparency",
                    Name = "Disable Transparency Effects",
                    Description =
                        "Reduce transparency effects in the Windows interface.",
                    Category = "Windows",
                    ExpectedBenefit =
                        "May slightly reduce desktop rendering overhead.",
                    Risk = TweakRisk.Low,
                    RequiresAdministrator = false,
                    RequiresRestart = false,
                    IsCompatible = true,
                    Status = "Not applied"
                },

                new Tweak
                {
                    Id = "input.mouse-acceleration",
                    Name = "Mouse Acceleration",
                    Description =
                        "Review the Windows pointer precision setting.",
                    Category = "Input",
                    ExpectedBenefit =
                        "Can provide more consistent mouse movement when configured to your preference.",
                    Risk = TweakRisk.Low,
                    RequiresAdministrator = false,
                    RequiresRestart = false,
                    IsCompatible = true,
                    Status = "Not applied"
                },

                new Tweak
                {
                    Id = "windows.visual-effects",
                    Name = "Visual Effects",
                    Description =
                        "Review Windows animation and visual effect settings.",
                    Category = "Windows",
                    ExpectedBenefit =
                        "May make the desktop feel more responsive on some systems.",
                    Risk = TweakRisk.Medium,
                    RequiresAdministrator = false,
                    RequiresRestart = false,
                    IsCompatible = true,
                    Status = "Not applied"
                },

                new Tweak
                {
                    Id = "gaming.fullscreen",
                    Name = "Fullscreen Optimization Review",
                    Description =
                        "Review fullscreen behavior for individual games.",
                    Category = "Gaming",
                    ExpectedBenefit =
                        "Results vary by game, Windows version, and graphics driver.",
                    Risk = TweakRisk.Medium,
                    RequiresAdministrator = false,
                    RequiresRestart = false,
                    IsCompatible = true,
                    Status = "Not applied"
                }
            };
        }
    }
}
