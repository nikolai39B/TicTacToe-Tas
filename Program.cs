using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Create a board
            Board board = new Board(3, 3);

            // Print the board
            board.PrintBoard();
            Console.WriteLine();

            board.AddPiece(0, 0, 'X');
            board.AddPiece(0, 2, 'O');
            board.AddPiece(1, 1, 'X');

            board.PrintBoard();
            Console.WriteLine(); 

            /*Console.WriteLine("Ay yo whatchu want");
            string userInput = Console.ReadLine();             Figuring out how to shit
            *

            board.ClearBoard();
            board.PrintBoard();
            Console.WriteLine();

            //Console.WriteLine(userInput);
            Console.ReadKey();
            */

            Game TTT = new Game();

            TTT.TicTacToeBoard.PrintBoard();
            char nextPlayer = 'X';

            while (TTT.GameStatus())
            {
                TTT.AddPiece(nextPlayer);
                if (nextPlayer == 'X')
                {
                    nextPlayer = 'O';
                }
                else if (nextPlayer == 'O')
                {
                    nextPlayer = 'X';
                }



                TTT.TicTacToeBoard.PrintBoard();

            }



            Console.ReadKey();
        }
    }
}
