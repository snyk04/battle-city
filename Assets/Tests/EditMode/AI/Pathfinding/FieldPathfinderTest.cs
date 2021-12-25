using System;
using System.Collections;
using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public class FieldPathfinderTest
    {
        private const int Rows = 3;
        private const int Columns = 3;
        private readonly Vector3 _topLeftPointPosition = Vector3.zero;
        private const float DistanceBetweenPoints = 1;

        private readonly Vector3 _start = Vector3.zero;
        private readonly Vector3 _goal = new Vector3(DistanceBetweenPoints * 2, 0, 0);

        private readonly Vector3[] _shortestPath1 =
        {
            Vector3.zero,
            new Vector3(DistanceBetweenPoints * 1, 0, 0),
            new Vector3(DistanceBetweenPoints * 2, 0, 0)
        };
        private readonly Vector3[] _shortestPath2 =
        {
            Vector3.zero,
            new Vector3(0, 0, -DistanceBetweenPoints * 1),
            new Vector3(DistanceBetweenPoints * 1, 0, -DistanceBetweenPoints * 1),
            new Vector3(DistanceBetweenPoints * 2, 0, -DistanceBetweenPoints * 1),
            new Vector3(DistanceBetweenPoints * 2, 0, 0)
        };

        [Test]
        public void FindShortestPathTest1()
        {
            GameObject[] walls = Array.Empty<GameObject>();
            FindShortestPathTest(walls, _shortestPath1);
        }
        [Test]
        public void FindShortestPathTest2()
        {
            var wall = new GameObject();
            wall.transform.position = new Vector3(1, 0, 0);

            GameObject[] walls = {wall};
            FindShortestPathTest(walls, _shortestPath2);
        }

        private void FindShortestPathTest(GameObject[] walls, IEnumerable expectedPath)
        {
            CreatePathfinder(out IPathfinder pathfinder);
            
            var field = new FieldContainer(
                Rows,
                Columns,
                walls,
                _topLeftPointPosition,
                DistanceBetweenPoints
                );
            var fieldPathFinder = new FieldPathfinderHelper(field, pathfinder);

            Vector3[] foundedPath = fieldPathFinder.FindShortestPath(_start, _goal);
            Assert.AreEqual(foundedPath, expectedPath);
        }
        
        private void CreatePathfinder(out IPathfinder pathfinder)
        {
            pathfinder = new AStarPathfinder();
        }
    }
}