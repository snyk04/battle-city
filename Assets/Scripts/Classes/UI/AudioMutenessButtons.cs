using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public abstract class AudioMutenessButton
    {
        protected readonly Image ButtonImage;
        protected readonly Sprite MutedSprite;
        protected readonly Sprite UnMutedSprite;

        protected AudioMutenessButton(Image buttonImage, Sprite mutedSprite, Sprite unMutedSprite)
        {
            ButtonImage = buttonImage;
            MutedSprite = mutedSprite;
            UnMutedSprite = unMutedSprite;
        }

        protected virtual void ConfigureMutenessButton(bool isMuted)
        {
            ButtonImage.sprite = isMuted ? MutedSprite : UnMutedSprite;
        }
    }
}