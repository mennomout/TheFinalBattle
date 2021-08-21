using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBattle
{
    public static class Display
    {
        public static void PrintCharacterNames(List<Character> characters)
        {
            int number = 1;

            foreach (Character character in characters)
            {
                Console.Write($"{number}. {character.Name} ");
                PrintHealth(character);
                Console.WriteLine();
                ++number;
            }
        }

        // Source of this code: https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations.
        // Modified it so it only prints the Actions from the character parameter.
        public static void PrintCharacterActions(Character character)
        {
            int count = 1;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ActionNames nameEnum in character.Actions)
            {
                stringBuilder.Append($"{count}. {nameEnum.GetDescription()}\n");
                ++count;
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        public static void PrintTurn(Battle battle, Character character)
        {
            PrintBattleStatus(battle, character);
            Console.Write($"\n\nIt is {character.Name}'s ");
            PrintHealth(character);
            Console.WriteLine(" turn:");
        }

        public static void PrintBattleStatus(Battle battle, Character actor)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("================================================================\n");
            Console.ResetColor();

            Console.Write("HEROES: |");
            PrintCharacterList(battle._heroes, actor);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n===========================VERSUS===============================\n");
            Console.ResetColor();

            Console.Write("MONSTERS: |");
            PrintCharacterList(battle._monsters, actor);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n================================================================");
            Console.ResetColor();
        }

        private static void PrintCharacterList(List<Character> characters, Character actor)
        {
            foreach(Character character in characters)
            {
                if (character == actor)
                {
                    Console.Write($"> ");
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{actor.Name}");
                    Console.ResetColor();
                    Console.Write($" <|");
                }
                else if (character.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($" {character.Name}");
                    Console.ResetColor();
                    Console.Write($" |");
                }
                else
                    Console.Write($" {character.Name} |");
            }    
        }

        public static void PrintHealth(Character character)
        {
            if(character.Health > 0)
            {
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{character.Health}");
                Console.ResetColor();
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{character._maxHealth}");
                Console.ResetColor();
                Console.Write(")");
            }
            else
            {
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{character.Health}");
                Console.ResetColor();
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{character._maxHealth}");
                Console.ResetColor();
                Console.Write(")");
            }

        }
        
        public static string GetHealthStatus(Character character)
        {
            string health = new($"( HP: {character.Health} / {character._maxHealth} )");
            return health;
        }
    }
}
