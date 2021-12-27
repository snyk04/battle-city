using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class MusicAudioMutenessButton : AudioMutenessButton, IDisposable
    {
        public MusicAudioMutenessButton(Image buttonImage, Sprite mutedSprite, Sprite unMutedSprite) : base(
            buttonImage, mutedSprite, unMutedSprite)
        {
            AudioSettingsTransmitter.MusicMuted.OnChange += ConfigureMutenessButton;
        }
        public virtual void Dispose()
        {
            AudioSettingsTransmitter.MusicMuted.OnChange -= ConfigureMutenessButton;
        }
    }
}