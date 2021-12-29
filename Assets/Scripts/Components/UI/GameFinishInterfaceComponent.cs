using BattleCity.GameLoop;
using UnityEngine;

namespace BattleCity.UI
{
    public class GameFinishInterfaceComponent : MonoBehaviour
    {
        [Header("Windows")]
        [SerializeField] private GameObject _victoryWindow;
        [SerializeField] private GameObject _defeatWindow;

        [Header("References")]
        [SerializeField] private GameFinisherComponent _gameFinisher;
        [SerializeField] private GameObject[] _uIToTurnOff;
        [SerializeField] private GameObject _backgroundImage;
   
        public GameFinishInterface GameFinishInterface { get; private set; }

        private void Awake()
        {
            GameFinisher gameFinisher = _gameFinisher.GameFinisher;
            
            GameFinishInterface = new GameFinishInterface(_victoryWindow, _defeatWindow, gameFinisher, _uIToTurnOff,
                _backgroundImage);
        }
    }
}