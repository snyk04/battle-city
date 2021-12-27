namespace BattleCity.UI
{
    public class MusicAudioMutenessButtonComponent : AudioMutenessButtonComponent<MusicAudioMutenessButton>
    {
        protected override MusicAudioMutenessButton Create()
        {
            return new MusicAudioMutenessButton(_image, _mutedSprite, _unMutedSprite);
        }
    }
}