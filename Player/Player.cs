using System;

namespace FinalBattle
{
    public abstract class Player
    {
        public string Name { get; private set; }
        protected bool IsHero { get; set; }

        public Player(string name, bool isHero)
        {
            Name = name;
            IsHero = isHero;
        }

        public abstract void Turn(Character actor, Battle battle);
    }
}
