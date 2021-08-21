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
            _keyPres = ConsoleKey.Clear;
            while (_keyPres != ConsoleKey.Enter)
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
