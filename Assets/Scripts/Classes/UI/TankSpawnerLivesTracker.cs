using BattleCity.GameLoop;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class TankSpawnerLivesTracker
    {
        private readonly ITankSpawner _tankSpawner;
        private readonly Text _trackerText;
        private readonly string _prefix;

        public TankSpawnerLivesTracker(ITankSpawner tankSpawner, Text trackerText, string prefix)
        {
            _tankSpawner = tankSpawner;
            _trackerText = trackerText;
            _prefix = prefix;

            UpdateTrackerText();

            _tankSpawner.LivesReduced += UpdateTrackerText;
        }

        private void UpdateTrackerText()
        {
            _trackerText.text = $"{_prefix}{_tankSpawner.AmountOfLives}";
        }
    }
}