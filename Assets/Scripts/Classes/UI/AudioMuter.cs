using UnityEngine;

namespace BattleCity.UI
{
    public class AudioMuter
    {
        private readonly AudioSource[] _musicAudioSources;
        
        public AudioMuter(AudioSource[] musicAudioSources)
        {
            _musicAudioSources = musicAudioSources;
            
            LoadMuteSettings();
        }
        
        public void SwitchAllAudioMuteness()
        {
            if (AudioSettingsTransmitter.AllAudioMuted)
            {
                UnMuteAllAudio();
                if (!AudioSettingsTransmitter.MusicMuted)
                {
                    UnMuteMusic();
                }
                AudioSettingsTransmitter.AllAudioMuted = false;
            }
            else
            {
                MuteAllAudio();
                MuteMusic();
                AudioSettingsTransmitter.AllAudioMuted = true;
            }
        }
        public void SwitchMusicMuteness()
        {
            if (AudioSettingsTransmitter.MusicMuted)
            {
                UnMuteMusic();
                AudioSettingsTransmitter.MusicMuted = false;
            }
            else
            {
                MuteMusic();
                AudioSettingsTransmitter.MusicMuted = true;
            }
        }
        
        public void MuteAllAudio()
        {
            AudioListener.volume = 0;
        }
        public void MuteMusic()
        {
            foreach (AudioSource musicAudioSource in _musicAudioSources)
            {
                musicAudioSource.Pause();
            }
        }

        public void UnMuteAllAudio()
        {
            AudioListener.volume = 1;
        }
        public void UnMuteMusic()
        {
            foreach (AudioSource musicAudioSource in _musicAudioSources)
            {
                musicAudioSource.UnPause();
            }
        }
        
        private void LoadMuteSettings()
        {
            if (AudioSettingsTransmitter.AllAudioMuted)
            {
                MuteAllAudio();
            }
            else
            {
                UnMuteAllAudio();
            }
            
            if (AudioSettingsTransmitter.MusicMuted)
            {
                MuteMusic();
            }
            else
            {
                UnMuteMusic();
            }
        }
    }
}