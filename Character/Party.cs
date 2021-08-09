using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Party
    {
        public List<Character> Members { get; private set; }
        public int PartySize { get; private set; }
        
        public Party(params Character[] partyMembers)
        {
            Members = new(partyMembers);
            PartySize = Members.Count;
        }

        public bool PartyDeath()
        {
            foreach (Character character in Members)
                if (character.Health > 0)
                    return false;
            return true;
        }
    }
}
