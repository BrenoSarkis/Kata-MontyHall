using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Kata.MontyHall
{
    [TestFixture]
    public class MontyHallTests
    {
        [Test]
        public void DoorOneIsTheWinner()
        {
            var montyHall = new MontyHall();
            var doors = montyHall.DefineDoors().ToArray();
            Assert.That(doors[0], Is.EqualTo(true));
        }
    }

    public class MontyHall
    {
        public IEnumerable<bool> DefineDoors()
        {
            yield return true;
        }
    }
}
