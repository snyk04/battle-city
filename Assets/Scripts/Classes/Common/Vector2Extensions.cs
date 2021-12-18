using System;
using UnityEngine;

namespace BattleCity.Common
{
    public static class Vector2Extensions
    {
        public static bool TrySnapToAxis(this ref Vector2 vector)
        {
            float xAbs = Mathf.Abs(vector.x);
            float yAbs = Mathf.Abs(vector.y);

            switch (xAbs.CompareTo(yAbs))
            {
                case 1:
                    vector.SnapToX();
                    
                    return true;
                case -1:
                    vector.SnapToY();
                    
                    return true;
                case 0: return false;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static Vector2 SnapToX(this ref Vector2 vector)
        {
            return vector = new Vector2(Mathf.Sign(vector.x), 0.0f);
        }
        
        public static Vector2 SnapToY(this ref Vector2 vector)
        {
            return vector = new Vector2(0.0f, Mathf.Sign(vector.y));
        }
    }
}
