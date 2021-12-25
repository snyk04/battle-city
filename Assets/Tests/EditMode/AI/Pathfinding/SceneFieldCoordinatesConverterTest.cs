using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public sealed class SceneFieldCoordinatesConverterTest
    {
        private readonly Vector3 _topLeftPointPosition = Vector3.zero;
        private const float DistanceBetweenPoints = 1;

        private SceneFieldCoordinatesConverter _converter;

        private static readonly (Vector3, Vector2Int)[] TestValues =
        {
            (Vector3.zero, Vector2Int.zero),
            (Vector3.right, Vector2Int.up)
        };

        public SceneFieldCoordinatesConverterTest()
        {
            _converter = new SceneFieldCoordinatesConverter(_topLeftPointPosition, DistanceBetweenPoints);
        }

        [Test]
        public void SceneToFieldCoordinatesTest([ValueSource(nameof(TestValues))] (Vector3, Vector2Int) values)
        {
            Assert.AreEqual(values.Item2, _converter.Convert(values.Item1));
        }

        [Test]
        public void FieldToSceneCoordinatesTest([ValueSource(nameof(TestValues))] (Vector3, Vector2Int) values)
        {
            Assert.AreEqual(values.Item1, _converter.Convert(values.Item2));
        }
    }
}