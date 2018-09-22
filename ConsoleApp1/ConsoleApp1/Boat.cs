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

		private int width = 4;
		private int height = 2;

		public Boat()
		{
            
			//if space between(even on first and last square in layer) squares in layer then counter += numOfSpaces 
		}
		
        public List<Square> markBoat(Board gameBoard)
        {
            List<Square> boardSquares = gameBoard.getBoard();

			foreach (var square in squares)
			{
                int indexCounter = 0;
				foreach (var boardSquare in boardSquares)
				{
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                    {
                        /*Console.Write("hor: " + gameBoard.Hor);
                        Console.Write(" ver: " + gameBoard.Ver);
                        Console.Write(" index: " + indexCounter);
                        Console.Write("\n");
                        if ((indexCounter + 1) % gameBoard.Hor != 0 && (indexCounter) % (gameBoard.Hor) != 0 && indexCounter > gameBoard.Hor && indexCounter < gameBoard.Hor * (gameBoard.Ver - 1))
                        {
                            List<Square> layer = gameBoard.getSquareLayer(indexCounter);
                            foreach (var item in layer)
                            {
                                Console.Write("   " + item.Pos[0] + ", " + item.Pos[1] + " // " + item.state + "\n");
                            }
                        }
                        //List<Square> layer = gameBoard.getSquareLayer(indexCounter);
                        Console.Write("\n");*/

                        boardSquare.Overlay = 1;
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

        public List<Square> placeBoat(Board gameBoard) {
            List<Square> boardSquares = gameBoard.getBoard();
            int err = 0;

            foreach (var square in squares)
            {
                foreach (var boardSquare in boardSquares)
                {
                    if (square.Pos[0] == boardSquare.Pos[0] && square.Pos[1] == boardSquare.Pos[1])
                    {
                        if (boardSquare.state == 1) err++;
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
                            if (err == 0)
                            {
                                boardSquare.state = 1;
                                boardSquare.OccupiedBy = this;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("An error occured while placing the boat.");
            }

            return boardSquares;
        }

		public void checkCollision(Board gameBoard, Square square) {
			int ver = gameBoard.Ver;
			int hor = gameBoard.Hor;
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


                /*Console.WriteLine("counterX: " + counterX);
                Console.WriteLine("counterY: " + counterY);
                Console.WriteLine("counter: " + counter);
                Console.WriteLine("pos X: " + square.Pos[1]);
                Console.WriteLine("layer: " + layer);
                Console.WriteLine("pos Y: " + square.Pos[0]);
                Console.WriteLine("+");*/
                if (counterX != square.BoatIndex)
                {
                    counter = square.BoatIndex;
                    counterX = counter - layer;
                    if (counter == 0)
                    {
                        counter = 0;
                        layer++;
                        counterX = -layer;
                        counterY = -layer;
                    }
                }

                Console.WriteLine("counterX: " + counterX);
                Console.WriteLine("counterY: " + counterY);
                Console.WriteLine("counter: " + counter);
                Console.WriteLine("pos X: " + square.Pos[1]);
                Console.WriteLine("layer: " + layer);
                Console.WriteLine("pos Y: " + square.Pos[0]);
                Console.WriteLine("after:");
                switch (rotated)
				{
					case 0:
                        square.Pos[0] += counterY;
						square.Pos[1] -= counterX;
                        Console.WriteLine("pos X: " + square.Pos[1]);
                        Console.WriteLine("pos Y: " + square.Pos[0]);
                        Console.WriteLine("after:");
                        break;
                        /*case 1:
                            square.Pos[0] -= counter;
                            square.Pos[1] -= counter;
                            if (layer == 2) square.Pos[1] += 1;
                            if (layer == 2) square.Pos[0] -= 1;
                            break;
                        case 2:
                            square.Pos[0] -= counter;
                            square.Pos[1] += counter;
                            if (layer == 2) square.Pos[0] += 1;
                            if (layer == 2) square.Pos[1] += 1;
                            break;
                        case 3:
                            square.Pos[0] += counter;
                            square.Pos[1] += counter;
                            if (layer == 2) square.Pos[1] -= 1;
                            if (layer == 2) square.Pos[0] += 1;
                            break;*/
                }
                Console.WriteLine("pos X: " + square.Pos[1]);
                Console.WriteLine("pos Y: " + square.Pos[0]);
                Console.WriteLine();

                if (counter < 3)
                {
                    counter++;
                    counterX--;
                    counterY++;
                }
                else
                {
                    counter = 0;
                    layer++;
                    counterX = -layer;
                    counterY = -layer;
                }
			}

			rotated++;
			if (rotated >= 4) rotated = 0;
			
			return markBoat(gameBoard);
		}
	}


    class Simple_boat : Boat
    {
        public Simple_boat(int length)
        {
            for (int i = 0; i < length; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatIndex = i,//BoatIndex => BoatPos[1] ...
                });
            }
        }
    }

    class Base_boat : Boat
    {
        public Base_boat(int length)
        {
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatIndex = i,
                });
            }
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatIndex = u,
                });
            }
        }
    }

    class Hydroplane_boat : Boat
    {
        public Hydroplane_boat(int length)
        {
            squares.Add(new Square
            {
                Pos = new List<int>() { 0, 1 },
                BoatIndex = 1,
            });
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 0 },
                BoatIndex = 0,
            });
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 2 },
                BoatIndex = 2,
            });
        }
    }

    class Cruiser_boat : Boat
    {
        public Cruiser_boat(int length)
        {
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatIndex = i,
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 0, 1 },
                BoatIndex = 1,
            });
        }
    }

    class HeavyCruiser_boat : Boat
    {
        public HeavyCruiser_boat(int length)
        {
            squares.Add(new Square
            {
                Pos = new List<int>() { 0, 1 },
                BoatIndex = 1,
            });
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatIndex = u,
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 2, 1 },
                BoatIndex = 1,
            });
        }
    }

    class Catamaran_boat : Boat
    {
        public Catamaran_boat(int length)
        {
            for (int u = 0; u < 3; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, u },
                    BoatIndex = u,
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 1 },
                BoatIndex = 1,
            });
            for (int i = 0; i < 3; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 2, i },
                    BoatIndex = i,
                });
            }
        }
    }

    class Warship_boat : Boat
    {
        public Warship_boat(int length)
        {
            for (int i = 0; i < 2; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatIndex = i,
                });
            }
            squares.Add(new Square
            {
                Pos = new List<int>() { 1, 0 },
                BoatIndex = 0,
            });
        }
    }

    class Planeship_boat : Boat
    {
        public Planeship_boat(int length)
        {
            for (int i = 0; i < 4; i++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 0, i },
                    BoatIndex = i,
                });
            }
            for (int u = 0; u < 2; u++)
            {
                squares.Add(new Square
                {
                    Pos = new List<int>() { 1, u },
                    BoatIndex = u,
                });
            }
        }
    }
}
