using BattleCity.AI;
using NUnit.Framework;
using UnityEngine;

namespace AI.Pathfinding
{
    public class PathfinderTest
    {
        private readonly bool[,] _testField1 =
        {
            {true, true, true},
            {true, true, true},
            {true, true, true}
        };
        private readonly bool[,] _testField2 =
        {
            {true, false, true},
            {true, true, true},
            {true, true, true}
        };
        private readonly Vector2Int[] _shortestPath1 =
        {
            Vector2Int.zero, new Vector2Int(0, 1), new Vector2Int(0, 2)
        };
        private readonly Vector2Int[] _shortestPath2 =
        {
            Vector2Int.zero, new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(1, 2), new Vector2Int(0, 2)
        };
        
        private readonly Vector2Int _start = Vector2Int.zero;
        private readonly Vector2Int _goal = new Vector2Int(0, 2);
        
        [Test]
        public void FindShortestPathTest1()
        {
            Assert.AreEqual(_shortestPath1, Pathfinder.FindShortestPath(_start, _goal, _testField1));
        }
        [Test]
        public void FindShortestPathTest2()
        {
            Assert.AreEqual(_shortestPath2, Pathfinder.FindShortestPath(_start, _goal, _testField2));
        }
    }
}