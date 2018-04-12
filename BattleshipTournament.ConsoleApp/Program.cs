using BattleshipTournament.ConsoleApp.Models;
using BattleshipTournament.Core.Models;
using BattleShipTournament.Nabil;
using BattleShipTournament.Nick;
using BattleShipTournament.Walter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager(
                new AdmiralWalter(),
                new AdmiralNabil(),
                new ConsoleLogger()
            );

            GameResult gameResult = gameManager.PlayGame();

            if (gameResult.Winner != null)
            {
                Console.WriteLine($"And the winner is... {gameResult.Winner.Nome}!");
            }
            else
            {
                Console.WriteLine("Partita terminata per timeout!");
            }

            Console.Write("Premi un tasto per terminare...");
            Console.ReadKey();
        }
    }
}
