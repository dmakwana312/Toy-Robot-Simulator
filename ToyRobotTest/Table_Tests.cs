using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
namespace ToyRobotTest
{
    [TestClass]
    public class Table_Tests
    {

        private Table table;

        // Create Table object to be used in all tests
        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            table = new Table(5, 5);
        }

        // Test isValidPosition returning true when parameters are for a valid position
        [TestMethod]
        public void Test_IsValidPosition_Where_New_Position_Is_Valid_Should_Return_True()
        {

            // Act 
            bool actualValue = table.IsValidPosition(2, 2);

            // Assert
            Assert.IsTrue(actualValue);
        }

        // Test isValidPosition returning false when moving north and y coordinate is invalidate
        [TestMethod]
        public void Test_IsValidPosition_Moving_North_Where_New_Position_Is_Invalid_Should_Return_False()
        {

            // Act 
            bool actualValue = table.IsValidPosition(2, 5);

            // Assert
            Assert.IsFalse(actualValue);
        }

        // Test isValidPosition returning false when moving east and x coordinate is invalidate
        [TestMethod]
        public void Test_IsValidPosition_Moving_East_Where_New_Position_Is_Invalid_Should_Return_False()
        {

            // Act 
            bool actualValue = table.IsValidPosition(5, 3);

            // Assert
            Assert.IsFalse(actualValue);
        }

        // Test isValidPosition returning false when moving south and y coordinate is invalidate
        [TestMethod]
        public void Test_IsValidPosition_Moving_South_Where_New_Position_Is_Invalid_Should_Return_False()
        {

            // Act 
            bool actualValue = table.IsValidPosition(2, -1);

            // Assert
            Assert.IsFalse(actualValue);
        }

        // Test isValidPosition returning false when moving west and x coordinate is invalidate
        [TestMethod]
        public void Test_IsValidPosition_Moving_West_Where_New_Position_Is_Invalid_Should_Return_False()
        {

            // Act 
            bool actualValue = table.IsValidPosition(-1, 2);

            // Assert
            Assert.IsFalse(actualValue);
        }

    }
}
