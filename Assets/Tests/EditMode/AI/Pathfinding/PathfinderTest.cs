using System.Collections;
using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public class PathfinderTest
    {
        private readonly Vector2Int _start = Vector2Int.zero;
        private readonly Vector2Int _goal = new Vector2Int(0, 2);
        
        private static readonly Vector2Int[][] ExpectedPaths =
        {
            new[]
            {
                Vector2Int.zero,
                Vector2Int.up, 
                Vector2Int.up * 2
            },
            new[]
            {
                Vector2Int.zero,
                Vector2Int.right, 
                new Vector2Int(1, 1),
                new Vector2Int(1, 2),
                Vector2Int.up * 2
            }
        };
        private static readonly bool[][,] TestFields =
        {
            new[,]
            {
                {true, true, true},
                {true, true, true},
                {true, true, true}
            },
            new[,]
            {
                {true, false, true},
                {true, true, true},
                {true, true, true}
            }
        };
        
        [Sequential]
        [Test]
        public void FindShortestPathTest([ValueSource(nameof(ExpectedPaths))]IEnumerable expectedPath,
            [ValueSource(nameof(TestFields))]bool[,] testField)
        {
            IPathfinder pathfinder = CreatePathfinder();
            Assert.AreEqual(expectedPath, pathfinder.FindShortestPath(_start, _goal, testField));
        }
        
        private IPathfinder CreatePathfinder()
        {
            return new AStarPathfinder();
        }

    }
}