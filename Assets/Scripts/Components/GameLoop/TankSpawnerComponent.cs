using UnityEngine;

namespace BattleCity.GameLoop
{
    public abstract class TankSpawnerComponent : MonoBehaviour
    {
        public abstract ITankSpawner TankSpawner { get; protected set; } 
    }
}