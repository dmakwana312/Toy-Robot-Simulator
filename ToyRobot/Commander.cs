using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Commander
    {
        // Table, list of commands and robot
        private Table table;
        private string[] commands;
        private Robot toy;

        private bool toyPlaced;

        // Constructor to set list of commands and create new table
        public Commander(string[] commands)
        {
            table = new Table(5, 5);
            this.commands = commands;

            toyPlaced = false;
        }

        // Start running commands
        public void StartRun()
        {

        }

        // Place robot
        public void Place(int x, int y, FacingDirection facingDirection)
        {
            if (table.IsValidPosition(x, y))
            {
                toy = new Robot(x, y, facingDirection);
                toyPlaced = true;
            }

        }

        // Move robot
        public void MoveRobot(string movement)
        {
            if (toyPlaced)
            {
                switch (movement)
                {
                    case "MOVE":
                        if (CheckIfMoveable())
                        {
                            toy.Move();
                        }
                        break;
                    case "RIGHT":
                        toy.Turn(TurnDirection.RIGHT);
                        break;
                    case "LEFT":
                        toy.Turn(TurnDirection.LEFT);
                        break;
                }
            }

        }

        // Check if move
        private bool CheckIfMoveable()
        {

            int movementUnits = toy.getMovementUnits();

            switch (toy.GetFacingDirection())
            {
                case FacingDirection.NORTH:
                    return table.IsValidPosition(toy.getX(), toy.getY() + movementUnits);
                case FacingDirection.SOUTH:
                    return table.IsValidPosition(toy.getX(), toy.getY() - movementUnits);
                case FacingDirection.WEST:
                    return table.IsValidPosition(toy.getX() - movementUnits, toy.getY());
                case FacingDirection.EAST:
                    return table.IsValidPosition(toy.getX() + movementUnits, toy.getY());
                default:
                    return false;
            }
        }

        public string Report()
        {
            if (toyPlaced)
            {
                return toy.Report();
            }
            else
            {
                return "No Toy Placed";
            }
        }

    }
}
