using System;

namespace FinalBattle
{
    public class DoNothing : Action, IAction
    {
        public DoNothing(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.DoNothing; }

        public void Execute()
        {
            Console.WriteLine($"{Actor.Name} chose to {Name.GetDescription()}...");
        }
    }

    public class BoneCrush : Action, IAction
    {
        public BoneCrush(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.BoneCrush; }

        public void Execute()
        {
            Random r = new();
            int damage = r.Next(2);

            foreach (Character target in Targets)
            {
                target.ChangeHealth(-damage);
                AttackActionText(target, damage);
            }
        }
    }

    public class Punch : Action, IAction
    {
        public Punch(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.Punch; }

        public void Execute()
        {
            int damage = 2;

            foreach (Character target in Targets)
            {
                target.ChangeHealth(-damage);
                AttackActionText(target, damage);
            }
        }
    }

    public class ReconstructAlly : Action, IAction
    {
        public ReconstructAlly(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.ReconstructAlly; }

        public void Execute()
        {
            int healing = 2;

            foreach (Character target in Targets)
            {
                target.ChangeHealth(healing);
                HealingActionText(target, healing);
            }
        }
    }

    public class Unraveling : Action, IAction
    {
        public Unraveling(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.Unraveling; }

        public void Execute()
        {
            Random r = new();
            int damage = r.Next(5);

            foreach (Character target in Targets)
            {
                target.ChangeHealth(-damage);
                AttackActionText(target, damage);
            }
        }
    }

    public class ConsumeAlly : Action, IAction
    {
        public ConsumeAlly(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.ConsumeAlly; }

        public void Execute()
        {
            int healing;

            foreach (Character target in Targets)
            {
                Console.WriteLine($"{Actor.Name} used {Name} on their ally {target.Name}...");
                if (target == Actor)
                {
                    Console.WriteLine($"Having no effect...");
                }
                else
                {
                    healing = target.Health / 2;
                    Actor.ChangeHealth(healing);
                    target.ChangeHealth(-target._maxHealth);

                    Console.Write($"gaining");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($" {healing}");
                    Console.ResetColor();
                    Console.Write($" HEALTH and destorying {target.Name} ");
                    Display.PrintHealth(target);
                    Console.WriteLine(" in the process!!!");
                }
            }
        }
    }

    public class QuickShot : Action, IAction
    {
        public QuickShot(Character actor, params Character[] targets) : base(actor, targets) { Name = ActionNames.QuickShot; }

        public void Execute()
        {
            Random r = new();
            int damage = r.Next(1, 11) % 2 == 0 ? 3 : 0;

            foreach (Character target in Targets)
            {
                target.ChangeHealth(-damage);
                AttackActionText(target, damage);
            }
        }
    }
}
