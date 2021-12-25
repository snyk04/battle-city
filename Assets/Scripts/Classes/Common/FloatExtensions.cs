using System;

namespace BattleCity.Common {
    public static class FloatExtensions {
        public static bool Equals(this float num1, float num2, float accuracy = Consts.EPSILON) {
            return Math.Abs(num1 - num2) < accuracy;
        }

        public static bool Equals(this float num1, int num2, float accuracy = Consts.EPSILON) {
            return Math.Abs(num1 - num2) < accuracy;
        }
    }
}