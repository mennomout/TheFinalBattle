using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Party
    {
        public List<Character> Members { get; private set; }

        public Party(params Character[] partyMembers)
        {
            if (partyMembers.Length < 1) 
                throw new ArgumentException("Bad Party argument: Party has no Character.");
            if (partyMembers.Length > 5) 
                throw new ArgumentException("Bad Party argument: Max Party size is five.");
            
            Members = new(partyMembers);
        }
    }
}
