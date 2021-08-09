using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage) => Health -= damage;
    }
}