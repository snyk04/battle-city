﻿using System.Collections.Generic;
using UnityEngine;

namespace BattleCity.AI
{
    public class FieldPathfinder
    {
        private readonly FieldContainer _fieldContainerManager;

        public FieldPathfinder(FieldContainer fieldContainerManager)
        {
            _fieldContainerManager = fieldContainerManager;
        }
        
        public Vector3[] FindShortestPath(Vector3 start, Vector3 goal)
        {
            Vector2Int fieldStart = _fieldContainerManager.SceneToFieldCoordinates(start);
            Vector2Int fieldGoal = _fieldContainerManager.SceneToFieldCoordinates(goal);

            Vector2Int[] fieldPath = Pathfinder.FindShortestPath(
                fieldStart, 
                fieldGoal, 
                _fieldContainerManager.Field
            );

            return ConvertPathToSceneCoordinates(fieldPath);
        }
        public int GetShortestPathLength(Vector3 start, Vector3 goal)
        {
            return FindShortestPath(start, goal).Length;
        }
        
        private Vector3[] ConvertPathToSceneCoordinates(IReadOnlyList<Vector2Int> fieldPath)
        {
            var path = new Vector3[fieldPath.Count];
            for (int i = 0; i < fieldPath.Count; i++)
            {
                path[i] = _fieldContainerManager.FieldToSceneCoordinates(fieldPath[i]);
            }

            return path;
        }
    }
}