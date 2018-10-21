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
        public void OneOfTheDoorsHoldsThePrize()
        {
            var montyHall = new MontyHall();
            montyHall.DefineWinner();
            Assert.That(montyHall.Doors().Count(door => door.ContainsPrize), Is.EqualTo(1));
        }

        [Test]
        public void RevealsDoorWithNoPrize()
        {
            var prizeSelector = new PrizeSelectorMock(doorNumberThatHoldsPrize: 1);
            var montyHall = new MontyHall(prizeSelector);

            montyHall.DefineWinner();
            var door = montyHall.RevealDoorWithNoPrize();

            Assert.That(door.Number, Is.EqualTo(2));
            Assert.That(door.ContainsPrize, Is.EqualTo(false));
        }
    }

    public class PrizeSelectorMock
    {
        private readonly int doorNumberThatHoldsPrize;

        public PrizeSelectorMock(int doorNumberThatHoldsPrize)
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
        private readonly PrizeSelectorMock prizeSelector;

        public MontyHall()
        {
            
        }

        public MontyHall(PrizeSelectorMock prizeSelector)
        {
            this.prizeSelector = prizeSelector;
        }

        public Door Door1 { get; private set; } = new Door(1, false);
        public Door Door2 { get; private set; } = new Door(2, false);
        public Door Door3 { get; private set; } = new Door(3, false);

        public IEnumerable<Door> Doors()
        {
            yield return Door1;
            yield return Door2;
            yield return Door3;
        }

        public void DefineWinner()
        {
            Door1 = new Door(1, true);
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