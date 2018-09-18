using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {
        private List<Square> board = new List<Square>();
        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int u = 0; u < 10; u++)
                {
                    board.Add(new Square{
                        X = i,
                        Y = u
                    });

                    Console.Write(".");
                }

                Console.Write("\n");
            }
        }
        public List<Square> getBoard()
        {
            return board;
        }
    }
}
