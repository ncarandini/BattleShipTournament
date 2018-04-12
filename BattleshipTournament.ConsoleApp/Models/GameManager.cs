using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp.Models
{
    public class GameManager
    {
        IAdmiral admiralWhite, admiralBlack,
                 attacker, defender,
                 winner, looser;

        ILogger logger;

        bool gameEnded = false;

        public GameManager(IAdmiral admiralWhite, IAdmiral admiralBlack, ILogger logger)
        {
            this.admiralWhite = admiralWhite;
            this.admiralBlack = admiralBlack;
            this.logger = logger;

            this.admiralWhite.FlottaAffondata += AdmiralWhite_FlottaAffondata;
            this.admiralBlack.FlottaAffondata += AdmiralWhite_FlottaAffondata;
        }

        private void AdmiralWhite_FlottaAffondata(IAdmiral admiral)
        {
            if (admiral == admiralWhite)
            {
                winner = admiralBlack;
                looser = admiralWhite;
            }
            else
            {
                winner = admiralWhite;
                looser = admiralBlack;
            }

            gameEnded = true;
        }

        public GameResult PlayGame()
        {
            logger.Log(this, $"Request to Admiral {admiralWhite.Nome} to set the fleet...");
            admiralWhite.PosizionaFlotta();
            logger.Log(this, $"Request to Admiral {admiralWhite.Nome} to set the fleet completed.");

            logger.Log(this, $"Request to Admiral {admiralBlack.Nome} to set the fleet...");
            admiralBlack.PosizionaFlotta();
            logger.Log(this, $"Request to Admiral {admiralBlack.Nome} to set the fleet completed.");

            int turn = 1;
            attacker = admiralWhite;
            defender = admiralBlack;

            while (!gameEnded && turn <= 100)
            {
                logger.Log(this, $"Turn {turn} : Attacker is {attacker.Nome}, defender is {defender.Nome}.");

                logger.Log(this, $"Request to attacker {attacker.Nome} to shot...");
                Coordinate sparo = attacker.Spara();
                logger.Log(this, $"Attacker {attacker.Nome} shooted at ({sparo.Riga}, {sparo.Colonna}).");

                logger.Log(this, $"Request to defender {defender.Nome} to report shot effects...");
                EffettoSparo effetto = defender.Rapporto(sparo);
                logger.Log(this, $"Defender {defender.Nome} reported '{TestoEffetto(effetto)}'.");

                logger.Log(this, $"Report to attacker {attacker.Nome} shot effects...");
                attacker.RiceviRapporto(effetto);
                logger.Log(this, $"Report to attacker {attacker.Nome} delivered.");

                logger.Log(this, $"Swap attacker and defender and start new turn.");
                SwapRoles();
                turn++;
            }

            return new GameResult(winner, looser);
        }

        void SwapRoles()
        {
            IAdmiral previousAttacker = attacker;
            attacker = defender;
            defender = previousAttacker;
        }

        string TestoEffetto(EffettoSparo effetto)
        {
            switch (effetto)
            {
                case EffettoSparo.Acqua:
                    return "acqua";
                case EffettoSparo.Colpito:
                    return "colpito";
                case EffettoSparo.Affondato:
                    return "colpito e affondato";
                default:
                    return "";
            }
        }

    }
}
