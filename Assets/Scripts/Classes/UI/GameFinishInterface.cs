using System;
using BattleCity.GameLoop;
using UnityEngine;

namespace BattleCity.UI
{
    public class GameFinishInterface
    {
        private readonly GameObject _victoryWindow;
        private readonly GameObject _defeatWindow;

        private readonly GameObject[] _uIToTurnOff;
        private readonly GameObject _backgroundImage;

        public GameFinishInterface(GameObject victoryWindow, GameObject defeatWindow, GameFinisher gameFinisher,
            GameObject[] uIToTurnOff, GameObject backgroundImage)
        {
            _victoryWindow = victoryWindow;
            _defeatWindow = defeatWindow;
            _uIToTurnOff = uIToTurnOff;
            _backgroundImage = backgroundImage;

            gameFinisher.GameFinished += HandleGameFinish;
        }

        private void HandleGameFinish(GameFinishType gameFinishType)
        {
            GameObject windowToActivate = gameFinishType switch
            {
                GameFinishType.Victory => _victoryWindow,
                GameFinishType.Defeat => _defeatWindow,
                _ => throw new ArgumentOutOfRangeException(nameof(gameFinishType), gameFinishType, null)
            };

            foreach (GameObject uIControl in _uIToTurnOff)
            {
                uIControl.SetActive(false);
            }
            
            _backgroundImage.SetActive(true);
            windowToActivate.SetActive(true);
        }
    }
}