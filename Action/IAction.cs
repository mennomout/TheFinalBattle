using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FinalBattle
{
    public interface IAction
    {
        public void Execute();
    }

    public abstract class Action
    {
        public ActionNames Name { get; set; }
        protected Character Actor { get; }
        protected List<Character> Targets { get; }

        public Action(Character character, params Character[] targets)
        {
            Actor = character;
            Targets = new(targets);
        }

        protected void AttackActionText(Character target, int damage)
        {
            Console.Write($"{Actor.Name} used {Name.GetDescription()} on {target.Name}... ");
            if (damage > 0)
            {
                Console.Write("DEALING ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{damage}");
                Console.ResetColor();
                Console.Write(" DAMAGE!!! ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Actor.Name} MISSED {target.Name}!!!");
                Console.ResetColor();
            }

            if (target.Health <= 0)
                Console.WriteLine($"{target.Name} DIED!!!");
            else
            {
                Console.Write($"{target.Name}");
                Display.PrintHealth(target);
            }
        }

        protected void HealingActionText(Character target, int healing)
        {
            Console.Write($"{Actor.Name} used {Name.GetDescription()} on {target.Name}... ");
            
            Console.Write(" HEALING them for ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{healing}");
            Console.ResetColor();
            Console.Write(". ");
        }
    }

    public enum ActionNames 
    {
        [Description("DO NOTHING")]
        DoNothing,
        [Description("BONE CRUSH")]
        BoneCrush,
        [Description("ROUNDHOUSE KICK")]
        Punch,
        [Description("UNRAVELING")]
        Unraveling,
        [Description("CONSUME ALLIES CODE")]
        ConsumeAlly,
        [Description("QUICK SHOT")]
        QuickShot,
        [Description("RECONSTRUCT ALLY")]
        ReconstructAlly
    }

    // Source of this code: https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations
    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();

            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
