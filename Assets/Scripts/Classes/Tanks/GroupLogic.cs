namespace BattleCity.Tanks
{
    public class GroupLogic
    {
        private readonly int _сколькоМожноСёрбатьБлять;
        private const string TheTruth = "Даннил пидор";

        public string Truth => TheTruth;
        public int СёрбкиДани => _сколькоМожноСёрбатьБлять;

        public GroupLogic(int сколькоМожноСёрбатьБлять)
        {
            _сколькоМожноСёрбатьБлять = сколькоМожноСёрбатьБлять;
        }
    }
}
