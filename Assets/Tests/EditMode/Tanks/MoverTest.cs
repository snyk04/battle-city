using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class MoverTest
    {
        private static (float, Vector2)[] _values =
        {
            (1, Vector2.right),
            (5, Vector2.left),
        };
        
        [Test]
        public void StartMovingTest([ValueSource(nameof(_values))](float, Vector2) values)
        {
            var mover = new Mover(values.Item1, new GameObject().transform);
            
            mover.StartMoving(values.Item2);
            
            Assert.AreEqual(values.Item2 * values.Item1, mover.Velocity);
        }
    }
}
