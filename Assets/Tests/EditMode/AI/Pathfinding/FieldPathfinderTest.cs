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
        
        private static readonly Vector3[][] ExpectedPaths =
        {
            new [] 
            {
                Vector3.zero,
                new Vector3(DistanceBetweenPoints * 1, 0, 0),
                new Vector3(DistanceBetweenPoints * 2, 0, 0)
            },
            new [] 
            {
                Vector3.zero,
                new Vector3(0, 0, -DistanceBetweenPoints * 1),
                new Vector3(DistanceBetweenPoints * 1, 0, -DistanceBetweenPoints * 1),
                new Vector3(DistanceBetweenPoints * 2, 0, -DistanceBetweenPoints * 1),
                new Vector3(DistanceBetweenPoints * 2, 0, 0)
            }
        };
        private static readonly GameObject[][] Walls =
        {
            Array.Empty<GameObject>(),
            new []
            {
                new GameObject
                {
                    transform =
                    {
                        position = Vector3.right
                    }
                }
            }
        };

        [Sequential]
        [Test]
        public void FindShortestPathTest([ValueSource(nameof(Walls))]GameObject[] walls, 
            [ValueSource(nameof(ExpectedPaths))] IEnumerable expectedPath)
        {
            IPathfinder pathfinder = CreatePathfinder();
            
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

        private IPathfinder CreatePathfinder()
        {
            return new AStarPathfinder();
        }
    }
}