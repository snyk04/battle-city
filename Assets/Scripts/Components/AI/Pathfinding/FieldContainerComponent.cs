using System;
using System.Collections.Generic;
using System.Linq;
using BattleCity.Common;
using BattleCity.GameLoop;
using UnityEngine;

namespace BattleCity.AI.Pathfinding
{
    public class FieldContainerComponent : MonoBehaviour
    {
        [Header("Field settings")]
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private List<GameObject> _walls;
        [SerializeField] private PlayerSpawnerComponent _playerSpawnerComponent;
        [SerializeField] private List<BotComponent> _botsComponents;

        [Header("Coordinates converting settings")] [SerializeField]
        private Transform _topLeftPoint;

        [SerializeField] private Transform _bottomRightPoint;

        private float _distanceBetweenPoints;

        public FieldContainer FieldContainer { get; private set; }

        private void Awake()
        {
            if (!_botsComponents.Any())
            {
                _botsComponents = FindObjectsOfType<BotComponent>().ToList();
            }
        }

        private void Start()
        {
            Vector3 topLeftPos = _topLeftPoint.position;
            _distanceBetweenPoints =
                CalculateDistanceBetweenPoints(topLeftPos, _bottomRightPoint.position, _rows, _columns);
            var topLeftCellCenter = new Vector3(topLeftPos.x + _distanceBetweenPoints / 2, topLeftPos.y,
                topLeftPos.z - _distanceBetweenPoints / 2);
            FieldContainer = new FieldContainer(
                _rows,
                _columns,
                _walls,
                topLeftCellCenter,
                _distanceBetweenPoints,
                _playerSpawnerComponent.PlayerSpawner,
                _botsComponents.Select(botComponent => botComponent.Bot.BotInfo).ToList()
            );
        }

        private void Update()
        {
            FieldContainer.UpdateField();
        }

        private float CalculateDistanceBetweenPoints(Vector3 topLeftPointPos, Vector3 bottomRightPointPos, int rows,
            int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Wrong number of rows or columns");
            }

            Vector3 delta = bottomRightPointPos - topLeftPointPos;
            if (delta.x <= 0 || delta.z >= 0)
            {
                throw new ArgumentException("Wrong positions of top left point or right bottom point");
            }

            float distanceBetweenPointsX = delta.x / columns;
            float distanceBetweenPointsY = delta.z / rows;
            if (distanceBetweenPointsX.Equals(-distanceBetweenPointsY, Constants.Epsilon))
            {
                return distanceBetweenPointsX;
            }

            throw new ArgumentException("Distance between points differ on x and y axes");
        }
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
            {
                return;
            }
            var n = FieldContainer.Field.GetLength(0);
            var m = FieldContainer.Field.GetLength(1);
            for (var x = 0; x < n; x++)
            {
                for (var y = 0; y < m; y++)
                {
                    var cell = FieldContainer.Field[x, y];
                    switch (cell)
                    {
                        case BotTankCell _:
                            Gizmos.color = Color.red;
                            break;
                        case WallCell _:
                            Gizmos.color = Color.blue;
                            break;
                        case PlayerTankCell _:
                            Gizmos.color = Color.green;
                            break;
                        default: 
                            continue;
                    }

                    Gizmos.DrawCube(FieldContainer.Converter.Convert(new Vector2Int(x, y)), Vector3.one);
                }
            }
        }
    }
}