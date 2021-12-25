using BattleCity.Common;
using UnityEngine;

namespace BattleCity.AI
{
    public class SceneFieldCoordinatesConverter : IConverter<Vector3, Vector2Int>, IConverter<Vector2Int, Vector3>
    {
        private readonly Vector3 _topLeftFieldPointPosition;
        private readonly float _distanceBetweenPoints;

        public SceneFieldCoordinatesConverter(Vector3 topLeftFieldPointPosition, float distanceBetweenPoints)
        {
            _topLeftFieldPointPosition = topLeftFieldPointPosition;
            _distanceBetweenPoints = distanceBetweenPoints;
        }

        public Vector3 Convert(Vector2Int fieldPosition)
        {
            float x = _topLeftFieldPointPosition.x + fieldPosition.y * _distanceBetweenPoints;
            float z = _topLeftFieldPointPosition.z - fieldPosition.x * _distanceBetweenPoints;

            return new Vector3(x, _topLeftFieldPointPosition.y, z);
        }

        public Vector2Int Convert(Vector3 scenePosition)
        {
            int row = Mathf.RoundToInt((_topLeftFieldPointPosition.z - scenePosition.z) / _distanceBetweenPoints);
            int column = Mathf.RoundToInt((scenePosition.x - _topLeftFieldPointPosition.x) / _distanceBetweenPoints);

            return new Vector2Int(row, column);
        }
    }
}