using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        public bool gameStatus = false;  // Tracks whether the status of the game is incomplete (false) or complete (true)
        
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

        
        // Clears Board for a New Game
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



        // Checks the pieces present in the board to determine gameStatus, returning the Status
        public bool GameStatus()
        { 
        
        }

        //============//
        // Properties //
        //============//
        public char[,] Pieces { get; private set; }
        public int NumRows { get { return Pieces.GetLength(0); } }
        public int NumCols { get { return Pieces.GetLength(1); } }
    }
}
