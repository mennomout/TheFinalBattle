using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            _menuOptions = new() { "START", "QUIT" };
        }

        public bool Play()
        {
            keyPres = ConsoleKey.Clear;
            while (keyPres != ConsoleKey.Enter)
            {
                Display();
                MenuNavigation();
            }
            return SelectPlay();
        }

        private bool SelectPlay()
        {
            Console.Clear();
            return _selectedIndex switch
            {
                0 => true,
                1 => false,
                _ => Play()
            };
        }
    }
}
