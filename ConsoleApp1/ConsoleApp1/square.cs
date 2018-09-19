using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Square
    {
        public List<int> pos { get; set; }
        public int Occupied { get; set; } = 0;
        public int Destroyed { get; set; } = 0;
		public Boat occupiedBy { get; set; }
        public int overlay { get; set; } = 0;
    }
}
