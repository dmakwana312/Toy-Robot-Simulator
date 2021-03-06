﻿namespace ToyRobot
{
    public class Table
    {
        // Height & width of table
        private int height, width;

        // Constructor to create table
        public Table(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        // Check if position is valid
        public bool IsValidPosition(int xPosition, int yPosition)
        {

            // If coordinates are outside of boundary of table, return false
            if (xPosition < 0 || xPosition >= width || yPosition < 0 || yPosition >= height)
            {
                return false;
            }
            return true;
        }

    }
}
