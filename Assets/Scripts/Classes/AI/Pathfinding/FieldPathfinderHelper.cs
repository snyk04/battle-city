using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleCity.AI
{
    public class FieldPathfinderHelper
    {
        private readonly FieldContainer _fieldContainerManager;
        private readonly IPathfinder _pathfinder;
        private SceneFieldCoordinatesConverter Converter => _fieldContainerManager.Converter;
        
        public FieldPathfinderHelper(FieldContainer fieldContainerManager, IPathfinder pathfinder)
        {
            _fieldContainerManager = fieldContainerManager;
            _pathfinder = pathfinder;
        }
        
        public Vector3[] FindShortestPath(Vector3 start, Vector3 goal)
        {
            Vector2Int[] fieldPath = _pathfinder.FindShortestPath(
                Converter.Convert(start), 
                Converter.Convert(goal), 
                _fieldContainerManager.Field
            );

            return fieldPath.Select(Converter.Convert).ToArray();
        }
        public int GetShortestPathLength(Vector2 start, Vector2 goal)
        {
            return FindShortestPath(start, goal).Length;
        }
    }
}