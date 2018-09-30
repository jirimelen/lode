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
            Console.SetWindowSize(55, 40);
            Console.SetBufferSize(55, 40);

            GameManager manager = new GameManager();

            ConsoleKeyInfo cki;

            bool activeLoop = true;
            bool completed = false;
            int winner = 0;

            Board board1 = new Board( 13,13 );
            Board board2 = new Board( 13,13 );

            Boat boat = new Simple_boat(1);

			List<Square> newList = boat.markBoat(board1);

            
            manager.printInfo(1,1);

            board1.updateBoard(newList);
			board1.printBoard();


            do
            {
                cki = Console.ReadKey();

                Console.Clear();
                manager.printInfo(1, 1);

                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow:
                        boat.moveBoat(board1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        boat.moveBoat(board1, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        boat.moveBoat(board1, 2);
                        break;
                    case ConsoleKey.UpArrow:
                        boat.moveBoat(board1, 3);
                        break;
                    case ConsoleKey.R:
                        boat.rotateBoat(board1);
                        break;
                    case ConsoleKey.Enter:
                        bool placed = boat.placeBoat(board1);
                        if (placed == true)
                        {
                            board1.Boats.Add(boat);
                            if (manager.checkEndQueue(1) == 0)
                            {
                                Console.WriteLine("you placed all boats. press any key to continue");
                                Console.ReadKey();
                                board1.nextPhase();
                                activeLoop = false;
                            }
                            boat = manager.nextBoat(1);
                            Console.Clear();
                            manager.printInfo(2, 1);
                            boat.markBoat(board1);
                        }
                        break;


                    case ConsoleKey.Tab:
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
            manager.printInfo(2, 1);

            board2.updateBoard(newList);
            board2.printBoard();


            do
            {
                cki = Console.ReadKey();

                Console.Clear();
                manager.printInfo(2, 1);

                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow:
                        boat.moveBoat(board2, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        boat.moveBoat(board2, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        boat.moveBoat(board2, 2);
                        break;
                    case ConsoleKey.UpArrow:
                        boat.moveBoat(board2, 3);
                        break;
                    case ConsoleKey.R:
                        boat.rotateBoat(board2);
                        break;
                    case ConsoleKey.Enter:
                        bool placed = boat.placeBoat(board2);
                        if (placed == true)
                        {
                            board2.Boats.Add(boat);
                            if (manager.checkEndQueue(2) == 0)
                            {
                                Console.WriteLine("you placed all boats. press any key to continue");
                                Console.ReadKey();
                                board2.nextPhase();
                                activeLoop = false;
                            }
                            boat = manager.nextBoat(2);
                            boat.markBoat(board2);
                            Console.Clear();
                            manager.printInfo(2, 1);
                        }
                        break;


                    case ConsoleKey.Tab:
                        board1.nextPhase();
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
                manager.printInfo(1,2);


                board2.updateBoard(newList);
                board2.printBoard();


                do
                {
                    cki = Console.ReadKey();

                    Console.Clear();
                    manager.printInfo(1, 2);

                    switch (cki.Key)
                    {
                        case ConsoleKey.RightArrow:
                            boat.moveBoat(board2, 0);
                            break;
                        case ConsoleKey.DownArrow:
                            boat.moveBoat(board2, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            boat.moveBoat(board2, 2);
                            break;
                        case ConsoleKey.UpArrow:
                            boat.moveBoat(board2, 3);
                            break;

                        case ConsoleKey.Enter:
                            switch (boat.attack(board2))
                            {
                                case 2:
                                    Console.WriteLine("You've already hit this square. try again");
                                    break;
                                case 1:
                                    completed = board2.checkWin();
                                    if (completed) {
                                        winner = 1;
                                        activeLoop = false;
                                    } 
                                    else
                                    {
                                        Console.WriteLine("You've hit part of opponent's boat, you get one more try ");
                                    }
                                    break;
                                case 0:
                                    boat.markBoat(board2, 1);
                                    activeLoop = false;
                                    break;
                            }
                            break; 


                        case ConsoleKey.Tab:
                            winner = 1;
                            activeLoop = false;
                            completed = true;
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

                


                if (completed == false)
                {
                    activeLoop = true;
                    boat = new Simple_boat(1);
                    newList = boat.markBoat(board1);

                    Console.Clear();
                    manager.printInfo(2, 2);


                    board1.updateBoard(newList);
                    board1.printBoard();
                    do
                    {
                        cki = Console.ReadKey();

                        Console.Clear();
                        manager.printInfo(2, 2);

                        switch (cki.Key)
                        {
                            case ConsoleKey.RightArrow:
                                boat.moveBoat(board1, 0);
                                break;
                            case ConsoleKey.DownArrow:
                                boat.moveBoat(board1, 1);
                                break;
                            case ConsoleKey.LeftArrow:
                                boat.moveBoat(board1, 2);
                                break;
                            case ConsoleKey.UpArrow:
                                boat.moveBoat(board1, 3);
                                break;

                            case ConsoleKey.Enter:
                                switch (boat.attack(board1))
                                {
                                    case 2:
                                        Console.WriteLine("You've already hit this square. try again");
                                        break;
                                    case 1:
                                        completed = board1.checkWin();
                                        if (completed)
                                        {
                                            winner = 2;
                                            activeLoop = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You've hit part of opponent's boat, you get one more try ");
                                        }
                                        break;
                                    case 0:
                                        boat.markBoat(board1, 1);
                                        activeLoop = false;
                                        break;
                                }
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
