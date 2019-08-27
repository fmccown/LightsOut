using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut
{
    class LightsOutGame
    {
        private bool[,] grid;                   // Stores on/off state of cells in grid
        private int numCells = 3;               // Number of cells in grid
        private Random rand;		            // Used to generate random numbers

        // Properties

        public int NumCells
        {
            get
            {
                return numCells;
            }

            set
            {
                // value is keyword
                if (value < 3 || value > 5)
                    numCells = 3;
                else
                    numCells = value;
            }
        }

        public LightsOutGame()
        {
            rand = new Random();    // Initializes random number generator
        }

        public void NewGame()
        {
            // TODO: Complete this method
            grid = new bool[numCells, numCells];

            // Fill grid with either white or black
            for (int r = 0; r < numCells; r++)
                for (int c = 0; c < numCells; c++)
                    grid[r, c] = rand.Next(2) == 1;
        }

        public void Move(int row, int col)
        {
            // Invert selected box and all surrounding boxes
            for (int i = row - 1; i <= row + 1; i++)
                for (int j = col - 1; j <= col + 1; j++)
                    if (i >= 0 && i < numCells && j >= 0 && j < numCells)
                        grid[i, j] = !grid[i, j];
        }

        public bool IsLightOn(int row, int col)
        {
            return grid[row, col];
        }

        public bool IsWinner()
        {
            for (int r = 0; r < numCells; r++)
                for (int c = 0; c < numCells; c++)
                    if (grid[r, c])
                        return false;

            return true;
        }
    }
}
