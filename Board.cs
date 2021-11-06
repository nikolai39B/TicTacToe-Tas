using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {


        //=============//
        // Constructor //
        //=============//
        public Board(int rows, int cols)
        {
            Pieces = new char[rows, cols];
        }


        //===============//
        // Adding Pieces //
        //===============//
        public void AddPiece(int row, int col, char piece)
        {
            // Validate
            Debug.Assert(row < NumRows);
            Debug.Assert(col < NumCols);

            Pieces[row, col] = piece;

        }


        //==========//
        // Printing //
        //==========//
        public void PrintBoard()
        {
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    char piece = Pieces[row, col];
                    if (piece == '\0')
                    {
                        Console.Write(row < NumRows - 1 ? '_' : ' ');
                    }
                    else
                    {
                        Console.Write(piece);
                    }

                    // Print the wall unless we're on the last col
                    if (col < NumCols - 1)
                    {
                        Console.Write("|");
                    }
                }

                // Print newline
                Console.WriteLine();
            }
        }


        // Clears Board for a New Game,
        // Also resets numPieces counter and the gameStatus tracker
        public void ClearBoard()
        {
            for (int i = 0; i < NumRows; i++)
            {
                for (int ii = 0; ii < NumCols; ii++)
                {
                    Pieces[i, ii] = '\0';
                }
            }
        }

        public int GetNumPieces() {
            int numChars = 0;

            for (int rows = 0; rows < NumRows; rows++) 
            {
                for (int cols = 0; cols < NumCols; cols ++)
                {
                    if (Pieces[rows, cols] != '\0')
                    {
                        numChars++;
                    }
                }
            }

            return numChars;
        }

        public bool IsPiece(int row, int col)
        {
            if (Pieces[row, col] != '\0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //============//
        // Properties //
        //============//
        public char[,] Pieces { get; private set; }
        public int NumRows { get { return Pieces.GetLength(0); } }
        public int NumCols { get { return Pieces.GetLength(1); } }
        public int NumSpaces { get { return Pieces.GetLength(0) * Pieces.GetLength(1); } }        
    }
}
