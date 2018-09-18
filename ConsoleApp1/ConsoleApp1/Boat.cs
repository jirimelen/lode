using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Boat
	{
		private List<Square> squares = new List<Square>();
		private List<Square> boardSquares = new List<Square>();
		private List<Square> immune = new List<Square>();
		private int rotated = 0;

		public Boat()
        {
            for (int i = 0; i < 4; i++)
            {
                squares.Add(new Square
                {
					pos = new List<int>() { 0, i }
				});
            }
        }

        public List<Square> markBoat(Board gameBoard)
        {
            List<Square> boardSquares = gameBoard.getBoard();

			foreach (var square in squares)
			{
				foreach (var boardSquare in boardSquares)
				{
					if (square.pos[0] == boardSquare.pos[0] && square.pos[1] == boardSquare.pos[1])
					{
						boardSquare.Occupied = 1;
						boardSquare.occupiedBy = this;
						immune.Add(boardSquare);
					}
					else 
					{
						if (boardSquare.occupiedBy == this && immune.Contains(boardSquare) == false) {
							boardSquare.Occupied = 0;
							boardSquare.occupiedBy = null;
						}
					}

				}
			}

			immune.Clear();

			return boardSquares;
        }

		public void checkCollision(Board gameBoard, Square square) {
			int ver = gameBoard.Ver;
			int hor = gameBoard.Hor;
			int? direction = null;

			if (square.pos[0] < 0)
			{
				direction = 1;
			}
			if (square.pos[1] < 0)
			{
				direction = 0;
			}
			if (square.pos[0] > hor - 1)
			{
				direction = 3;
			}
			if (square.pos[1] > ver - 1)
			{
				direction = 2;
			}
			if (direction != null)
			Console.WriteLine(direction);
			{
				foreach (var oneSquare in squares)
				{
					switch (direction)
					{
						case 0:
							oneSquare.pos[1]++;
							break;
						case 1:
							oneSquare.pos[0]++;
							break;
						case 2:
							oneSquare.pos[1]--;
							break;
						case 3:
							oneSquare.pos[0]--;
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
						square.pos[1]++;
						break;
					case 1:
						square.pos[0]++;
						break;
					case 2:
						square.pos[1]--;
						break;
					case 3:
						square.pos[0]--;
						break;
				}

				checkCollision(gameBoard, square);
			}

			return markBoat(gameBoard);
		}

		public List<Square> rotateBoat(Board gameBoard)
		{
			int counter = 0;

			foreach (var square in squares)
			{

				switch (rotated)
				{
					case 0:
						square.pos[0] += counter;
						square.pos[1] -= counter;
						break;
					case 1:
						square.pos[0] -= counter;
						square.pos[1] -= counter;
						break;
					case 2:
						square.pos[0] -= counter;
						square.pos[1] += counter;
						break;
					case 3:
						square.pos[0] += counter;
						square.pos[1] += counter;
						break;
				}

				checkCollision(gameBoard, square);
				counter++;
			}
			rotated++;
			if (rotated >= 4) rotated = 0;
			
			return markBoat(gameBoard);
		}
	}
}
