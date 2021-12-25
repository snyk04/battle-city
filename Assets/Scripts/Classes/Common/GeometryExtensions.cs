using System.Collections.Generic;
using UnityEngine;

namespace BattleCity.Common
{
    public static class GeometryExtensions
    {
        public static Vector2 ProjectToYZ(this in Vector3 v) => new Vector2(v.y, v.z);
        public static Vector2 ProjectToXZ(this in Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 ProjectToXY(this in Vector3 v) => new Vector2(v.x, v.y);

        public static Vector3 ReProjectFromYZ(this in Vector2 v, float newX = 0.0f) => new Vector3(newX, v.x, v.y);
        public static Vector3 ReProjectFromXZ(this in Vector2 v, float newY = 0.0f) => new Vector3(v.x, newY, v.y);
        public static Vector3 ReProjectFromXY(this in Vector2 v, float newZ = 0.0f) => new Vector3(v.x, v.y, newZ);

        public static Vector2 GetClosest(this in Vector2 v, in IEnumerable<Vector2> possibleValues)
        {
            Vector2 result = Vector2.zero;
            float minAngle = float.MaxValue;
            foreach (Vector2 vector in possibleValues)
            {
                float angle = Vector2.Angle(v, vector);
                if (angle < minAngle)
                {
                    result = vector;
                    minAngle = angle;
                }
            }

            return result;
        }

        public static void Deconstruct(this Vector2Int v, out int x, out int y)
        {
            x = v.x;
            y = v.y;
        }
        public static void Deconstruct(this Vector3Int v, out int x, out int y, out int z)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }
}