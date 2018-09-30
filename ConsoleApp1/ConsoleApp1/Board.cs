using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {
		public int ver;
		public int hor;
        private List<Square> board = new List<Square>();
        private int type = 0;
        public List<Boat> Boats = new List<Boat>();

        public Board(int vertical = 10, int horizontal = 10)
        {
            ver = vertical;
            hor = horizontal;

            for (int i = 0; i < ver; i++)
            {
                for (int u = 0; u < hor; u++)
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
            for (int p = 1; p <= ver*hor; p++)
			{
                if (type == 0)
                {
                    if (board[p - 1].state == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (board[p - 1].Overlay == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    if (board[p - 1].state == 1 && board[p - 1].Overlay == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                }
                else
                {
                    if (board[p - 1].state == (int)Square_state.waterHit)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    if (board[p - 1].state == (int)Square_state.boatHit)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    if (board[p - 1].Overlay == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                }

                Console.Write("_|");
				Console.ResetColor();
				Console.Write("  ");

				if (p % hor == 0)
				{
					Console.Write("\n\n");
				}
			}
		}

        public void printAttackBoard(Board ownBoard)
        {

        }

        public bool checkWin()
        {
            for (int p = 1; p < ver * hor + 1; p++)
            {
                if (board[p - 1].state == (int)Square_state.occupied) return false;
            }
            return true;
        }
        
        public void nextPhase()
        {
            type++;
        }
    }
}
