using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// set limits of placed boats
// set boat types to be placed
// in attack phase print another board with opponents moves
// update to SOLID model
//

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(41, 40);
            Console.SetBufferSize(41, 40);

            ConsoleKeyInfo cki;

            bool activeLoop = true;
            bool completed = false;
            int winner = 0;

            Board board1 = new Board();
            Board board2 = new Board();

            Boat boat = new Simple_boat(1);

			List<Square> newList = boat.markBoat(board1);


            Console.WriteLine("Use arrows to move and 'R' to rotate :)");
            Console.WriteLine("Use nums 0-7 to change type of boat.");
            Console.WriteLine("while option 0 is selected use +/- to make your boat longer/shorter.");
            Console.WriteLine("Player 1 places boats:");

            board1.updateBoard(newList);
			board1.printBoard();


            do
            {
                cki = Console.ReadKey();

                Console.Clear();
                
                Console.WriteLine("use arrows to move and 'R' to rotate :)");
                Console.WriteLine("Use nums 0-7 to change type of boat.");
                Console.WriteLine("while option 0 is selected use +/- to make your boat longer/shorter.");
                Console.WriteLine("Player 1 places boats:");

                switch (cki.Key.ToString())
                {
                    case "RightArrow":
                        boat.moveBoat(board1, 0);
                        break;
                    case "DownArrow":
                        boat.moveBoat(board1, 1);
                        break;
                    case "LeftArrow":
                        boat.moveBoat(board1, 2);
                        break;
                    case "UpArrow":
                        boat.moveBoat(board1, 3);
                        break;
                    case "R":
                        boat.rotateBoat(board1);
                        break;
                    case "Enter":
                        bool placed = boat.placeBoat(board1);
                        if (placed == true)
                        {
                            board1.Boats.Add(boat);
                            boat = new Simple_boat(1);
                            boat.markBoat(board1);
                        }
                        break;

                    case "Add":
                    case "OemPlus":
                        if (boat.GetType().Name == "Simple_boat")
                        {
                            if (boat.getWidth() + 1 <= 5)
                            {
                                boat = new Simple_boat(boat.getWidth() + 1);
                                boat.markBoat(board1);
                            }
                        }
                        break;
                    case "Subtract":
                    case "OemMinus":
                        if (boat.GetType().Name.Equals("Simple_boat"))
                        {
                            if (boat.getWidth() - 1 > 0)
                            {
                                boat = new Simple_boat(boat.getWidth() - 1);
                                boat.markBoat(board1);
                            }
                        }
                        break;

                    case "D0":
                        boat = new Simple_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D1":
                        boat = new Base_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D2":
                        boat = new Hydroplane_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D3":
                        boat = new Cruiser_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D4":
                        boat = new HeavyCruiser_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D5":
                        boat = new Catamaran_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D6":
                        boat = new Warship_boat(1);
                        boat.markBoat(board1);
                        break;
                    case "D7":
                        boat = new Planeship_boat(1);
                        boat.markBoat(board1);
                        break;

                    case "Tab":
                        board1.nextPhase();
                        activeLoop = false;
                        break;
                }
                board1.printBoard();
                Console.WriteLine();
            } while (activeLoop == true);


            activeLoop = true;
            boat = new Simple_boat(1);
            newList = boat.markBoat(board2);

            Console.Clear();

            Console.WriteLine("use arrows to move and 'R' to rotate :)");
            Console.WriteLine("Use nums 0-7 to change type of boat.");
            Console.WriteLine("while option 0 is selected use +/- to make your boat longer/shorter.");
            Console.WriteLine("Player 2 places boats:");
            board2.updateBoard(newList);
            board2.printBoard();


            do
            {
                cki = Console.ReadKey();

                Console.Clear();
                
                Console.WriteLine("use arrows to move and 'R' to rotate :)");
                Console.WriteLine("Use nums 0-7 to change type of boat.");
                Console.WriteLine("while option 0 is selected use +/- to make your boat longer/shorter.");
                Console.WriteLine("Player 2 places boats:");

                switch (cki.Key.ToString())
                {
                    case "RightArrow":
                        boat.moveBoat(board2, 0);
                        break;
                    case "DownArrow":
                        boat.moveBoat(board2, 1);
                        break;
                    case "LeftArrow":
                        boat.moveBoat(board2, 2);
                        break;
                    case "UpArrow":
                        boat.moveBoat(board2, 3);
                        break;
                    case "R":
                        boat.rotateBoat(board2);
                        break;
                    case "Enter":
                        bool placed = boat.placeBoat(board2);
                        if (placed == true)
                        {
                            board2.Boats.Add(boat);
                            boat = new Simple_boat(1);
                            boat.markBoat(board2);
                        }
                        break;

                    case "Add":
                    case "OemPlus":
                        if (boat.GetType().Name == "Simple_boat")
                        {
                            if (boat.getWidth() + 1 <= 5)
                            {
                                boat = new Simple_boat(boat.getWidth() + 1);
                                boat.markBoat(board2);
                            }
                        }
                        break;
                    case "Subtract":
                    case "OemMinus":
                        if (boat.GetType().Name.Equals("Simple_boat"))
                        {
                            if (boat.getWidth() - 1 > 0)
                            {
                                boat = new Simple_boat(boat.getWidth() - 1);
                                boat.markBoat(board2);
                            }
                        }
                        break;

                    case "D0":
                        boat = new Simple_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D1":
                        boat = new Base_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D2":
                        boat = new Hydroplane_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D3":
                        boat = new Cruiser_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D4":
                        boat = new HeavyCruiser_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D5":
                        boat = new Catamaran_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D6":
                        boat = new Warship_boat(1);
                        boat.markBoat(board2);
                        break;
                    case "D7":
                        boat = new Planeship_boat(1);
                        boat.markBoat(board2);
                        break;

                    case "Tab":
                        board2.nextPhase();
                        activeLoop = false;
                        break;
                }
                board2.printBoard();
                Console.WriteLine();
            } while (activeLoop == true);



            do
            {
                activeLoop = true;
                boat = new Simple_boat(1);
                newList = boat.markBoat(board2);

                Console.Clear();

                Console.WriteLine("use arrows to choose a square which you want to attack");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Player 1 attacks:");
                board2.updateBoard(newList);
                board2.printBoard();


                do
                {
                    cki = Console.ReadKey();

                    Console.Clear();
                    
                    Console.WriteLine("use arrows to choose a square then press 'Enter' when you want to attack");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Player 1 attacks:");

                    switch (cki.Key.ToString())
                    {
                        case "RightArrow":
                            boat.moveBoat(board2, 0);
                            break;
                        case "DownArrow":
                            boat.moveBoat(board2, 1);
                            break;
                        case "LeftArrow":
                            boat.moveBoat(board2, 2);
                            break;
                        case "UpArrow":
                            boat.moveBoat(board2, 3);
                            break;

                        case "Enter":
                            switch (boat.attack(board2))
                            {
                                case 2:
                                    Console.WriteLine("You've already hit this square. try again");
                                    break;
                                case 1:
                                    Console.WriteLine("You've hit part of opponent's boat, you get one more try ");
                                    completed = board2.checkWin();
                                    if (completed) {
                                        winner = 1;
                                        activeLoop = false;
                                    } 
                                    break;
                                case 0:
                                    boat.markBoat(board2, 1);
                                    activeLoop = false;
                                    break;
                            }
                            break; 


                        case "Tab":
                            board2.nextPhase();
                            activeLoop = false;
                            break;
                    }
                    board2.printBoard();
                    Console.WriteLine();
                    if (activeLoop == false)
                    {
                        Console.WriteLine("Press any key to end turn.");
                        Console.ReadKey();
                    }
                } while (activeLoop == true);

                


                activeLoop = true;
                boat = new Simple_boat(1);
                newList = boat.markBoat(board1);

                Console.Clear();

                Console.WriteLine("use arrows to choose a square which you want to attack");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Player 2 attacks:");
                board1.updateBoard(newList);
                board1.printBoard();
                if (completed == false)
                {
                    do
                    {
                        cki = Console.ReadKey();

                        Console.Clear();
                        
                        Console.WriteLine("use arrows to choose a square which you want to attack");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Player 2 attacks:");

                        switch (cki.Key.ToString())
                        {
                            case "RightArrow":
                                boat.moveBoat(board1, 0);
                                break;
                            case "DownArrow":
                                boat.moveBoat(board1, 1);
                                break;
                            case "LeftArrow":
                                boat.moveBoat(board1, 2);
                                break;
                            case "UpArrow":
                                boat.moveBoat(board1, 3);
                                break;

                            case "Enter":
                                switch (boat.attack(board1))
                                {
                                    case 2:
                                        Console.WriteLine("You've already hit this square. try again");
                                        break;
                                    case 1:
                                        Console.WriteLine("You've hit part of opponent's boat, you get one more try ");
                                        completed = board1.checkWin();
                                        if (completed)
                                        {
                                            winner = 2;
                                            activeLoop = false;
                                        }
                                        break;
                                    case 0:
                                        boat.markBoat(board1, 1);
                                        activeLoop = false;
                                        break;
                                }
                                break;


                            case "Tab":
                                board1.nextPhase();
                                activeLoop = false;
                                break;
                        }
                        board1.printBoard();
                        Console.WriteLine();
                        if (activeLoop == false)
                        {
                            Console.WriteLine("Press any key to end turn.");
                            Console.ReadKey();
                        }
                    } while (activeLoop == true);
                }
            } while (completed == false);

            Console.WriteLine("The game has been completed :)");
            Console.WriteLine("player " + winner + " won the game");
            
        }
    }
}
