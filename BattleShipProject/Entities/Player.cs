using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipProject.Utils;

namespace BattleShipProject.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        public List<Ship> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name)
        {
            Name = name;
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed panels are occupied, place the ship
                //Do this for all ships

                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2; //0 for Horizontal

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endcolumn++;
                        }
                    }

                    //We cannot place ships beyond the boundaries of the board
                    if (endrow > 10 || endcolumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    //Check if specified panels are occupied
                    var affectedPanels = GameBoard.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedPanels.Any(x => x.OccupationType == OccupationStatus.Battleship))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var panel in affectedPanels)
                    {
                        panel.OccupationType = ship.OccupationStatus;
                    }
                    isOpen = false;
                }
            }
        }

        public void DiplaySHipPosition()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Game Board:");
            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GameBoard.Panels.Where(x => x.Row == row && x.Column == ownColumn).First().Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public ShotResult ProcessShot(int X, int Y)
        {
            if(X>10 || Y>10)
            {
                Console.WriteLine("Coordinates entered should be between 1 to 10. Try Again.");
                return ShotResult.Miss;
            }

            var panel = GameBoard.Panels.At(X, Y);

            if (panel.OccupationType==OccupationStatus.Empty)
            {
                Console.WriteLine("Miss! Try Again.");
                return ShotResult.Miss;
            }

            var ship = Ships.First(x => x.OccupationStatus == panel.OccupationType);

            ship.Hits++;
            Console.WriteLine("Hit!");
            if (ship.IsSunk)
            {
                Console.WriteLine("You sunk " + ship.Name + "!");
                ship.OccupationStatus = OccupationStatus.Destroyed;
            }
            return ShotResult.Hit;
        }

        public void ProcessShotResult(int row, int column, ShotResult result)
        {
            var panel = GameBoard.Panels.At(row, column);

            switch (result)
            {
                case ShotResult.Hit:
                    panel.OccupationType = OccupationStatus.Hit;
                    break;
                    
                default:
                    panel.OccupationType = OccupationStatus.Miss;
                    break;

            }
        }
    }
}
