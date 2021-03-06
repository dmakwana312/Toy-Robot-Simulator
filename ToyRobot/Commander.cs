﻿using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Commander
    {
        // Table, list of commands and robot
        private Table table;
        private string[] commands;
        private Robot toy;

        // Check if toy has been placed
        private bool toyPlaced;

        // Regex patterns for commands
        private const string placePattern = @"\bPLACE [0-4],[0-4],(NORTH|EAST|WEST|SOUTH)$";
        private const string movePattern = @"\bMOVE$";
        private const string leftPattern = @"\bLEFT$";
        private const string rightPattern = @"\bRIGHT$";
        private const string reportPattern = @"\bREPORT$";



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

            foreach (string command in commands)
            {

                if (Regex.IsMatch(command, placePattern))
                {
                    Place(command);
                }
                else if (Regex.IsMatch(command, movePattern) || Regex.IsMatch(command, leftPattern) || (Regex.IsMatch(command, rightPattern)))
                {
                    MoveRobot(command);
                }
                else if (Regex.IsMatch(command, reportPattern))
                {
                    Console.WriteLine(Report());
                }
                else
                {
                    throw new InvalidCommandException("Command Format Is Invalid");
                }
            }



        }

        // Place robot
        public void Place(string command)
        {
            // Split command into array
            string[] splitCommand = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Variables to store parameters of place command
            int x;
            int y;
            FacingDirection facingDirection;

            // Parse to correct to data type
            bool xSet = Int32.TryParse(splitCommand[1], out x);
            bool ySet = Int32.TryParse(splitCommand[2], out y);
            bool facingDirectionSet = Enum.TryParse(splitCommand[3], true, out facingDirection);

            // If attributes are set, place robot
            if (xSet && ySet && facingDirectionSet)
            {

                if (table.IsValidPosition(x, y))
                {
                    toy = new Robot(x, y, facingDirection);
                    toyPlaced = true;
                }
            }

        }

        // Move robot
        public void MoveRobot(string movement)
        {
            // If Toy is placed, run correct command
            if (toyPlaced)
            {
                switch (movement)
                {
                    case "MOVE":
                        // If it is possible to robot in direction faced, move
                        if (CheckIfMoveable())
                        {
                            toy.Move();
                        }
                        else
                        {
                            Console.WriteLine("Can't move further in this direction. Will fall off!");
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
            else
            {
                Console.WriteLine("Toy Robot Not Placed");
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

        // Get report of robot
        public string Report()
        {
            if (toyPlaced)
            {
                return toy.Report();
            }
            return "Toy Robot Not Placed";
        }

    }
}
