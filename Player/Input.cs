using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public static class Input
    {
        public static string GetName()
        {
            Console.Write("Enter the name of your hero: ");
            return Console.ReadLine();
        }

        public static Character SingleTarget(Party party)
        {
            Console.WriteLine($"Who do you want to target?");
            party.PrintNames();

            return party.Members[GetIndexChoice(party.Members.Count)];
        }

        private static int GetIndexChoice(int maxNum, int minNum = 1)
        {
            string numberChoice = Console.ReadLine();
            if (int.TryParse(numberChoice, out int number) && (number >= minNum) && (number <= maxNum))
                return number - 1;
            else
            {
                Console.WriteLine("That was not a (valid) number. Try again: ");
                return GetIndexChoice(minNum, maxNum);
            }
        }
    }
}
