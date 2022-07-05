using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipProject.Utils
{
    public enum OccupationStatus
    {
        Empty = 'o',
        Battleship = 'B',
        Hit = 'X',
        Miss = 'M',
        Destroyed = 'D'
    }

    public enum ShotResult
    {
        Hit,
        Miss
    }
}
