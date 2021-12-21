using System;
using UnityEngine;

namespace BattleCity.Common
{
    public static class Vector3Extensions
    {
        public static void SnapToAxis(this ref Vector3 vector)
        {
            vector = Math.Abs(vector.x) > Math.Abs(vector.z)
                ? new Vector3(vector.x, 0, 0)
                : new Vector3(0, 0, vector.z);
        }
    }
}
