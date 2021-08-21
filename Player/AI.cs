using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalBattle
{
    public class AI : Player
    {
        public AI(string name, bool isHero) : base(name, isHero) { }

        public override void Turn(Character actor, Battle battle)
        {
            // A.I. picks randomly from it's list of actions but never skipping a turn.
            Random r = new();
            ActionNames actionName = actor.Actions[r.Next(1,actor.Actions.Count)];
            
            IAction action = GetAction(actionName, actor, battle);
            action.Execute();
            
            Thread.Sleep(5);
        }

        private IAction GetAction(ActionNames actionNames, Character actor, Battle battle)
        {
            // If the action is an attack, pass the enemies list. If the action is a heal, pass the allies list.
            List<Character> enemies = IsHero ? battle._monsters : battle._heroes;
            List<Character> allies = IsHero ? battle._heroes : battle._monsters;

            return actionNames switch
            {
                ActionNames.DoNothing => new DoNothing(actor),
                ActionNames.BoneCrush => new BoneCrush(actor, GetTarget(enemies)),
                ActionNames.Punch => new Punch(actor, GetTarget(enemies)),
                ActionNames.Unraveling => new Unraveling(actor, GetTarget(enemies)),
                ActionNames.QuickShot => new QuickShot(actor, GetTarget(enemies)),
                ActionNames.ConsumeAlly => new ConsumeAlly(actor, GetTarget(allies)),
                ActionNames.ReconstructAlly => new ReconstructAlly(actor, GetTarget(allies)),
                _ => GetAction(actionNames, actor, battle)
            };
        }

        private Character GetTarget(List<Character> targets)
        {
            Character target = targets[0];

            // Selects the lowest health character in the list of targets that is still alive.
            foreach (Character character in targets)
                if (character.Health <= target.Health && character.Health > 0)
                    target = character;

            return target;
        }
    }
}
