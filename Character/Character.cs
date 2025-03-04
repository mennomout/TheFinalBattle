﻿using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public readonly int _maxHealth;
        public List<ActionNames> Actions { get; set; }

        public Character(string name, int health)
        {
            Name = name.ToUpper();
            Health = health;
            _maxHealth = health;
        }

        public void ChangeHealth(int health)
        {
            Health += health;
            if (Health < 0)
                Health = 0;
        }
    }
}