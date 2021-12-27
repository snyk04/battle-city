using UnityEngine;

namespace BattleCity.UI
{
    public class AudioMuterComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _musicAudioSources;
        
        public AudioMuter AudioMuter { get; private set; }

        private void Awake()
        {
            AudioMuter = new AudioMuter(_musicAudioSources);
        }

        public void SwitchAllAudioMuteness()
        {
            AudioMuter.SwitchAllAudioMuteness();
        }
        public void SwitchMusicMuteness()
        {
            AudioMuter.SwitchMusicMuteness();
        }
    }
}