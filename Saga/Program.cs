using System;

namespace CourseApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------- RPS SAGA -------");
            int playersInGame = 0;
            playersInGame = Game.StartGame(playersInGame);
            Battle.Tournament(playersInGame);

            Console.ReadLine();
        }
    }
}