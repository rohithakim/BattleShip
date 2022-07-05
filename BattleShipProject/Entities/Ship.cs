using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipProject.Utils;

namespace BattleShipProject.Entities
{
    public class Ship
    {
        public int Width { get; set; }
        public string Name { get; set; }
        public OccupationStatus OccupationStatus { get; set; }
        public int Hits { get; set; }

        public Ship(string name)
        {
            Name = name;
        }
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
    }
}
