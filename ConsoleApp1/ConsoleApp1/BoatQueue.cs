using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BoatQueue
    {
        private int position = 1;
        private List<Boat> queue = new List<Boat>() {
            new Simple_boat(1),
            new Simple_boat(2),
            new Simple_boat(3),
            new Simple_boat(4),
            new Simple_boat(5),
            new Base_boat(1),
            new Hydroplane_boat(1),
            new Cruiser_boat(1),
            new HeavyCruiser_boat(1),
            new Catamaran_boat(1),
            new Warship_boat(1),
            new Planeship_boat(1),
            new Boat()
        };

        public Board getQueueBoard()
        {
            Board queueBoard = new Board(3,5);
            //queueBoard.updateBoard(queue[position].markBoat(queueBoard));

            return queueBoard;
        }

        public void moveQueue()
        {
            if (position+1 <= queue.Count()) position++;
        }

        public Boat getCurrentBoat()
        {
            return queue[position - 1];
        }

        public Boat getNextBoat()
        {
            return position <= queue.Count() ? queue[position] : queue[position - 1];
        }
    }
}
