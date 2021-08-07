using System;
using System.Threading;

namespace FinalBattle
{
    public class Battle
    {
        private Party Heroes { get; set; }
        private Party Monsters { get; set; }
        private int _round = 1;

        public Battle(Party heroes, Party monsters)
        {
            Heroes = heroes;
            Monsters = monsters;
        }

        public void Start()
        {
            while (CheckWinLoss())
            {
                Round round = new(Heroes, Monsters, _round);
                round.TakeTurns();
                Thread.Sleep(500);
                ++_round;
            }
        }

        private bool CheckWinLoss() => !Heroes.PartyDeath() && !Monsters.PartyDeath();
    }
}
