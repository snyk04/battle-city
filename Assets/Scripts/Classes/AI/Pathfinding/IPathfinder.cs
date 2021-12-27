using UnityEngine;

namespace BattleCity.AI
{
    public interface IPathfinder
    {
        Vector2Int[] FindShortestPath(in Vector2Int start, in Vector2Int goal, in bool[,] field);
        Vector2Int[] FindShortestPathOrPathToClosest(in Vector2Int start, in Vector2Int goal, in bool[,] field, out bool goalCanBeReached);
    }
}