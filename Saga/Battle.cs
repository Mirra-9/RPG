using System;
using System.Collections.Generic;

namespace CourseApp
{
    public class Battle
    {
        private static List<Player> players = new List<Player>();
        private static List<Player> winners = new List<Player>();

        public static void Tournament(int playersInGame) // турнир
        {
            Random rnd = new Random();
            while (players.Count < playersInGame)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        players.Add(new Archer());
                        break;
                    case 1:
                        players.Add(new Warrior());
                        break;
                    case 2:
                        players.Add(new Wizard());
                        break;
                }
            }

            Logger.LogText("Давайте взглянем на наших героев!");
            foreach (Player o in players)
            {
                Console.WriteLine(o);
            }

            int tern = 1;
            Logger.LogText("\n");
            Logger.LogText("---------------------------Начинаем турнир-----------------------");
            Logger.LogText($"                               Кон {tern++}-й");
            while (players.Count + winners.Count > 1)
            {
                if (players.Count >= 2)
                {
                    int rndPlayer1 = rnd.Next(0, players.Count);
                    int rndPlayer2 = rnd.Next(0, players.Count);
                    while (rndPlayer1 == rndPlayer2)
                    {
                        rndPlayer2 = rnd.Next(0, players.Count);
                    }

                    Player fighter = players[rndPlayer1]; // боец
                    Player fighterEnemy = players[rndPlayer2]; // враг
                    Logger.LogText($"                ({fighter.Class}) {fighter.Name} VS ({fighterEnemy.Class}) {fighterEnemy.Name}");
                    Fight.TFights(fighter, fighterEnemy);
                    if (fighterEnemy.Hp < 0)
                    {
                        Logger.LogText($"({fighterEnemy.Class}) {fighterEnemy.Name} погиб(ла). \n");
                        fighter.Hp = rnd.Next(70, 300);
                        players.Remove(fighter); // Remove - удаляет игрока из списка игроков
                        players.Remove(fighterEnemy);
                        winners.Add(fighter);
                    }
                    else
                    {
                        Logger.LogText($"({fighter.Class}) {fighter.Name} погиб(ла). \n");
                        fighterEnemy.Hp = rnd.Next(70, 300);
                        players.Remove(fighterEnemy);
                        players.Remove(fighter);
                        winners.Add(fighterEnemy);
                    }
                }

                if ((winners.Count >= 2) && (players.Count == 0))
                {
                    int rndPlayer1 = rnd.Next(0, players.Count);
                    int rndPlayer2 = rnd.Next(0, winners.Count);
                    while (rndPlayer1 == rndPlayer2)
                    {
                        rndPlayer2 = rnd.Next(0, winners.Count);
                    }

                    Player fighter = winners[rndPlayer1];
                    Player fighterEnemy = winners[rndPlayer2];
                    if (winners.Count % 2 == 0)
                    {
                        Logger.LogText($"                               Кон {tern++}-й");
                    }

                    Logger.LogText($"                ({fighter.Class}) {fighter.Name} VS ({fighterEnemy.Class}) {fighterEnemy.Name}");
                    Fight.TFights(fighter, fighterEnemy);
                    if (fighterEnemy.Hp < 0)
                    {
                        Logger.LogText($"({fighterEnemy.Class}) {fighterEnemy.Name} погиб(ла). \n");
                        fighter.Hp = rnd.Next(70, 300);
                        winners.Remove(fighterEnemy);
                    }
                    else
                    {
                        Logger.LogText($"({fighter.Class}) {fighter.Name} погиб(ла). \n");
                        fighterEnemy.Hp = rnd.Next(70, 300);
                        winners.Remove(fighter);
                    }
                }
            }

            Logger.LogText($"Победитель турнира: ({winners[0].Class}) {winners[0].Name}");
            Logger.LogText("---------------------------Конец турнира-------------------------");
        }
    }
}