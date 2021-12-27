using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public interface IPlayerTracker
    {
        Transform Player { get; }
    }
}