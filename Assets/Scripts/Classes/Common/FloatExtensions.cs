using System;
using System.Collections.Generic;

namespace BattleCity.Common
{
    public static class FloatExtensions
    {
        public static bool Equals(this float num1, float num2, float accuracy = Constants.Epsilon)
        {
            return Math.Abs(num1 - num2) < accuracy;
        }

        public static bool Equals(this float num1, int num2, float accuracy = Constants.Epsilon)
        {
            return Math.Abs(num1 - num2) < accuracy;
        }
    }

}