using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Square
    {
        public List<int> Pos { get; set; }
        public List<int> BoatPos { get; set; }
        public Square_state state = Square_state.free;
		public Boat OccupiedBy { get; set; }
        public int Overlay { get; set; } = 0;
    }
}
