using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle
{
    public class GameModeMenu : Menu
    {
        public GameModeMenu()
        {
            _menuOptions = new() { "COMPUTER vs COMPUTER", "PLAYER vs COMPUTER", "PLAYER vs PLAYER" };
        }

        public (Player, Player) CreatePlayers()
        {
            while (_keyPres != ConsoleKey.Enter)
            {
                Display();
                MenuNavigation();
            }
            return SelectMode();
        }

        private (Player, Player) SelectMode()
        {
            Console.Clear();
            return _selectedIndex switch
            {
                0 => (new AI("HEROES", true), new AI("MONSTERS", false)),
                1 => (new Human("HEROES", true), new AI("MONSTERS", false)),
                2 => (new Human("HEROES", true), new Human("MONSTERS", false)),
                _ => CreatePlayers()
            };
        }
    }
}
