using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Level
    {
        private List<Battle> Battles { get; set; }
        private Player Heroes { get; set; }
        private Player Monsters { get; set; }
        
        public Level(Player heroes, Player monsters, params Battle[] battles) 
        {
            Battles = new(battles);
            Heroes = heroes;
            Monsters = monsters;
        }

        public void Play()
        {
            foreach (Battle battle in Battles)
            {
                battle.Start(Heroes, Monsters);
                if (battle.HeroesLost)
                    break;
                else
                    BetweenBattlesMessage();
            }
            EndMessage();
        }

        private void EndMessage()
        {
            string winnerName = "default";

            foreach (Battle battle in Battles)
                if (battle.CheckCharactersDeath(battle._heroes))
                    winnerName = "MONSTERS";
                else
                    winnerName = "HEROES";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================\n");
            Console.WriteLine($"{winnerName} WON THE BATTLE!!!");
            Console.WriteLine("\n==========================================");
            Console.ResetColor();

            Console.WriteLine("\nPress 'Enter' to return to the main menu.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }

        private void BetweenBattlesMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================\n");
            Console.WriteLine($"HEROES WON THE BATTLE!!!");
            Console.WriteLine("\n==========================================");
            Console.ResetColor();

            Console.WriteLine("\nPress 'Enter' to start the next battle!!!");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
    }
}
