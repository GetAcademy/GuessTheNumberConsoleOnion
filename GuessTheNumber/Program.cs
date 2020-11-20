using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GuessTheName.ApplicationServices;
using GuessTheNumber.DomainModel;
using GuessTheNumber.Infrastructure;

namespace GuessTheNumber
{
    class Program
    {
        private static Game _game;

        static void Main(string[] args)
        {
            var gameService = new GameService(new FileGameRepository());

            _game = gameService.NewGame();
            while (true)
            {
                Show();
                var command = Console.ReadLine();
                var isNumber = byte.TryParse(command, out byte number);
                if (command == "N") _game = gameService.NewGame();
                else if (command == "S") gameService.SaveGame(_game);
                else if (command == "L") _game = gameService.LoadGame();
                else if (command == "X") return;
                else if (isNumber) gameService.Guess(_game, number);
                else Console.WriteLine("Ukjent kommando: " + command);
            }
        }

        private static void Show()
        {
            Console.Clear();
            Console.WriteLine("Jeg tenker på et tall mellom 0 og 100. Gjett tallet!");

            foreach (var guess in _game.GetGuesses())
            {
                Console.WriteLine(guess);
            }

            Console.WriteLine("Kommandoer: \r\n N = nytt spill\r\n S = skrive spill til fil\r\n L = lese inn spill fra fil\r\n X = avslutte\r\n <tall> = gjette tall\r\n");
            Console.Write("> ");
        }
    }
}
