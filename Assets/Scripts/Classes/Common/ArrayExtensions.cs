namespace BattleCity.Common
{
    public static class ArrayExtensions
    {
        public static void FillByNulls<T>(this T[,] array) where T: class
        {
            var n = array.GetLength(0);
            var m = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = null;

                }
            }
        }
    }
}