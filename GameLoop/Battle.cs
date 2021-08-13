using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalBattle
{
    public class Battle
    {
        private List<Party> _heroParties;
        private List<Party> _monsterParties;

        public Battle(List<Party> heroParties, List<Party> monsterParties)
        {
            _heroParties = heroParties;
            _monsterParties = monsterParties;
        }

        private bool CheckDeath(List<Party> parties)
        {
            int deathCount = 0;
            foreach (Party party in parties)
                if (party.PartyDeath())
                    ++deathCount;

            return (deathCount == parties.Count);
        }

        private bool HeroesTurn(int turn) => !(turn % 2 == 0);
    }
}
