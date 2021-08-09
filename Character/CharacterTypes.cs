using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Skeleton : Character
    {
        public Skeleton() : base("SKELETON", 4) { }
    }

    public class Programmer : Character
    {
        public Programmer() : base(Input.GetName(), 20) { }
    }
}
