using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp.Models
{
    public interface ILogger
    {
        void Log(object sender, string message);
    }
}
