using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameManager
    {
        private BoatQueue queue1 = new BoatQueue();
        private BoatQueue queue2 = new BoatQueue();

        public void printInfo(int player, int phase)
        {
            BoatQueue queue;
            string info = "";
            if (player == 1)
            {
                queue = queue1;
            }
            else
            {
                queue = queue2;
            }


            if (phase == 1)
            {
                info += "Use arrows to move and 'R' to rotate :) \n";
                info += $"Player {player} places boats: \n";

                Console.WriteLine("next boat:");
                queue.getQueueBoard().printBoard();
            }
            else
            {
                info += "use arrows to choose a square which you want to attack \n\n\n";
                info += $"Player {player} attacks: \n";
            }
            
            Console.Write(info);
        }

        public Boat nextBoat(int player)
        {
            BoatQueue queue;
            if (player == 1)
            {
                queue = queue1;
            }
            else
            {
                queue = queue2;
            }

            queue.moveQueue();
            return queue.getCurrentBoat();
        }

        public int checkEndQueue(int player)
        {
            BoatQueue queue;
            if (player == 1)
            {
                queue = queue1;
            }
            else
            {
                queue = queue2;
            }

            return queue.getNextBoat().getWidth();
        }
    }
}
