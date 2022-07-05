using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipProject.Entities;
using BattleShipProject.Utils;

namespace BattleShipProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();

            Ship batteShip = new Ship("Crusier");
            batteShip.Width = 4;
            batteShip.OccupationStatus = OccupationStatus.Battleship;

            Ship submarine = new Ship("Submarine");
            submarine.Width = 6;
            submarine.OccupationStatus = OccupationStatus.Battleship;

            List<Ship> ships = new List<Ship>();
            ships.Add(batteShip);
            ships.Add(submarine);

            Player p1 = new Player("Player1");
            p1.GameBoard = board;
            p1.Ships = ships;

            p1.PlaceShips();

            p1.DiplaySHipPosition();

            //Console.ReadLine();

            while (!p1.HasLost)
            {
                Console.WriteLine("Enter Coordinates for attack in form X,Y");
                string input = Console.ReadLine();

                try
                {
                    string[] inp = input.Split(',');

                    var result = p1.ProcessShot(Convert.ToInt16(inp[0]), Convert.ToInt16(inp[1]));
                    p1.ProcessShotResult(Convert.ToInt16(inp[0]), Convert.ToInt16(inp[1]), result);

                    if (!(p1.Ships.Any(x => x.OccupationStatus == OccupationStatus.Battleship)))
                    {
                        Console.WriteLine("You have won!");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Input error!, Please enter Coordinates for attack in form X,Y");
                }
            }

            

            Console.ReadLine();

        }
    }
}
