namespace BattleCity.UI
{
    public class MasterAudioMutenessButtonComponent : AudioMutenessButtonComponent<MasterAudioMutenessButton>
    {
        protected override MasterAudioMutenessButton Create()
        {
            return new MasterAudioMutenessButton(_image, _mutedSprite, _unMutedSprite);
        }
    }
}