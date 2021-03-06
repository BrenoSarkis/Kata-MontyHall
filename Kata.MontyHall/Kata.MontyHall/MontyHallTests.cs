﻿using System.Collections.Generic;
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
        public void OneOfTheDoorsHoldsThePrize()
        {
            var doorNumberThatHoldsPrize = 1;
            var prizeSelector = new PrizeSelectorFake(doorNumberThatHoldsPrize: doorNumberThatHoldsPrize);
            var montyHall = new MontyHall(prizeSelector);

            montyHall.DefineWinningDoor();

            Assert.That(montyHall.WinningDoor.ContainsPrize, Is.EqualTo(true));
            Assert.That(montyHall.WinningDoor.Number, Is.EqualTo(doorNumberThatHoldsPrize));
        }

        [Test]
        public void RevealsDoorWithNoPrize()
        {
            var doorNumberThatHoldsPrize = 1;
            var prizeSelector = new PrizeSelectorFake(doorNumberThatHoldsPrize: doorNumberThatHoldsPrize);
            var montyHall = new MontyHall(prizeSelector);

            montyHall.DefineWinningDoor();
            var door = montyHall.RevealDoorWithNoPrize();

            Assert.That(door.Number, Is.EqualTo(2));
            Assert.That(door.ContainsPrize, Is.EqualTo(false));
        }
    }

    public interface ISelectPrizes
    {
        int ChooseDoor();
    }

    public class PrizeSelectorFake : ISelectPrizes
    {
        private readonly int doorNumberThatHoldsPrize;

        public PrizeSelectorFake(int doorNumberThatHoldsPrize)
        {
            this.doorNumberThatHoldsPrize = doorNumberThatHoldsPrize;
        }

        public int ChooseDoor()
        {
            return this.doorNumberThatHoldsPrize;
        }
    }

    public class MontyHall
    {
        private readonly ISelectPrizes prizeSelector;

        public MontyHall()
        {
        }

        public MontyHall(ISelectPrizes prizeSelector)
        {
            this.prizeSelector = prizeSelector;
        }

        public Door Door1 { get; private set; } = new Door(1, false);
        public Door Door2 { get; private set; } = new Door(2, false);
        public Door Door3 { get; private set; } = new Door(3, false);

        public Door WinningDoor;

        public IEnumerable<Door> Doors()
        {
            yield return Door1;
            yield return Door2;
            yield return Door3;
        }

        public void DefineWinningDoor()
        {
            WinningDoor = new Door(prizeSelector.ChooseDoor(), true);
        }

        public Door RevealDoorWithNoPrize()
        {
            return Door2;
        }
    }

    public class Door
    {
        public Door(int number, bool containsPrize)
        {
            Number = number;
            ContainsPrize = containsPrize;
        }

        public int Number { get; }
        public bool ContainsPrize { get; }
    }
}