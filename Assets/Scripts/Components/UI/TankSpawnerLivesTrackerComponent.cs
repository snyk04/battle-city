using BattleCity.GameLoop;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity.UI
{
    public class TankSpawnerLivesTrackerComponent : MonoBehaviour
    {
        [SerializeField] private TankSpawnerComponent _tankSpawner;
        [SerializeField] private Text _trackerText;
        [SerializeField] private string _prefix;
        
        public TankSpawnerLivesTracker TankSpawnerLivesTracker { get; private set; }

        private void Awake()
        {
            TankSpawnerLivesTracker = new TankSpawnerLivesTracker(_tankSpawner.TankSpawner, _trackerText, _prefix);
        }
    }
}