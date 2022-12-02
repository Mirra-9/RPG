using System;

namespace CourseApp
{
    public class Wizard : Player
    {
        public Wizard()
        {
            Class = "Wizard";
            AbilityName = "Fascination"; // очарование
        }

        public override int Ability(Player player, Player enemy)
        {
            enemy.StandTime = 2;
            Logger.LogText($"({Class}) {Name} использовал способность {AbilityName}");
            return 0;
        }

        public override string ToString()
        {
            return $"Class: {Class}. Name: {Name}. Strength: {Strength}. Health: {Hp}.";
        }
    }
}
