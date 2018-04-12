using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp.Models
{
    public class GameResult
    {
        public IAdmiral Winner { get; private set; }
        public IAdmiral Looser { get; private set; }

        public GameResult(IAdmiral winner, IAdmiral looser)
        {
            Winner = winner;
            Looser = looser;
        }
    }
}
