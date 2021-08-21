using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle
{
    public class DifficultyMenu : Menu
    {
        public DifficultyMenu()
        {
            _menuOptions = new() { "EASY", "MEDIUM", "HARD" };
        }

        public int LevelDificulty()
        {
            while (_keyPres != ConsoleKey.Enter)
            {
                Display();
                MenuNavigation();
            }
            return SelectDifficutly();
        }

        // Returns a integer that represents the amount of battles in a level.
        private int SelectDifficutly()
        {
            Console.Clear();
            return _selectedIndex switch
            {
                0 => 1,
                1 => 2,
                2 => 3,
                _ => LevelDificulty()
            };
        }
    }
}
