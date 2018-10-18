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
        public void AtStartGameHasThreeDoors()
        {
            var montyHall = new MontyHall();
            var doors = montyHall.StartNew();
            Assert.That(doors.Count(), Is.EqualTo(3));
        }
    }

    public class MontyHall
    {
        public IEnumerable<bool> StartNew()
        {
            yield return false;
            yield return false;
            yield return false;
        }
    }
}
