using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class MoverTest
    {
        private const float Speed1 = 1;
        private const float Speed2 = 5;
        private readonly Vector3 _direction1 = Vector3.right;
        private readonly Vector3 _direction2 = Vector3.left;

        [Test]
        public void StartMovingTest1()
        {
            CreateMover(Speed1, out Rigidbody rb, out Mover mover);
            mover.StartMoving(_direction1);
            
            Assert.AreEqual(_direction1 * Speed1, rb.velocity);
        }
        [Test]
        public void StartMovingTest2()
        {
            CreateMover(Speed2, out Rigidbody rb, out Mover mover);
            mover.StartMoving(_direction2);
            
            Assert.AreEqual(_direction2 * Speed2, rb.velocity);
        }
        
        private void CreateMover(float speed, out Rigidbody rb, out Mover mover)
        {
            var moverObject = new GameObject();
            rb = moverObject.AddComponent<Rigidbody>();

            mover = new Mover(speed, rb, moverObject.transform);
        }
    }
}
