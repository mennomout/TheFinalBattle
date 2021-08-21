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
            while (keyPres != ConsoleKey.Enter)
            {
                Display();
                MenuNavigation();
            }
            return SelectDifficutly();
        }

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
