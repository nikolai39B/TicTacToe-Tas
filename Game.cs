using System;


namespace TicTacToe
{

	public class Game
	{

		public Game()
		{

			TicTacToeBoard = new Board(3, 3);

		}

		public void AddPiece(char piece)
		{
			bool validSpace = false;
			int placement = 0;
			Console.Write("Where would you like to add a piece? (value 1-9) ");
			

			while (!validSpace)
			{
				string userIn = Console.ReadLine();
				placement = Int32.Parse(userIn);

				if (TicTacToeBoard.IsPiece(((placement - 1) / 3), ((placement - 1) % 3)))
				{
					Console.Write("Error: There is already a piece in {0}, {0} ", (placement % 3), (placement - (placement % 3)));

				} 
				else 
				{
					validSpace = true;

				}

			}
			TicTacToeBoard.AddPiece(((placement - 1) / 3), ((placement - 1) % 3), piece);
		}

		
		// Checks the status of the Game (right now only if the board is fully populated)
		// If the Board is full, then this will return false, otherwise returns positive
		public bool GameStatus() 
		{
			if (TicTacToeBoard.GetNumPieces() == 9)
			{
				return false;
			}
			else 
			{
				return true;
			}
		}
		

		public Board TicTacToeBoard { get ; private set ; }

	}

}

