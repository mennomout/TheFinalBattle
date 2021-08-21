using System;

namespace FinalBattle
{  
    public class Skeleton : Character
    {
        public Skeleton(string name = "SKELETON", int health = 4) : base(name, health) 
        { 
            Actions = new() { 
                ActionNames.DoNothing, 
                ActionNames.BoneCrush 
            }; 
        }
    }

    public class Programmer : Character
    {
        public Programmer(int health = 10) : base(Input.GetProgrammerName(), health)
        {
            Actions = new()
            {
                ActionNames.DoNothing,
                ActionNames.Punch,
                ActionNames.ReconstructAlly
            };
        }
    }

    public class UncodedOne : Character
    {
        public UncodedOne(int health = 10) : base("THE UNCODED ONE", health)
        {
            Actions = new()
            {
                ActionNames.DoNothing,
                ActionNames.Unraveling,
                ActionNames.ConsumeAlly
            };
        }
    }

    public class VinFletcher : Character
    {
        public VinFletcher(int health = 5) : base("VIN FLETCHER", health)
        {
            Actions = new()
            {
                ActionNames.DoNothing,
                ActionNames.QuickShot
            };
        }
    }
}
