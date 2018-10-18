﻿using System.Collections;
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
            Assert.That(montyHall.Doors().Count(), Is.EqualTo(3));
        }
    }

    public class MontyHall
    {
        public bool Door1 { get; set; }
        public bool Door2 { get; set; }
        public bool Door3 { get; set; }

        public IEnumerable<bool> Doors()
        {
            yield return Door1;
            yield return Door2;
            yield return Door3;
        }
    }
}
