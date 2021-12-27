using System;

namespace BattleCity.UI
{
    public static class AudioSettingsTransmitter
    {
        public static bool AllAudioMuted
        {
            get => _allAudioMuted;
            set
            {
                _allAudioMuted = value;
                AllAudioMutenessChanged?.Invoke();
            }
        }
        public static bool MusicMuted
        {
            get => _musicMuted;
            set
            {
                _musicMuted = value;
                MusicMutenessChanged?.Invoke();
            }
        }
        
        private static bool _allAudioMuted;
        private static bool _musicMuted;

        public static event Action AllAudioMutenessChanged;
        public static event Action MusicMutenessChanged;
    }
}