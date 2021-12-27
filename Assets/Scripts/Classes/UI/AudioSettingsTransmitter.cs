using System;

namespace BattleCity.UI
{
    public class AudioSettingsTransmitter : Observable<bool>
    {
        public static readonly AudioSettingsTransmitter MasterMuted = new AudioSettingsTransmitter();
        public static readonly AudioSettingsTransmitter MusicMuted = new AudioSettingsTransmitter();
    }

    public class Observable<T>
    {
        public event Action<T> OnChange;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!value.Equals(_value))
                {
                    _value = value;
                    OnChange?.Invoke(_value = value);
                }
            }
        }

        public void Change(T isMuted)
        {
            Value = isMuted;
        }
        
        public static implicit operator T(Observable<T> observable)
        {
            return observable.Value;
        }
    }
}