#nullable enable

using System.Linq;
using BattleCity.Tanks;
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

        public Vector3[]? FindShortestPath(Vector3 start, Vector3 goal, Mover caller, out bool goalCanBeReached)
        {
            Vector2Int[]? fieldPath = _pathfinder.FindShortestPathOrPathToClosest(
                Converter.Convert(start),
                Converter.Convert(goal),
                _fieldContainerManager.GetFieldBoolRepresentation(caller),
                out goalCanBeReached
            );


            return fieldPath?.Select(Converter.Convert).ToArray();
        }
        public int GetShortestPathLength(Vector2 start, Vector2 goal, Mover caller)
        {
            // todo make out length param in FindShortestPath
            Vector2Int[]? path = _pathfinder.FindShortestPath(
                Converter.Convert(start),
                Converter.Convert(goal),
                _fieldContainerManager.GetFieldBoolRepresentation(caller)
            );
            return path?.Length ?? 0;
        }
    }
}