using UnityEngine;

namespace BattleCity.GameLoop
{
    public interface ICurrentPlayerTracker
    {
        Transform CurrentPlayer { get; }
    }
}