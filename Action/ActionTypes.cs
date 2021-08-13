using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class DoNothing : Action, IAction
    {
        public DoNothing(Character actor) : base(actor) { }

        public void Execute()
        {
            Console.WriteLine($"{Actor.Name} did nothing...");
        }
    }

    public class BoneCrush : Action, IAction
    {
        public BoneCrush(Character actor, Party enemyParty) : base(actor, enemyParty) { }

        public void Execute()
        {
            foreach (Party enemyParty in Targets)
            {
                Character target = Input.SingleTarget(enemyParty);

                Random r = new();
                target.ChangeHealth(-r.Next(2));
            }
        }
    }
}
