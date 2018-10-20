using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kata.MontyHall
{
    [TestFixture]
    public class MontyHallTests
    {

        [Test]
        public void GameHasThreeDoors()
        {
            var montyHall = new MontyHall();
            Assert.That(montyHall.Doors().Count(), Is.EqualTo(3));
        }

        [Test]
        public void AtGameStart_HasAWinner()
        {
            var montyHall = new MontyHall();
            montyHall.DefineWinner();
            Assert.IsTrue(montyHall.Doors().Any(door => door));
        }
    }

    public class MontyHall
    {
        public bool Door1 { get; private set; }
        public bool Door2 { get; private set; }
        public bool Door3 { get; private set; }

        public IEnumerable<bool> Doors()
        {
            yield return Door1;
            yield return Door2;
            yield return Door3;
        }

        public void DefineWinner()
        {
            Door1 = true;
        }
    }
}