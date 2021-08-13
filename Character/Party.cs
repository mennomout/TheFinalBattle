using System;
using System.Linq;
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

        public bool PartyDeath()
        {
            foreach (Character character in Members)
                if (character.Health > 0)
                    return false;
            return true;
        }

        public void PrintNames()
        {
            int characterNumber = 1;

            foreach (Character character in Members)
            {
                Console.WriteLine($"{characterNumber}. {character.Name}");
                ++characterNumber;
            }
        }
    }
}
