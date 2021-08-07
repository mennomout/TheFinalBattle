using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Round
    {
        private readonly Party _currentParty;
        private readonly Party _waitingParty;

        public Round(Party heroes, Party monsters, int round)
        {
            _currentParty = (round % 2 != 0) ? heroes : monsters;
            _waitingParty = (round % 2 == 0) ? heroes : monsters;
        }

        public void TakeTurns()
        {
            foreach(Character character in _currentParty.Members)
            {
                Console.WriteLine($"It is {character.Name}'s turn...");
                TurnAction(character);
            }
        }

        private void TurnAction(Character character)
        {
            string action = Input.GetActionChoice(character);
            if (action == Action._basicAttack) Action.BasicAttack(character, Input.TargetCharacter(_waitingParty));
            if (action == Action._doNothing) Action.DoNothing(character);
        }
    }
}
