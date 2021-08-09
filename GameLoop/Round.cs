using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Round
    {
        private List<Character> _heroes;
        private List<Character> _monsters;

        public Round(ref List<Party> heroes, ref List<Party> monsters)
        {
            ExtractParty(heroes, true);
            ExtractParty(monsters, false);
        }
          
        public void Start()
        {

        }
        
        private void ExtractParty(List<Party> parties, bool heroes)
        {
            foreach (Party party in parties)
                if (heroes) 
                    _heroes.AddRange(party.Members);
                else
                    _monsters.AddRange(party.Members);
        }

        private bool IsEvenTurn(int turnCount) => (turnCount % 2 == 0);
    }
}
