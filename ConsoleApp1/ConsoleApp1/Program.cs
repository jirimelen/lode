using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			ConsoleKeyInfo cki;

            Board board = new Board();

            Boat boat = new Boat();

			List<Square> newList = boat.markBoat(board);

			board.updateBoard(newList);
			board.printBoard();


			do {
				cki = Console.ReadKey();

				Console.Clear();

				Console.WriteLine(cki.Key.ToString());

				switch (cki.Key.ToString())
				{
					case "RightArrow":
						boat.moveBoat(board, 0);
						break;
					case "DownArrow":
						boat.moveBoat(board, 1);
						break;
					case "LeftArrow":
						boat.moveBoat(board, 2);
						break;
					case "UpArrow":
						boat.moveBoat(board, 3);
						break;
					case "R":
						boat.rotateBoat(board);
						break;
				}
				board.printBoard();
				Console.WriteLine();
			} while (cki.Key != ConsoleKey.Escape);
		}
    }
}
