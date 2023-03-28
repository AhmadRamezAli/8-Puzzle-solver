using System;

using System.Collections.Generic;
using System.Text;

namespace PuzzleApp
{
    public class State
    {
        public int[,] board; // 2D array to store the puzzle board

        public int[,] Board { get => board; set => board = value; }


        // Constructor that initializes the board with the given 2D array
        public State(int[,] initialBoard)
        {
            board = (int[,])initialBoard.Clone();
        }


        public State()
        {
            board = new int[3, 3];
        }
        // Returns the value at a given row and column
        public int GetValueAt(int row, int col)
        {
            return board[row, col];
        }

        // Returns the row and column indices of a given value
        public Tuple<int, int> GetIndicesOf(int value)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == value)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return null; // value not found
        }

        // Returns a new state with the given value swapped with the blank tile
        public State GetNextState(int value)
        {
            Tuple<int, int> valueIndices = GetIndicesOf(value);
            Tuple<int, int> blankIndices = GetIndicesOf(0); // get the indices of the blank tile
            int[,] newBoard = (int[,])board.Clone(); // create a new board with the same values as the current board
            newBoard[valueIndices.Item1, valueIndices.Item2] = 0; // swap the value with the blank tile
            newBoard[blankIndices.Item1, blankIndices.Item2] = value;
            return new State(newBoard);
        }

        // Returns whether the state is the goal state
        public bool IsGoalState()
        {
            int[,] goalBoard = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }; // the goal state
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != goalBoard[i, j])
                    {
                        return false; // the state is not the goal state
                    }
                }
            }
            return true; // the state is the goal state
        }

        // Prints the state in a 3x3 grid
        public void Print()
        {
          
          
        }


        // This method checks if this node is equal to another object.
        // Two nodes are considered equal if they have the same hash code.
        // This method is used to check if a node has already been visited.
        public override bool Equals(object obj)
        {
            // Call the GetHashCode method to get the hash code of this node
            // and compare it with the hash code of the other object.
            // If they are equal, return true, indicating that the objects are equal.
            return (this.GetHashCode() == obj.GetHashCode());
        }


        // This method generates a hash code for the current state object.
        // The hash code is calculated by concatenating the digits of the puzzle board
        // from left to right and top to bottom, treating them as a single integer.
        // The hash code is used to check if a node has already been visited.
        public override int GetHashCode()
        {
            int hash = 0;    // Initialize the hash code to zero
            int power = 1;   // Initialize the power of 10 to 1

            // Loop through all elements of the puzzle board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Add the current board element multiplied by the power of 10 to the hash code
                    hash += board[i, j] * power;

                    // Increase the power of 10 to move to the next digit
                    power *= 10;
                }
            }

            // Return the hash code
            return hash;
        }

    }
}
