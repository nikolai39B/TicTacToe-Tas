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
        private bool gameStatus = false;  // Tracks whether the status of the game is incomplete (false) or complete (true)
        private int numPieces = 0;        // Tracks the number of pieces on the board at any given time
        private int numSpaces = 0;        // Determines maximum number of pieces on the board (due to Board object having possible unusual dimensions)

        //=============//
        // Constructor //
        //=============//
        public Board(int rows, int cols)
        {
            Pieces = new char[rows, cols];
            numSpaces = rows * cols;
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
            numPieces++;
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
            numPieces = 0;
            gameStatus = false;
        }



        // Checks the pieces present in the board to determine gameStatus, returning the Status
        public bool GameStatus()
        {
            if (numPieces == numSpaces) 
            {
                gameStatus = true;
                return true;
            }

            // Begins checking possibilities for a winning combination of pieces 

            for (int i = 0; i < NumRows && gameStatus == false; i++)
            {
                char currentRowPiece = Pieces[i, 0];
                
                for (int ii = 0; ii < NumCols; ii++)
                {
                    char currentColPiece = Pieces[i, ii];
                    if (currentRowPiece != currentColPiece)
                    {
                        break;
                    }
                }


            }



            return gameStatus;
        }

        //============//
        // Properties //
        //============//
        public char[,] Pieces { get; private set; }
        public int NumRows { get { return Pieces.GetLength(0); } }
        public int NumCols { get { return Pieces.GetLength(1); } }
    }
}
