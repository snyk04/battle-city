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
            if (AudioSettingsTransmitter.MasterMuted)
            {
                UnMuteAllAudio();
                if (!AudioSettingsTransmitter.MusicMuted)
                {
                    UnMuteMusic();
                }
                AudioSettingsTransmitter.MasterMuted.Value = false;
            }
            else
            {
                MuteAllAudio();
                MuteMusic();
                AudioSettingsTransmitter.MasterMuted.Value = true;
            }
        }
        public void SwitchMusicMuteness()
        {
            if (AudioSettingsTransmitter.MusicMuted)
            {
                UnMuteMusic();
                AudioSettingsTransmitter.MusicMuted.Value = false;
            }
            else
            {
                MuteMusic();
                AudioSettingsTransmitter.MusicMuted.Value = true;
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
            if (AudioSettingsTransmitter.MasterMuted)
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