using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public sealed class SceneFieldCoordinatesConverterTest
    {
        private readonly Vector3 _topLeftPointPosition = Vector3.zero;
        private const float DistanceBetweenPoints = 1;
        
        private static readonly Vector3[] SceneCoordinates =
        {
            Vector3.zero, Vector3.right
        };
        private static readonly Vector2Int[] FieldCoordinates =
        {
            Vector2Int.zero, Vector2Int.up, 
        };

        [Sequential]
        [Test]
        public void SceneToFieldCoordinatesTest([ValueSource(nameof(SceneCoordinates))]Vector3 sceneCoordinates,
            [ValueSource(nameof(FieldCoordinates))]Vector2Int fieldCoordinates)
        {
            SceneFieldCoordinatesConverter converter = CreateConverter();
            Assert.AreEqual(fieldCoordinates, converter.Convert(sceneCoordinates));
        }

        [Sequential]
        [Test]
        public void FieldToSceneCoordinatesTest([ValueSource(nameof(FieldCoordinates))]Vector2Int fieldCoordinates,
            [ValueSource(nameof(SceneCoordinates))]Vector3 sceneCoordinates)
        {
            SceneFieldCoordinatesConverter converter = CreateConverter();
            Assert.AreEqual(sceneCoordinates, converter.Convert(fieldCoordinates));
        }

        private SceneFieldCoordinatesConverter CreateConverter()
        {
            return new SceneFieldCoordinatesConverter(_topLeftPointPosition, DistanceBetweenPoints);
        }
    }
}