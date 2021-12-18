using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class MoverTest
    {
        private const float Speed = 1;
        private readonly Vector3 _direction = Vector3.right;
        
        [Test]
        public void StartMovingTest()
        {
            var moverObject = new GameObject();
            var rb = moverObject.AddComponent<Rigidbody>();

            var mover = new Mover(rb, moverObject.transform, Speed);
            
            mover.StartMoving(_direction);
            
            Assert.AreEqual(_direction * Speed, rb.velocity);
        }
    }
}
