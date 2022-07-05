using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipProject.Entities;

namespace BattleShipProject.Utils
{
    public static class PanelExtensions
    {
        public static Panel At(this List<Panel> panels, int row, int column)
        {
            return panels.Where(x => x.Row == row && x.Column == column).First();
        }
    }
}
