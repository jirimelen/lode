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

        public Boat()
        {
            for (int i = 0; i < 4; i++)
            {
                squares.Add(new Square
                {
                    X = 0,
                    Y = i
                });
            }
        }
        public void printBoat(Board gameBoard)
        {
            List<Square> boardSquares = gameBoard.getBoard();
        }
    }
}
