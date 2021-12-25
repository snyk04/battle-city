using UnityEngine;

namespace BattleCity.AI
{
    public class Node
    {
        public Vector2Int Position { get; set; }

        public Node CameFrom { get; set; }

        public int DistanceFromStart { get; set; }
        public int ApproximatePathLength { get; set; }
        public int FullPathLength => DistanceFromStart + ApproximatePathLength;
    }
}