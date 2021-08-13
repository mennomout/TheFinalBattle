using System;
using System.Collections.Generic;

namespace FinalBattle
{
    // All Character sub types have a default name and health value but allow different names and health values
    // The Programmer sub type is a deviation from this because the name is always supplied by the Player
    
    public class Skeleton : Character
    {
        public Skeleton(string name = "SKELETON", int health = 4) : base(name, health) { }
    }

    public class Programmer : Character
    {
        public Programmer(int health = 20) : base(Input.GetName(), health) { }
    }
}
