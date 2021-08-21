using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public class Battle
    {
        public List<Character> _heroes;
        public List<Character> _monsters;
        public readonly int _characterCount;
        public bool HeroesLost { get; private set; }

        public Battle(List<Party> heroParties, List<Party> monsterParties)
        {
            _heroes = ExtractCharacters(heroParties);
            _monsters = ExtractCharacters(monsterParties);
            _characterCount = _heroes.Count + _monsters.Count;
            HeroesLost = false;
        }

        public void Start(Player heroPlayer, Player monsterPlayer)
        {
            while (true)
            {
                Round(heroPlayer, monsterPlayer);

                if(CheckCharactersDeath(_heroes))
                {
                    WinMessage("MONSTERS");
                    HeroesLost = true;
                    break;
                }   
                if(CheckCharactersDeath(_monsters))
                {
                    WinMessage("HEROES");
                    break;
                }
            }
        }

        private void Round(Player heroPlayer, Player monsterPlayer)
        {
            int heroTurn = 0;
            int monsterTurn = 0;

            for (int round = 1; round < _characterCount; ++round)
            {
                if (CheckCharactersDeath(_heroes) || CheckCharactersDeath(_monsters))
                    break;
                Turn(ref heroTurn, _heroes, heroPlayer);
                Turn(ref monsterTurn, _monsters, monsterPlayer);
            }
        }

        private void Turn(ref int turn, List<Character> characters, Player player)
        {
            if (turn >= characters.Count)
                return;

            if (characters[turn].Health > 0)
            {
                Display.PrintTurn(this, characters[turn]);
                player.Turn(characters[turn], this);
                turn++;
            }
            else
                turn++;
        }

        private List<Character> ExtractCharacters(List<Party> parties)
        {
            List<Character> charactersList = new();

            foreach (Party party in parties)
                foreach (Character character in party.Members)
                    charactersList.Add(character);

            return charactersList;
        }

        public bool CheckCharactersDeath(List<Character> characters)
        {
            foreach (Character character in characters)
                if (character.Health > 0)
                    return false;
            return true;
        }

        private void WinMessage(string name) => Console.WriteLine($"{name} won the battle");
    }
}
