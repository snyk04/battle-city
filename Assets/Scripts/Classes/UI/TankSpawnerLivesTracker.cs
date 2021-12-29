using BattleCity.GameLoop;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class TankSpawnerLivesTracker
    {
        private readonly ITankSpawner _tankSpawner;
        private readonly Text _trackerText;

        public TankSpawnerLivesTracker(ITankSpawner tankSpawner, Text trackerText)
        {
            _tankSpawner = tankSpawner;
            _trackerText = trackerText;
            
            UpdateTrackerText();

            _tankSpawner.LivesReduced += UpdateTrackerText;
        }

        private void UpdateTrackerText()
        {
            string newValue = _tankSpawner.AmountOfLives >= 0 ? _tankSpawner.AmountOfLives.ToString() : "0";
            _trackerText.text = newValue;
        }
    }
}