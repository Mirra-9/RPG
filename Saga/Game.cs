using System;
using System.Collections.Generic;
using System.Collections;

namespace CourseApp
{
    public class Game
    {
        public static int StartGame(int playersInGame)
        {
            Logger.LogText("Введите количество игроков: ");
            playersInGame = Convert.ToInt32(Console.ReadLine());
            while ((playersInGame % 2 != 0) || (playersInGame < 1))
            {
                Logger.LogText("Введите количество игроков: ");
                playersInGame = Convert.ToInt32(Console.ReadLine());
            }

            return playersInGame;
        }
    }
}