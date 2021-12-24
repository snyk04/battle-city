using System;
using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public class FieldContainerTest
    {
        private const int Rows = 3;
        private const int Columns = 3;
        private readonly Vector3 _topLeftPointPosition = Vector3.zero;
        private const float DistanceBetweenPoints = 1;
        
        private readonly Vector3 _sceneCoordinates1 = Vector3.zero;
        private readonly Vector3 _sceneCoordinates2 = new Vector3(1, 0, 0);
        private readonly Vector2Int _fieldCoordinates1 = Vector2Int.zero;
        private readonly Vector2Int _fieldCoordinates2 = new Vector2Int(0, 1);

        [Test]
        public void SceneToFieldCoordinatesTest1()
        {
            SceneToFieldCoordinatesTest(_sceneCoordinates1, _fieldCoordinates1);
        }
        [Test]
        public void SceneToFieldCoordinatesTest2()
        {
            SceneToFieldCoordinatesTest(_sceneCoordinates2, _fieldCoordinates2);
        }

        [Test]
        public void FieldToSceneCoordinatesTest1()
        {
            FieldToSceneCoordinatesTest(_fieldCoordinates1, _sceneCoordinates1);
        }
        [Test]
        public void FieldToSceneCoordinatesTest2()
        {
            FieldToSceneCoordinatesTest(_fieldCoordinates2, _sceneCoordinates2);
        }
        
        private void SceneToFieldCoordinatesTest(Vector3 sceneCoordinates, Vector2Int fieldCoordinates)
        {
            CreateFieldContainer(out FieldContainer fieldContainer);
            Assert.AreEqual(fieldCoordinates, fieldContainer.SceneToFieldCoordinates(sceneCoordinates));
        }
        private void FieldToSceneCoordinatesTest(Vector2Int fieldCoordinates, Vector3 sceneCoordinates)
        {
            CreateFieldContainer(out FieldContainer fieldContainer);
            Assert.AreEqual(sceneCoordinates, fieldContainer.FieldToSceneCoordinates(fieldCoordinates));
        }

        private void CreateFieldContainer(out FieldContainer fieldContainer)
        {
            fieldContainer = new FieldContainer(
                Rows,
                Columns,
                Array.Empty<GameObject>(),
                _topLeftPointPosition,
                DistanceBetweenPoints
            );
        }
    }
}