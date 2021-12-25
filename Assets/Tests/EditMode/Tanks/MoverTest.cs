using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class MoverTest
    {
        private static readonly float[] Speeds =
        {
            1,
            5
        };
        private static readonly Vector2[] MoveDirections =
        {
            Vector2.right, 
            Vector2.left
        };
        
        [Sequential]
        [Test]
        public void StartMovingTest([ValueSource(nameof(Speeds))]float speed, 
            [ValueSource(nameof(MoveDirections))]Vector2 moveDirection)
        {
            Mover mover = CreateMover(speed, new GameObject().transform);
            mover.StartMoving(moveDirection);
            
            Assert.AreEqual(moveDirection * speed, mover.Velocity);
        }

        private Mover CreateMover(float speed, Transform transform)
        {
            return new Mover(speed, transform);
        }
    }
}