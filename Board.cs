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

            // Begins checking possibilities for a winning combination of pieces (Column Portions)

            for (int i = 0; i < NumRows && !gameStatus; i++)
            {
                char currentRowPiece = Pieces[i, 0];                            // Holds current value of the Row Piece
                
                for (int ii = 0; ii < NumCols && !gameStatus; ii++)
                {
                    char currentColPiece = Pieces[i, ii];                       // Holds current value of the Column Piece

                    if (currentRowPiece != currentColPiece)                     // Compares Row and Column Pieces 
                    {                                                           // If Row != Column, winning is impossible, thus breaking loop checking
                        break;
                    }

                    if (ii == NumCols && currentColPiece == currentRowPiece)    // Claims that if the ii variable (tracking column position) is in the final position in the column  
                    {                                                           // And that the loop has not yet broken, AND the final character is equivalent to the inital character
                        gameStatus = true;                                      // There is a Winner, breaking out of both loops and returning the gameStatus Variable
                    }
                
                }

            }

            // Performs same function as the first grouping of nested for loops, but for the Row Pieces

            for (int i = 0; i < NumCols && !gameStatus; i++)
            {
                char currentRowPiece = Pieces[0, i];                            

                for (int ii = 0; ii < NumRows && !gameStatus; ii++)
                {
                    char currentColPiece = Pieces[ii, i];                       

                    if (currentRowPiece != currentColPiece)                    
                    {                                                          
                        break;
                    }

                    if (ii == NumCols && currentColPiece == currentRowPiece)      
                    {                                                          
                        gameStatus = true;                                     
                    }
                
                }
            
            }

            for (int i = 0; i < NumRows && !gameStatus; i++) 
            {
                char currentPiece = Pieces[i, i];
               
                for (int ii = 0; ii < NumCols && !gameStatus; ii++) 
                {
                    char comparingPiece = Pieces[ii, ii];

                    if (currentPiece != comparingPiece)
                    {
                        break;
                    }

                    if (ii == NumCols && currentPiece == comparingPiece)
                    {
                        gameStatus = true;
                    }

                }

            }

            for (int i = NumRows; i < NumRows && !gameStatus; i--)
            {
                char currentPiece = Pieces[i, i];

                for (int ii = NumCols; ii < NumCols && !gameStatus; ii--)
                {
                    char comparingPiece = Pieces[ii, ii];

                    if (currentPiece != comparingPiece)
                    {
                        break;
                    }

                    if (ii == 0 && currentPiece == comparingPiece)
                    {
                        gameStatus = true;
                    }

                }

            }

            // Extremely disgusting checking for Tic-Tac-Toe boards with dimensions of 3x3
            /*
            if (Pieces[0, 0].Equals(Pieces[0, 1].Equals(Pieces[0, 2])) ||
                Pieces[1, 0].Equals(Pieces[1, 1].Equals(Pieces[1, 2])) ||
                Pieces[2, 0].Equals(Pieces[2, 1].Equals(Pieces[2, 2])) ||
                Pieces[0, 0].Equals(Pieces[1, 1].Equals(Pieces[2, 2])) ||
                Pieces[2, 0].Equals(Pieces[1, 1].Equals(Pieces[0, 2])) ||
                )
            {
                gameStatus = true;
            }
            */

            if (!gameStatus && (numPieces == numSpaces))                        // Checks whether or not the method has gone through all other loops,
            {                                                                   // If this is true, and the Board is totally filled, the statement 
                gameStatus = true;                                              // Changes the gameStatus to true, ending the game
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
