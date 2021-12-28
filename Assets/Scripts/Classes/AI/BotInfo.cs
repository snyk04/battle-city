using System;
using System.Collections.Generic;
using BattleCity.AI.Pathfinding;
using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class BotInfo
    {
        private readonly List<Vector2Int> DefaultOccupiedCells = new List<Vector2Int>()
        {
            Vector2Int.zero,
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.right,
            Vector2Int.left,
            
        };
        public event Action<IState> OnStateChange;
        public readonly Damageable Damageable;
        public readonly Mover Mover;
        public readonly Shooter Shooter;
        public readonly Transform Transform;
        public readonly IPlayerTracker PlayerTracker;
        public readonly Transform Base;
        public readonly LayerMask TanksLayerMask;
        public readonly float ShotDelay;
        public readonly FieldPathfinderComponent FieldPathfinder;
        public FieldPathfinderHelper FieldPathfinderHelper => FieldPathfinder.FieldPathfinderHelper;
        public readonly List<Vector2Int> OccupiedCells;

        public Vector3 Position => Transform.position;

        public BotInfo(Mover mover, Shooter shooter, Transform transform, IPlayerTracker playerTracker, Transform @base,
            LayerMask tanksLayerMask, float shotDelay,
            FieldPathfinderComponent fieldPathfinder, Damageable damageable)
        {
            Mover = mover;
            Shooter = shooter;
            Transform = transform;
            PlayerTracker = playerTracker;
            Base = @base;
            TanksLayerMask = tanksLayerMask;
            ShotDelay = shotDelay;
            FieldPathfinder = fieldPathfinder;
            Damageable = damageable;
            OccupiedCells = DefaultOccupiedCells;
        }

        public BotInfo(Mover mover, Shooter shooter, Transform transform, IPlayerTracker playerTracker, Transform @base,
            LayerMask tanksLayerMask, float pauseBeforeShot, float pauseAfterShot,
            FieldPathfinderComponent fieldPathfinder, List<Vector2Int> occupiedCells, Damageable damageable)
        {
            Mover = mover;
            Shooter = shooter;
            Transform = transform;
            PlayerTracker = playerTracker;
            Base = @base;
            TanksLayerMask = tanksLayerMask;
            OccupiedCells = occupiedCells;
            Damageable = damageable;
        }

        public void ChangeState(IState state)
        {
            if (OnStateChange == null)
            {
                throw new InvalidOperationException("OnStateChange should have already been initialized.");
            }

            OnStateChange(state);
        }
    }
}