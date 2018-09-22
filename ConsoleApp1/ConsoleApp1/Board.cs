using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {
		public int Ver = 10;
		public int Hor = 10;
        private List<Square> board = new List<Square>();
        private List<Boat> boats = new List<Boat>();

        public Board()
        {
            for (int i = 0; i < Ver; i++)
            {
                for (int u = 0; u < Hor; u++)
                {
					board.Add(new Square
					{
						Pos = new List<int>() {i,u}
					});
                }
            }
        }

        public List<Square> getBoard()
        {
            return board;
        }

		public void updateBoard(List<Square> updatedBoard) {
			board = updatedBoard;
		}

		public void printBoard() {
			Console.Write("\n");
			for (int p = 1; p < Ver*Hor+1; p++)
			{
				if (board[p-1].state == 1)
				{
					Console.BackgroundColor = ConsoleColor.White;
				}
                if (board[p-1].Overlay == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                if (board[p - 1].state == 1 && board[p - 1].Overlay == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }

                Console.Write("_|");
				Console.ResetColor();
				Console.Write("  ");

				if (p % Hor == 0)
				{
					Console.Write("\n\n");
				}
			}
		}        
    }
}
