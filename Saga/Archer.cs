using System;

namespace CourseApp
{
    public class Archer : Player
    {
        public Archer()
        {
            Class = "Archer";
            AbilityName = "Fire arrows";
        }

        public override int Ability(Player player, Player enemy)
        {
            AbilityDamage = 2;
            Logger.LogText($"({Class}) {Name} использовал способность {AbilityName}");
            return Strength + AbilityDamage;
        }

        public override string ToString()
        {
            return $"Class: {Class}. Name: {Name}. Strength: {Strength}. Health: {Hp}.";
        }
    }
}