using System;

namespace FinalBattle
{
    public abstract class Player
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public abstract void Turn(Party partyTurn, Party enemyParty);
        public abstract IAction ChooseAction(Character charTurn, Party partyTurn, Party enemyParty);
    }
}
