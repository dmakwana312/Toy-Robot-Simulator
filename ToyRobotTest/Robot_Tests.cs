using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
namespace ToyRobotTest
{
    [TestClass]
    public class Robot_Tests
    {

        // Test Moving Robot North
        [TestMethod]
        public void Test_Moving_Robot_North_Should_Increase_y_Coordinate()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.NORTH);
            int expectedYValue = 4;

            // Act 
            robot.Move();

            // Assert
            Assert.AreEqual(expectedYValue, robot.getY());
        }

        // Test Moving Robot South
        [TestMethod]
        public void Test_Moving_Robot_South_Should_Decrease_y_Coordinate()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.SOUTH);
            int expectedYValue = 2;

            // Act 
            robot.Move();

            // Assert
            Assert.AreEqual(expectedYValue, robot.getY());
        }

        // Test Moving Robot West
        [TestMethod]
        public void Test_Moving_Robot_West_Should_Decrease_x_Coordinate()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.WEST);
            int expectedYValue = 1;

            // Act 
            robot.Move();

            // Assert
            Assert.AreEqual(expectedYValue, robot.getX());
        }

        // Test Moving Robot East
        [TestMethod]
        public void Test_Moving_Robot_East_Should_Increase_x_Coordinate()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.EAST);
            int expectedYValue = 3;

            // Act 
            robot.Move();

            // Assert
            Assert.AreEqual(expectedYValue, robot.getX());
        }

        // Test Rotating Robot Left When Facing North (Edge Case)
        [TestMethod]
        public void Test_Turning_Robot_Left_When_Facing_North_Should_Make_Robot_Face_North()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.NORTH);
            FacingDirection expectedDirection = FacingDirection.WEST;

            // Act 
            robot.Turn(TurnDirection.LEFT);

            // Assert
            Assert.AreEqual(expectedDirection, robot.GetFacingDirection());
        }

        // Test Rotating Robot Right When Facing West (Edge Case)
        [TestMethod]
        public void Test_Turning_Robot_Right_When_Facing_Wes_Should_Make_Robot_Face_West()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.WEST);
            FacingDirection expectedDirection = FacingDirection.NORTH;

            // Act 
            robot.Turn(TurnDirection.RIGHT);

            // Assert
            Assert.AreEqual(expectedDirection, robot.GetFacingDirection());
        }

        // Test report function of robot
        [TestMethod]
        public void Test_Report_Robot_Position_And_Facing_Direction()
        {
            // Arrange
            Robot robot = new Robot(2, 3, FacingDirection.NORTH);
            string expectedReport = "Position: (2, 4) - Facing: NORTH";

            // Act 
            robot.Move();

            // Assert
            Assert.AreEqual(expectedReport, robot.Report());

        }


    }
}
