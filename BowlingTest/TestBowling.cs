using System;
using BowlingApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace BowlingTest
{
    [TestClass]
    public class TestBowling
    {
        [TestMethod, TestCategory("Bowling")]
        [Description("Check Bowling Perfect Score")]
        public void Test_Perfect_Score()
        {
            //Arrange
            IGame game = new Game();

            var rollings = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            foreach (int pins in rollings)
            {
                game.Roll(pins);
            }

            //Act
            var result = game.Score();

            //Assert
            var actual = result;
            var expected = 300;

            Console.WriteLine($@"Perfect Score: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Bowling")]
        [Description("Check Bowling Worst Score")]
        public void Test_Worst_Score()
        {
            //Arrange
            IGame game = new Game();

            var rollings = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach (int pins in rollings)
            {
                game.Roll(pins);
            }

            //Act
            var result = game.Score();

            //Assert
            var actual = result;
            var expected = 0;

            Console.WriteLine($@"Worst Score: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Bowling")]
        [Description("Check Bowling A Given Score")]
        public void Test_A_Given_Score()
        {
            //Arrange
            var game = new Game();

            var rollings = new List<int> { 3, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };

            foreach (int pins in rollings)
            {
                game.Roll(pins);
            }

            //Act
            var result = game.Score();

            //Assert
            var actual = result;
            var expected = 135;

            Console.WriteLine($@"A Given Score: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Bowling")]
        [Description("Check Bowling Last Strike Score")]
        public void Test_A_Last_Strike_Score()
        {
            //Arrange
            var game = new Game();

            var rollings = new List<int> { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 10, 10, 10 };

            foreach (int pins in rollings)
            {
                game.Roll(pins);
            }

            //Act
            var result = game.Score();

            //Assert
            var actual = result;
            var expected = 157;

            Console.WriteLine($@"Last Strike Score: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Bowling")]
        [Description("Check Bowling A Mock Example")]
        public void Test_A_MockExample()
        {
            //TODO: Need to enhance this test as this Test is only here to demonstrate the Mocking functionality

            //Arrange           
            var game = new Mock<IGame>();
            game.Setup(g => g.Score()).Returns(123);

            //Act
            var result = game.Object;

            //Assert
            var actual = result.Score();
            var expected = 123;

            Console.WriteLine($@"Mock Example: {actual}");
            Assert.AreEqual(expected, actual);
        }

    }
}
