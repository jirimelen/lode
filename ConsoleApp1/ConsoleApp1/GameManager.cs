using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameManager
    {
        public void printInfo(int player, int phase)
        {
            string info = "";
            if (phase == 1)
            {
                info += "Use arrows to move and 'R' to rotate :) \n";
                info += "Use nums 0-7 to change type of boat. \n";
                info += "When option 0 is selected use +/- to make your boat longer/shorter. \n";
                info += $"Player {player} places boats: \n";
            }
            else
            {
                info += "use arrows to choose a square which you want to attack \n\n\n";
                info += $"Player {player} attacks: \n";
            }
            
            Console.Write(info);
        }
    }
}
