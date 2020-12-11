using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Robot
    {

        // Position
        private int x, y;

        // Direction the robot is facing
        private FacingDirection facingDirection;

        // Number of units to move
        private const int moveUnits = 1;

        // Constructor to set properties of robot
        public Robot(int x, int y, FacingDirection facingDirection)
        {
            this.x = x;
            this.y = y;
            this.facingDirection = facingDirection;
        }

        // Move robot based on direction it faces
        public void Move()
        {
            switch (facingDirection)
            {
                case FacingDirection.NORTH:
                    y += moveUnits;
                    break;
                case FacingDirection.SOUTH:
                    y -= moveUnits;
                    break;
                case FacingDirection.WEST:
                    x -= moveUnits;
                    break;
                case FacingDirection.EAST:
                    x += moveUnits;
                    break;
            }
        }

        // Turn robot based on paramter
        public void Turn(TurnDirection turnDirection)
        {
            switch (turnDirection)
            {
                case TurnDirection.LEFT:
                    facingDirection = (facingDirection == FacingDirection.NORTH ? FacingDirection.WEST : (FacingDirection)((int)facingDirection - 1));
                    break;
                case TurnDirection.RIGHT:
                    facingDirection = (facingDirection == FacingDirection.WEST ? FacingDirection.NORTH : (FacingDirection)((int)facingDirection + 1));
                    break;

            }
        }

              

    }



}
