using System.Collections.Generic;
using System.Linq;

namespace BattleCity.Common
{
    public static class ListExtensions
    {
        public static void Mix<T>(this List<T> collection)
        {
            int length = collection.Count;
            var random = new System.Random();

            List<int> indexes = Enumerable.Range(0, length).ToList();
            var bufferCollection = new T[length];
            
            for (int i = 0; i < length; i++)
            {
                int index = indexes[random.Next(indexes.Count)];
                indexes.Remove(index);
                bufferCollection[i] = collection[index];
            }
            
            for (int i = 0; i < length; i++)
            {
                collection[i] = bufferCollection[i];
            }
        }
    }
}