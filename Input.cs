using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public static class Input
    {
        public static string GetPlayerName()
        {
            Console.Write("Enter the name of your hero: ");
            return Console.ReadLine();
        }

        public static string GetActionChoice(Character character)
        {
            List<string> actions = Action.ActionList(character);

            Console.WriteLine("Choose the action for this round");
            for(int i = 0; i < actions.Count; ++i)
                Console.WriteLine($"{ i + 1 }. { actions[i] }");

            int choice = GetNumberChoice(0, actions.Count) - 1;
            return actions[choice];
        }

        public static Character TargetCharacter(Party party)
        {
            Console.WriteLine("What enemy do you want to target:");
            for(int i = 0; i < party.Members.Count; ++i)
                Console.WriteLine($"{ i + 1 }. { party.Members[i].Name }");

            Character choice = party.Members[GetNumberChoice(0, party.Members.Count) - 1];
            return choice;
        }

        private static int GetNumberChoice(int minNum, int maxNum)
        {
            string numberChoice = Console.ReadLine();
            if (int.TryParse(numberChoice, out int number) && (number >= minNum) && (number <= maxNum))
                return number;
            else
            {
                Console.WriteLine("That was not a number. Try again: ");
                return GetNumberChoice(minNum, maxNum);
            }
        }
    }
}
