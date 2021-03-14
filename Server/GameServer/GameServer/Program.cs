using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";

            Server.Start(100, 1337);

            Console.ReadKey();
        }
    }
}
