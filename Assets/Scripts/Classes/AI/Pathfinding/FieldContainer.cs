using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BattleCity.Common;
using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class FieldContainer
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly List<GameObject> _walls;
        private readonly IPlayerTracker _playerTracker;
        private readonly List<BotInfo> _bots;
        public readonly Vector3 TopLeftPointPosition;
        public readonly float DistanceBetweenPoints;
        public readonly SceneFieldCoordinatesConverter Converter;

        private List<Vector2Int> _wallCoordinates;

        public ICell[,] Field { get; private set; }

        public FieldContainer(int rows, int columns, List<GameObject> walls, Vector3 topLeftPointPosition,
            float distanceBetweenPoints, IPlayerTracker playerTracker, List<BotInfo> bots)
        {
            _rows = rows;
            _columns = columns;
            _walls = walls;
            TopLeftPointPosition = topLeftPointPosition;
            DistanceBetweenPoints = distanceBetweenPoints;
            _playerTracker = playerTracker;
            _bots = bots;

            Converter = new SceneFieldCoordinatesConverter(TopLeftPointPosition, DistanceBetweenPoints);

            HandleWalls();
            SubscribeToBotsOnDestroy();
            InitializeField();
        }
        private void SubscribeToBotsOnDestroy()
        {
            foreach (var bot in _bots)
            {
                bot.Damageable.OnDestroy += () => OnBotDestroy(bot);
            }
        }
        private void OnBotDestroy(BotInfo botInfo)
        {
            _bots.Remove(botInfo);
        }

        private void HandleWalls()
        {
            _wallCoordinates = new List<Vector2Int>(_walls.Count);
            for (int i = 0; i < _walls.Count; i++)
            {
                GameObject wall = _walls[i];
                Vector3 scenePosition = wall.transform.position;
                Vector2Int fieldCoordinates = Converter.Convert(scenePosition);
                _wallCoordinates.Add(fieldCoordinates);

                if (wall.TryGetComponent(out DamageableComponent damageableComponent))
                {
                    Damageable damageable = damageableComponent.Damageable;
                    damageable.OnDestroy += () => DestroyWall(fieldCoordinates);
                }
            }
        }
        private void InitializeField()
        {
            Field = new ICell[_rows, _columns];
            UpdateField();
        }
        public bool[,] GetFieldBoolRepresentation(Mover caller)
        {
            var n = Field.GetLength(0);
            var m = Field.GetLength(1);
            var result = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = Field[i, j].CanBePassed(caller);
                }
            }
            return result;
        }
        public void UpdateField()
        {
            Field.FillByNulls();
            AddBotsPositionsToField();
            AddPlayerPositionToField();
            AddWallsPositionToField();
            var n = Field.GetLength(0);
            var m = Field.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Field[i, j] == null) // todo check (i, j) or (j, i)
                    {
                        Field[i, j] = new EmptyCell();
                    }
                }
            }


        }
        private void AddWallsPositionToField()
        {
            foreach (var wallPos in _wallCoordinates)
            {
                OccupyCellByWall(wallPos);

            }
        }
        private void AddPlayerPositionToField()
        {
            Vector2Int pos = Converter.Convert(_playerTracker.Player.position);
            OccupyCellByPlayer(pos);
        }
        private void AddBotsPositionsToField()
        {
            foreach (var bot in _bots)
            {
                Vector2Int pos = Converter.Convert(bot.Position);
                SetOccupiedCells(bot, pos);

            }
        }
        private void SetOccupiedCells(BotInfo bot, Vector2Int pos)
        {
            bot.OccupiedCells.ForEach(localPos => OccupyCell(bot, pos + localPos));
        }
        private void OccupyCell(BotInfo bot, Vector2Int pos)
        {
            if (!IsFieldContainsPos(pos))
            {
                return;
            }
            Field[pos.x, pos.y] = Field[pos.x, pos.y] != null ? new BotTankCell(null) : new BotTankCell(bot.Mover);
        }
        private void OccupyCell(Type type, Vector2Int pos)
        {
            if (!IsFieldContainsPos(pos))
            {
                return;
            }
            Field[pos.x, pos.y] = (ICell) type.GetConstructor(new[]
            {
                typeof(Mover)
            })?.Invoke(null);
        }
        private void OccupyCellByPlayer(Vector2Int pos)
        {
            if (!IsFieldContainsPos(pos))
            {
                return;
            }
            Field[pos.x, pos.y] = new PlayerTankCell();
        }
        private void OccupyCellByWall(Vector2Int pos)
        {
            if (!IsFieldContainsPos(pos))
            {
                return;
            }
            Field[pos.x, pos.y] = new WallCell();
        }
        private bool IsFieldContainsPos(Vector2Int pos)
        {
            if (pos.x < 0 || pos.y < 0)
            {
                return false;
            }
            var n = Field.GetLength(0);
            var m = Field.GetLength(1);
            return pos.x < n && pos.y < m;

        }

        private void DestroyWall(Vector2Int wallPosition)
        {
            var wall = _walls.Find(wall => Converter.Convert(wall.transform.position).Equals(wallPosition));
            _walls.Remove(wall);
            _wallCoordinates.Remove(wallPosition);
            Field[wallPosition.x, wallPosition.y] = new EmptyCell();
        }

        /*public Vector2Int SceneToFieldCoordinates(in Vector3 scenePosition)
        {
            int row = Mathf.RoundToInt((TopLeftPointPosition.z - scenePosition.z) / DistanceBetweenPoints);
            int column = Mathf.RoundToInt((scenePosition.x - TopLeftPointPosition.x) / DistanceBetweenPoints);

            return new Vector2Int(row, column);
        }
        public Vector3 FieldToSceneCoordinates(in Vector2Int fieldPosition)
        {
            float x = TopLeftPointPosition.x + fieldPosition.y * DistanceBetweenPoints;
            float z = TopLeftPointPosition.z - fieldPosition.x * DistanceBetweenPoints;
            
            return new Vector3(x, TopLeftPointPosition.y, z);
        }*/
    }
}