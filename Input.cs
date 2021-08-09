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

        private static int GetNumberChoice(int maxNum, int minNum = 1)
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
