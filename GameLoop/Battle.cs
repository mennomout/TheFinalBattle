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

        public void Start()
        {
            while(true)
            {
                Round round = new(ref _heroParties, ref _monsterParties);
                round.Start();
                if (CheckDeath(_heroParties))
                {
                    End(_monsterParties);
                    break;
                }
                if (CheckDeath(_monsterParties))
                {
                    End(_heroParties);
                    break;
                }
            }
        }

        public void End(List<Party> parties)
        {
            string partyNames = null;
            for (int i = 0; i < parties.Count; ++i)
                foreach (Character character in parties[i].Members)
                    partyNames += $" {character.Name}";

            Console.WriteLine($"VICTORY BELONGS TO THE PARTY OF: {partyNames}!!!");
        }

        private bool CheckDeath(List<Party> parties)
        {
            int deathCount = 0;
            foreach (Party party in parties)
                if (party.PartyDeath())
                    ++deathCount;

            return (deathCount == parties.Count);
        }
    }
}
