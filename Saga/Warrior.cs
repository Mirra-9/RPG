using System;

namespace CourseApp
{
    public class Warrior : Player
    {
        public Warrior()
        {
            Class = "Warrior";
            AbilityName = "Retaliation strike"; // ответный удар
        }

        public override int Ability(Player player, Player enemy)
        {
            Logger.LogText($"({Class}) {Name} использовал способность {AbilityName}");
            AbilityDamage = (int)(Strength * 1.4);
            return AbilityDamage;
        }

        public override string ToString()
        {
            return $"Class: {Class}. Name: {Name}. Strength: {Strength}. Health: {Hp}.";
        }
    }
}