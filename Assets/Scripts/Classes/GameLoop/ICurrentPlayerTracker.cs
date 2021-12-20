using UnityEngine;

namespace BattleCity.GameLoop
{
    public interface ICurrentPlayerTracker
    {
        Vector3 CurrentPlayerPosition { get; }
    }
}
