using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Boat
	{
		protected List<Square> squares = new List<Square>();
		private List<Square> boardSquares = new List<Square>();
		private List<Square> immune = new List<Square>();
		private int rotated = 0;
		protected int width;
		
        public List<Square> markBoat(Board gameBoard, int state = 0)
        {
            List<Square> boardSquares = gameBoard.getBoard();

			foreach (var square in squares)
			{
                int indexCounter = 0;
				foreach (var boardSquare in boardSquares)
				{
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                    {
                        if (state == 0)
                        {
                            boardSquare.Overlay = 1;
                        }
                        else
                        {
                            boardSquare.Overlay = 0;
                        }
                        immune.Add(boardSquare);
                    }
                    else
                    {
                        if (immune.Contains(boardSquare) == false)
                        {
                            boardSquare.Overlay = 0;
                        }
                    }
                    indexCounter++;
                }
			}

			immune.Clear();

			return boardSquares;
        }

        public int getWidth()
        {
            return width;
        }

        public bool placeBoat(Board gameBoard) {
            List<Square> boardSquares = gameBoard.getBoard();
            int err = 0;

            foreach (var square in squares)
            {
                foreach (var boardSquare in boardSquares)
                {
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                    {
                        if (boardSquare.state == Square_state.occupied) err++;
                    }
                    if (square.Pos[0] - 1 == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1] && square.Pos[0] - 1 >= 0)
                    {
                        if (boardSquare.state == Square_state.occupied) err++;
                    }
                    if (square.Pos[0] + 1 == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1] && square.Pos[0] + 1 <= gameBoard.getSize()[0])
                    {
                        if (boardSquare.state == Square_state.occupied) err++;
                    }
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] - 1 == boardSquare.Pos[1] && square.Pos[1] - 1 >= 0)
                    {
                        if (boardSquare.state == Square_state.occupied) err++;
                    }
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] + 1 == boardSquare.Pos[1] && square.Pos[1] + 1 <= gameBoard.getSize()[1])
                    {
                        if (boardSquare.state == Square_state.occupied) err++;
                    }
                }
            }

            if (err == 0)
            {
                foreach (var square in squares)
                {
                    foreach (var boardSquare in boardSquares)
                    {
                        if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                        {
                            boardSquare.state = Square_state.occupied;
                            boardSquare.OccupiedBy = this;
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("An error occured while placing the boat.");
                return false;
            }

        }

		public void checkCollision(Board gameBoard, Square square) {
			int ver = gameBoard.ver;
			int hor = gameBoard.hor;
			int? direction = null;

			if (square.Pos[0] < 0)
			{
				direction = 1;
			}
			if (square.Pos[1] < 0)
			{
				direction = 0;
			}
			if (square.Pos[0] > ver - 1)
			{
				direction = 3;
			}
			if (square.Pos[1] > hor - 1)
			{
				direction = 2;
			}
			if (direction != null)
			{
				foreach (var oneSquare in squares)
				{
					switch (direction)
					{
						case 0:
							oneSquare.Pos[1]++;
							break;
						case 1:
							oneSquare.Pos[0]++;
							break;
						case 2:
							oneSquare.Pos[1]--;
							break;
						case 3:
							oneSquare.Pos[0]--;
							break;
					}
				}
			}
			

		}

		public List<Square> moveBoat(Board gameBoard, int direction)
		{
			foreach (var square in squares)
			{
				switch (direction)
				{
					case 0:
						square.Pos[1]++;
						break;
					case 1:
						square.Pos[0]++;
						break;
					case 2:
						square.Pos[1]--;
						break;
					case 3:
						square.Pos[0]--;
						break;
				}

				checkCollision(gameBoard, square);
			}

			return markBoat(gameBoard);
		}

		public List<Square> rotateBoat(Board gameBoard)
		{
            int counter = 0;
			int counterX = 0;
            int counterY = 0;
			int layer = 0;

			foreach (var square in squares)
            {
                layer = square.BoatPos[0];
                counter = square.BoatPos[1];
                counterX = -layer - counter;
                counterY = -layer + counter;
                
                switch (rotated)
				{
					case 0:
                        square.Pos[0] += counterY;
						square.Pos[1] += counterX;
                        break;
                    case 1:
                        if (layer == 0)
                        {
                            square.Pos[0] -= counterY;
                            square.Pos[1] += counterX;
                        }
                        else
                        {
                            square.Pos[0] += counterX;
                            square.Pos[1] -= counterY;
                        }
                        break;
                    case 2:
                        square.Pos[0] -= counterY;
                        square.Pos[1] -= counterX;
                        break;
                    case 3:
                        if (layer == 0)
                        {
                            square.Pos[0] += counterY;
                            square.Pos[1] -= counterX;
                        }
                        else
                        {
                            square.Pos[0] -= counterX;
                            square.Pos[1] += counterY;
                        }
                        break;
                }
                checkCollision(gameBoard, square);
			}
			rotated++;
			if (rotated >= 4) rotated = 0;
			
			return markBoat(gameBoard);
        }

        public int attack(Board gameBoard)
        {
            List<Square> boardSquares = gameBoard.getBoard();
            Square square = squares[0];
            foreach (var boardSquare in boardSquares)
            {
                if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                {
                    if (boardSquare.state == Square_state.occupied)
                    {
                        boardSquare.state = Square_state.boatHit;
                        return 1;
                    }
                    else if (boardSquare.state == Square_state.free)
                    {
                        boardSquare.state = Square_state.waterHit;
                        return 0;
                    }
                    else if (boardSquare.state == Square_state.waterHit || boardSquare.state == Square_state.boatHit)
                    {
                        return 2;
                    }
                }
            }
            return 2;
        }
    }


    class Simple_boat : Boat
    {
        public Simple_boat(int length)
        {
            width = length;
            for (int i = 0; i < length; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatPos = new List<int>() { 0, i },
                });
            }
        }
    }

    class Base_boat : Boat
    {
        public Base_boat(int length)
        {
            width = 3;
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatPos = new List<int>() { 0,i },
                });
            }
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatPos = new List<int>() { 1,u },
                });
            }
        }
    }

    class Hydroplane_boat : Boat
    {
        public Hydroplane_boat(int length)
        {
            width = 3;
            squares.Add(new Square
            {
                Pos = new List<int>() { 0, 1 },
                BoatPos = new List<int>() { 0, 1 },
            });
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 0 },
                BoatPos = new List<int>() { 1,0 }
            });
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 2 },
                BoatPos = new List<int>() { 1,2 }
            });
        }
    }

    class Cruiser_boat : Boat
    {
        public Cruiser_boat(int length)
        {
            width = 3;
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatPos = new List<int>() { 0,i }
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 1 },
                BoatPos = new List<int>() { 1,1 }
            });
        }
    }

    class HeavyCruiser_boat : Boat
    {
        public HeavyCruiser_boat(int length)
        {
            width = 3;
            squares.Add(new Square
            {
                Pos = new List<int>() { 0, 1 },
                BoatPos = new List<int>() { 0,1 }
            });
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatPos = new List<int>() { 1,u }
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 2, 1 },
                BoatPos = new List<int>() { 2,1 }
            });
        }
    }

    class Catamaran_boat : Boat
    {
        public Catamaran_boat(int length)
        {
            width = 3;
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, u },
                    BoatPos = new List<int>() { 0,u }
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 1 },
                BoatPos = new List<int>() { 1,1 }
            });
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 2, i },
                    BoatPos = new List<int>() { 2,i }
                });
            }
        }
    }

    class Warship_boat : Boat
    {
        public Warship_boat(int length)
        {
            width = 2;
            for (int i = 0; i < 2; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatPos = new List<int>() { 0,i }
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 0 },
                BoatPos = new List<int>() { 1,0 }
            });
        }
    }

    class Planeship_boat : Boat
    {
        public Planeship_boat(int length)
        {
            width = 4;
            for (int i = 0; i < 4; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatPos = new List<int>() { 0,i }
                });
            }
            for (int u = 0; u < 2; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatPos = new List<int>() { 1,u }
                });
            }
        }
    }
}
