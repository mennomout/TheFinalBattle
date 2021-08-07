using System;
using System.Collections.Generic;

namespace FinalBattle
{
    public static class Action
    {
        public static readonly string _basicAttack = "basic attack";
        public static readonly string _doNothing = "do nothing";

        public static void DoNothing(Character character) => Console.WriteLine($"{character.Name} did nothing this round");
        public static void BasicAttack(Character attackingCharacter, Character targetCharacter) => targetCharacter.TakeDamage(attackingCharacter.BaseDamage);

        public static List<string> ActionList(Character character)
        {
            List<string> actions = new() { _basicAttack, _doNothing };

            // differentiate between CharacterTypes here if/else add to action choice

            return actions;
        }
    }
}
