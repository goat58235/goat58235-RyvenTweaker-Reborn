
using System;
using System.Collections.Generic;
using RyvenTweaker.Models;

namespace RyvenTweaker.Services
{
    public sealed class TweakEngine
    {
        private readonly Dictionary<string, Tweak> _tweaks = new();

        public IReadOnlyCollection<Tweak> Tweaks => _tweaks.Values;

        public event Action<Tweak>? TweakStatusChanged;

        public void Register(Tweak tweak)
        {
            if (tweak == null)
                throw new ArgumentNullException(nameof(tweak));

            if (string.IsNullOrWhiteSpace(tweak.Id))
                throw new ArgumentException("A tweak must have an ID.");

            if (_tweaks.ContainsKey(tweak.Id))
                throw new InvalidOperationException(
                    $"Tweak '{tweak.Id}' is already registered.");

            _tweaks.Add(tweak.Id, tweak);
        }

        public Tweak? Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _tweaks.TryGetValue(id, out Tweak? tweak)
                ? tweak
                : null;
        }

        public bool CanApply(string id, out string reason)
        {
            Tweak? tweak = Find(id);

            if (tweak == null)
            {
                reason = "Tweak not found.";
                return false;
            }

            if (!tweak.IsCompatible)
            {
                reason = "This tweak is not compatible with this system.";
                return false;
            }

            if (tweak.IsApplied)
            {
                reason = "This tweak is already marked as applied.";
                return false;
            }

            reason = "Ready for action validation.";
            return true;
        }

        public bool CanUndo(string id, out string reason)
        {
            Tweak? tweak = Find(id);

            if (tweak == null)
            {
                reason = "Tweak not found.";
                return false;
            }

            if (!tweak.IsApplied)
            {
                reason = "This tweak is not marked as applied.";
                return false;
            }

            reason = "Ready for rollback validation.";
            return true;
        }

        public void SetStatus(
            string id,
            string status,
            bool isApplied)
        {
            Tweak? tweak = Find(id);

            if (tweak == null)
                throw new KeyNotFoundException(
                    $"Tweak '{id}' was not found.");

            tweak.Status = status;
            tweak.IsApplied = isApplied;

            TweakStatusChanged?.Invoke(tweak);
        }
    }
}
