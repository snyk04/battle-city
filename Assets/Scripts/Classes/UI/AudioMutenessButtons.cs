using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class AudioMutenessButtons
    {
        private readonly Image _allAudioMutenessButtonImage;
        private readonly Image _musicMutenessButtonImage;

        private readonly Sprite _allAudioMutedSprite;
        private readonly Sprite _allAudioUnMutedSprite;
        private readonly Sprite _musicMutedSprite;
        private readonly Sprite _musicUnMutedSprite;
        
        public AudioMutenessButtons(Image allAudioMutenessButtonImage, Image musicMutenessButtonImage, Sprite allAudioMutedSprite, Sprite allAudioUnMutedSprite, Sprite musicMutedSprite, Sprite musicUnMutedSprite)
        {
            _allAudioMutenessButtonImage = allAudioMutenessButtonImage;
            _musicMutenessButtonImage = musicMutenessButtonImage;
            _allAudioMutedSprite = allAudioMutedSprite;
            _allAudioUnMutedSprite = allAudioUnMutedSprite;
            _musicMutedSprite = musicMutedSprite;
            _musicUnMutedSprite = musicUnMutedSprite;

            ConfigureAllAudioMutenessButton();
            ConfigureMusicMutenessButton();
            
            AudioSettingsTransmitter.AllAudioMutenessChanged += ConfigureAllAudioMutenessButton;
            AudioSettingsTransmitter.MusicMutenessChanged += ConfigureMusicMutenessButton;
        }

        private void ConfigureAllAudioMutenessButton()
        {
            Sprite newSprite = AudioSettingsTransmitter.AllAudioMuted
                ? _allAudioMutedSprite
                : _allAudioUnMutedSprite;

            _allAudioMutenessButtonImage.sprite = newSprite;
        }
        private void ConfigureMusicMutenessButton()
        {
            Sprite newSprite = AudioSettingsTransmitter.MusicMuted
                ? _musicMutedSprite
                : _musicUnMutedSprite;

            _musicMutenessButtonImage.sprite = newSprite;
        }
    }
}