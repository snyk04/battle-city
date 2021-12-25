using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleCity.AI
{
    public sealed class AStarPathfinder : IPathfinder
    {
        private const int DistanceBetweenNeighbours = 1;

        public Vector2Int[] FindShortestPath(in Vector2Int start, in Vector2Int goal, in bool[,] field)
        {
            var closedSet = new List<Node>();
            var openSet = new List<Node>();

            var startNode = new Node
            {
                Position = start,
                CameFrom = null,
                DistanceFromStart = 0,
                ApproximatePathLength = CalculateApproximatePathLength(start, goal)
            };
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.OrderBy(node => node.FullPathLength).First();

                if (currentNode.Position == goal)
                {
                    return GetPathFromStartToNode(currentNode);
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                foreach (Node neighbourNode in GetValidNeighbours(currentNode, goal, field))
                {
                    if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                    {
                        continue;
                    }

                    Node openNode = openSet.FirstOrDefault(node => node.Position == neighbourNode.Position);

                    if (openNode == null)
                    {
                        openSet.Add(neighbourNode);
                    }
                    else if (openNode.DistanceFromStart > neighbourNode.DistanceFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.DistanceFromStart = neighbourNode.DistanceFromStart;
                    }
                }
            }

            return null;
        }

        private IEnumerable<Node> GetValidNeighbours(Node node, Vector2Int goal, bool[,] field)
        {
            return (
                from uncheckedNeighbour in GetUncheckedNeighbours(node)
                where NeighbourIsValid(uncheckedNeighbour, field)
                select new Node
                {
                    Position = uncheckedNeighbour,
                    CameFrom = node,
                    DistanceFromStart = node.DistanceFromStart + DistanceBetweenNeighbours,
                    ApproximatePathLength = CalculateApproximatePathLength(uncheckedNeighbour, goal)
                }
            ).ToArray();
        }
        private IEnumerable<Vector2Int> GetUncheckedNeighbours(in Node node)
        {
            Vector2Int[] uncheckedNeighbours =
            {
                new Vector2Int(node.Position.x + 1, node.Position.y),
                new Vector2Int(node.Position.x - 1, node.Position.y),
                new Vector2Int(node.Position.x, node.Position.y + 1),
                new Vector2Int(node.Position.x, node.Position.y - 1)
            };

            return uncheckedNeighbours;
        }
        private bool NeighbourIsValid(in Vector2Int position, in bool[,] field)
        {
            return position.x >= 0
                   && position.x < field.GetLength(0)
                   && position.y >= 0
                   && position.y < field.GetLength(1)
                   && PointIsWalkable(position, field);
        }
        private bool PointIsWalkable(in Vector2Int position, in bool[,] field)
        {
            return field[position.x, position.y];
        }

        private Vector2Int[] GetPathFromStartToNode(in Node node)
        {
            var path = new List<Vector2Int>();

            Node currentNode = node;
            while (currentNode != null)
            {
                path.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }

            path.Reverse();
            return path.ToArray();
        }

        private int CalculateApproximatePathLength(in Vector2Int start, in Vector2Int goal)
        {
            int xDistance = Math.Abs(goal.x - start.x);
            int yDistance = Math.Abs(goal.y - start.y);

            return xDistance + yDistance;
        }
    }
}