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

                        foreach (var square in board)
                        {
                            if ((board[p - 1].Pos[0] - 1 == square.Pos[0] && board[p - 1].Pos[1] == square.Pos[1] && board[p - 1].Pos[0] - 1 >= 0) || (board[p - 1].Pos[0] + 1 == square.Pos[0] && board[p - 1].Pos[1] == square.Pos[1] && board[p - 1].Pos[0] + 1 <= this.getSize()[0]) || (board[p - 1].Pos[0] == square.Pos[0] && board[p - 1].Pos[1] - 1 == square.Pos[1] && board[p - 1].Pos[1] - 1 >= 0) || (board[p - 1].Pos[0] == square.Pos[0] && board[p - 1].Pos[1] + 1 == square.Pos[1] && board[p - 1].Pos[1] + 1 <= this.getSize()[1]))
                            {
                                if (square.state == (int)Square_state.occupied)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                }
                            }
                        }
                    }
                    if (board[p - 1].state == 1 && board[p - 1].Overlay == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }



                    /*foreach (var square in squares)
                    {
                        foreach (var boardSquare in boardSquares)
                        {
                            if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                            {
                                if (boardSquare.state == 1) err++;
                            }
                            if (square.Pos[0] - 1 == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1] && square.Pos[0] - 1 >= 0)
                            {
                                if (boardSquare.state == 1) err++;
                            }
                            if (square.Pos[0] + 1 == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1] && square.Pos[0] + 1 <= gameBoard.getSize()[0])
                            {
                                if (boardSquare.state == 1) err++;
                            }
                            if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] - 1 == boardSquare.Pos[1] && square.Pos[1] - 1 >= 0)
                            {
                                if (boardSquare.state == 1) err++;
                            }
                            if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] + 1 == boardSquare.Pos[1] && square.Pos[1] + 1 <= gameBoard.getSize()[1])
                            {
                                if (boardSquare.state == 1) err++;
                            }
                        }
                    }*/
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

        public List<int> getSize()
        {
            return new List<int>() { ver, hor };
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
