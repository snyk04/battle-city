using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public abstract class AudioMutenessButtonComponent<TAudioMutenessButton> : MonoBehaviour where TAudioMutenessButton : AudioMutenessButton, IDisposable
    {
        [Header("Button images")]
        [SerializeField] protected Image _image;

        [Header("Sprites")]
        [SerializeField] protected Sprite _mutedSprite;
        [SerializeField] protected Sprite _unMutedSprite;

        public TAudioMutenessButton AudioMutenessButton { get; private set; }

        protected virtual void Awake()
        {
            AudioMutenessButton = Create();
        }

        protected abstract TAudioMutenessButton Create();

        protected virtual void OnDestroy()
        {
            AudioMutenessButton.Dispose();
        }
    }
}