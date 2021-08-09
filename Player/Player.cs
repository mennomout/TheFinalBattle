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
    }
}
