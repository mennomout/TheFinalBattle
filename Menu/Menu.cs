using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle
{
    public abstract class Menu
    {
        protected List<string> _menuOptions;
        protected int _selectedIndex = 0;
        protected ConsoleKey keyPres;

        protected void Display()
        {
            Console.Clear();

            StringBuilder stringBuilder = new();

            for (int i = 0; i < _menuOptions.Count; ++i)
            {
                if (i == _selectedIndex)
                    stringBuilder.Append($"{Select(_menuOptions[_selectedIndex])}\n");
                else
                    stringBuilder.Append($"{_menuOptions[i]}\n");
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        protected void MenuNavigation()
        {
            keyPres = Console.ReadKey(true).Key;

            if (keyPres == ConsoleKey.UpArrow) Previous();
            if (keyPres == ConsoleKey.DownArrow) Next();
        }

        protected void Next()
        {
            if (_selectedIndex == _menuOptions.Count - 1) _selectedIndex = 0;
            else _selectedIndex += 1;
        }

        protected void Previous()
        {
            if (_selectedIndex == 0) _selectedIndex = _menuOptions.Count - 1;
            else _selectedIndex -= 1;
        }

        protected string Select(string word) => $"[{word}]";
    }
}


