
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTest
{
    [TestClass]
    public class Commander_Tests
    {

        private Commander commander;
        // Create Commander object to be used in some tests
        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            commander = new Commander(new string[] { "PLACE 1,2,EAST" });
            commander.StartRun();
        }

        // Test StartRun Method When Place Command Format Is Invalid
        [TestMethod]
        public void Test_StartRun_Where_Command_Is_Invalid_Should_Raise_InvalidCommandException()
        {
            // Arrange
            Commander commander = new Commander(new string[] { "Place" });

            try
            {
                // Act
                commander.StartRun();

                // Assert
                Assert.Fail();
            }
            catch (InvalidCommandException)
            {
                // Assert
                Assert.IsTrue(true);
            }

        }

        // Test Place Method When Paramter Format Is Valid
        [TestMethod]
        public void Test_Place_Where_Paramter_Is_Valid_Should_Create_Robot_Object()
        {
            // Arrange
            commander = new Commander(new string[] { });
            string command = "PLACE 1,2,EAST";
            string expectedReport = "Position: (1, 2) - Facing: EAST";

            // Act
            commander.Place(command);
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

        // Test MoveRobot Method Where Paramter Is MOVE
        [TestMethod]
        public void Test_MoveRobot_Where_Paramter_Is_Move_Should_Move_Robot()
        {
            // Arrange
            string expectedReport = "Position: (2, 2) - Facing: EAST";

            // Act
            commander.MoveRobot("MOVE");
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

        // Test MoveRobot Method Where Paramter Is RIGHT
        [TestMethod]
        public void Test_MoveRobot_Where_Paramter_Is_Right_Should_Turn_Robot_Right()
        {
            // Arrange
            string expectedReport = "Position: (1, 2) - Facing: SOUTH";

            // Act
            commander.MoveRobot("RIGHT");
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

        // Test MoveRobot Method Where Paramter Is LEFT
        [TestMethod]
        public void Test_MoveRobot_Where_Paramter_Is_LEFT_Should_Turn_Robot_Right()
        {
            // Arrange
            string expectedReport = "Position: (1, 2) - Facing: NORTH";

            // Act
            commander.MoveRobot("LEFT");
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

        // Test Report Method Where Robot Is Not Placed
        [TestMethod]
        public void Test_Report_Where_Robot_Is_Not_Placed_Should_Return_Error_Message_String()
        {
            // Arrange
            commander = new Commander(new string[] { });
            string expectedReport = "Toy Robot Not Placed";

            // Act
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

        // Test Report Method Where Robot Is Placed
        [TestMethod]
        public void Test_Report_Where_Robot_Is_Placed_Should_Return_String()
        {
            // Arrange
            string expectedReport = "Position: (1, 2) - Facing: EAST"; ;

            // Act
            string actualReport = commander.Report();

            // Assert
            Assert.AreEqual(expectedReport, actualReport);

        }

    }
}
