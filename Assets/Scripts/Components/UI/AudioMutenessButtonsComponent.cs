using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class AudioMutenessButtonsComponent : MonoBehaviour
    {
        [Header("Button images")]
        [SerializeField] private Image _allAudioMutenessButtonImage;
        [SerializeField] private Image _musicMutenessButtonImage;

        [Header("Sprites")]
        [SerializeField] private Sprite _allAudioMutedSprite;
        [SerializeField] private Sprite _allAudioUnMutedSprite;
        [SerializeField] private Sprite _musicMutedSprite;
        [SerializeField] private Sprite _musicUnMutedSprite;

        public AudioMutenessButtons AudioMutenessButtons { get; private set; }

        private void Awake()
        {
            AudioMutenessButtons = new AudioMutenessButtons(
                _allAudioMutenessButtonImage,
                _musicMutenessButtonImage,
                _allAudioMutedSprite,
                _allAudioUnMutedSprite,
                _musicMutedSprite,
                _musicUnMutedSprite
            );
        }
    }
}