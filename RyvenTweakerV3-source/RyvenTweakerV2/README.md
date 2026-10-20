# Ryven Tweaker V3 source preview

This is an updated Windows 11 WPF (.NET 8) project based on the supplied V2 source. The redesigned dashboard includes Apply and Undo actions and 15 supported HKCU registry changes plus 2 manual-review entries. It is not a benchmarked performance optimizer: many options are cosmetic, and FPS improvements are not guaranteed.

**Safety:** Apply and Undo store originals in memory ONLY. Undo changes before closing the app; after closing, originals are not available. Do not apply changes without understanding their effect. Some changes require Explorer restart, sign-out or reboot. No Windows Defender or network services are disabled. No admin access is required for the included HKCU changes.

Build on Windows with .NET 8 SDK: `dotnet publish RyvenTweaker.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o publish`

Source has not been compiled in this environment; use GitHub Actions to verify. For your existing repository, upload/replace the V2 project directory contents and keep your workflow path consistent.
