using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int BaseDamage { get; private set; } // Basic attack without modifiers

        protected Character(string name, int health, int baseDamage)
        {
            Name = name;
            Health = health;
            BaseDamage = baseDamage;
        }

        public void TakeDamage(int damage) => Health -= damage;
    }
}