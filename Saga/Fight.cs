using System;

namespace CourseApp
{
    public class Fight
    {
        public static Tuple<Player, Player> TFights(Player fighter, Player fighterEnemy)
        {
            Random rnd = new Random();
            while ((fighter.Hp > 0) && (fighterEnemy.Hp > 0))
            {
                if (rnd.Next(1, 6) == 1)
                {
                    fighter.Effects = true;
                }
                else if (rnd.Next(1, 6) == 3)
                {
                    fighterEnemy.Effects = true;
                }

                if ((fighter.StandTime > 0) && (fighter.Hp > 0))
                {
                    Logger.LogText($"({fighter.Class}) {fighter.Name} пропускает ход");
                    fighter.StandTime--;
                }
                else if (fighter.Hp > 0)
                {
                    fighterEnemy.GetDamage(fighter.Attack(fighter, fighterEnemy));
                    Logger.LogText($"({fighter.Class}) {fighter.Name}  наносит {fighter.DamageInfo} едениц урона ({fighterEnemy.Class}) {fighterEnemy.Name}");
                }

                if ((fighterEnemy.StandTime > 0) && (fighterEnemy.Hp > 0))
                {
                    Logger.LogText($"({fighterEnemy.Class}) {fighterEnemy.Name} пропускает ход");
                    fighterEnemy.StandTime--;
                }
                else if (fighterEnemy.Hp > 0)
                {
                    fighter.GetDamage(fighterEnemy.Attack(fighter, fighterEnemy));
                    Logger.LogText($"({fighterEnemy.Class}) {fighterEnemy.Name} наносит {fighterEnemy.DamageInfo} едениц урона ({fighter.Class}) {fighter.Name}");
                }
            }

            return new Tuple<Player, Player>(fighter, fighterEnemy);
        }
    }
}