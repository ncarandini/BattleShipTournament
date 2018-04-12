using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp.Models
{
    public class ConsoleLogger : ILogger
    {
        public void Log(object sender, string message)
        {
            Console.WriteLine($"{DateTime.Now} [{sender.GetType().Name}] {message}");
        }
    }
}
