using System;
using System.Threading;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Human : Player
    {
        public Human(string name,  bool isHero) : base(name, isHero) { }

        public override void Turn(Character actor, Battle battle)
        {
            ActionNames actionName = Input.GetActionName(actor);

            IAction action = GetAction(actionName, actor, battle);
            action.Execute();

            Console.WriteLine("\nPress 'Enter' to end your turn.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        private IAction GetAction(ActionNames actionNames, Character actor, Battle battle)
        {
            // If the action is an attack, pass the enemies list. If the action is a heal, pass the allies list.
            List<Character> enemies = IsHero ? battle._monsters : battle._heroes;
            List<Character> allies = IsHero ? battle._heroes : battle._monsters;

            return actionNames switch
            {
                ActionNames.DoNothing => new DoNothing(actor),
                ActionNames.BoneCrush => new BoneCrush(actor, Input.GetSingleTarget(enemies)),
                ActionNames.Punch => new Punch(actor, Input.GetSingleTarget(enemies)),
                ActionNames.Unraveling => new Unraveling(actor, Input.GetSingleTarget(enemies)),
                ActionNames.QuickShot => new QuickShot(actor, Input.GetSingleTarget(enemies)),
                ActionNames.ConsumeAlly => new ConsumeAlly(actor, Input.GetSingleTarget(allies)),
                ActionNames.ReconstructAlly => new ReconstructAlly(actor, Input.GetSingleTarget(allies)),
                _ => GetAction(actionNames, actor, battle)
            };
        }
    }
}
