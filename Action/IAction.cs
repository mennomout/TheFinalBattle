using System;

namespace FinalBattle
{
    public interface IAction
    {
        public void Execute();
    }

    public abstract class Action
    {
        protected Character Actor { get; }
        protected Party[] Targets { get; }

        public Action(Character character, params Party[] targets)
        {
            Actor = character;
            Targets = targets;
        }
    }
}
