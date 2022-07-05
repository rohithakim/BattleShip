using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipProject.Utils;

namespace BattleShipProject.Entities
{
    public class Panel
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public OccupationStatus OccupationType { get; set; }

        public Panel(int row, int column)
        {
            Row = row;
            Column = column;
            OccupationType = OccupationStatus.Empty;
        }

        public string Status
        {
            get
            {
                return ((char)OccupationType).ToString();
            }

            set
            {
                OccupationType = OccupationStatus.Battleship;
            }
        }
    }
}
