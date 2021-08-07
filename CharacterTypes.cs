using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Skeleton : Character
    {
        public Skeleton() : base("SKELETON", 10, 2) { }
    }

    public class TrueProgrammer : Character
    {
        public TrueProgrammer() : base(Input.GetPlayerName(), 20, 4) { }
    }
}
