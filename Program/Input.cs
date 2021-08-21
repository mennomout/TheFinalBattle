using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public static class Input
    {
        public static string GetProgrammerName()
        {
            Console.Write("Enter the name of your programming hero: ");
            return Console.ReadLine();
        }

        public static Character GetSingleTarget(List<Character> targets)
        {
            Console.WriteLine($"Who do you want to target?");
            Display.PrintTargets(targets);

            Character target = targets[GetIndexChoice(targets.Count)];
            if (target.Health <= 0)
            {
                Console.WriteLine($"{target.Name} is already dead! Try another target...");
                target = GetSingleTarget(targets);
            }    

            return target;
        }

        public static ActionNames GetActionName(Character character)
        {
            Display.PrintCharacterActions(character);

            return character.Actions[GetIndexChoice(character.Actions.Count)];
        }

        private static int GetIndexChoice(int maxNum, int minNum = 1)
        {
            char numberChoice = Console.ReadKey(true).KeyChar;
            string choice = $"{numberChoice}";

            Console.WriteLine();
            if (int.TryParse(choice, out int number) && (number >= minNum) && (number <= maxNum))
                return number - 1;
            else
            {
                Console.WriteLine("That was not a (valid) number. Try again: ");
                return GetIndexChoice(maxNum, minNum);
            }
        }
    }
}
