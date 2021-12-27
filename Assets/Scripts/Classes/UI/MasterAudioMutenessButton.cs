using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class MasterAudioMutenessButton : AudioMutenessButton, IDisposable
    {
        public MasterAudioMutenessButton(Image buttonImage, Sprite mutedSprite, Sprite unMutedSprite) : base(
            buttonImage, mutedSprite, unMutedSprite)
        {
            AudioSettingsTransmitter.MasterMuted.OnChange += ConfigureMutenessButton;
        }
        public virtual void Dispose()
        {
            AudioSettingsTransmitter.MasterMuted.OnChange -= ConfigureMutenessButton;
        }
    }
}