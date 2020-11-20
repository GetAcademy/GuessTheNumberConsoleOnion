using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GuessTheNumber
{
    class OldProgram
    {
        private static byte _correctNumber;
        private static List<byte> _guesses;
        private static Random _random = new Random();

        static void MainX(string[] args)
        {
            NewGame();
            while (true)
            {
                Show();
                var command = Console.ReadLine();
                var isNumber = byte.TryParse(command, out byte number);
                if (command == "N") NewGame();
                else if (command == "S") SaveGame();
                else if (command == "L") LoadGame();
                else if (command == "X") return;
                else if (isNumber) Guess(number);
                else Console.WriteLine("Ukjent kommando: " + command);
            }
        }

        private static void Show()
        {
            Console.Clear();
            Console.WriteLine("Jeg tenker på et tall mellom 0 og 100. Gjett tallet!");

            if (_guesses.Count > 0) ShowGuesses();
            else Console.WriteLine("Du har ikke tippet noe tall ennå.");

            Console.WriteLine("Kommandoer: \r\n N = nytt spill\r\n S = skrive spill til fil\r\n L = lese inn spill fra fil\r\n X = avslutte\r\n <tall> = gjette tall\r\n");
            Console.Write("> ");
        }

        private static void ShowGuesses()
        {
            Console.WriteLine("Du har tippet dette så langt:");
            foreach (var guess in _guesses)
            {
                var evaluation =
                    guess < _correctNumber ? "for lavt" :
                    guess > _correctNumber ? "for høyt" :
                    "riktig!";
                Console.WriteLine($"{guess} ({evaluation})");
            }
        }

        private static void NewGame()
        {
            _correctNumber = (byte)_random.Next(0, 100);
            _guesses = new List<byte>();
        }

        private static void SaveGame()
        {
            var bytes = new byte[_guesses.Count + 1];
            bytes[0] = _correctNumber;
            var guesses = _guesses.ToArray();
            Array.Copy(
                guesses,
                0,
                bytes,
                1,
                guesses.Length);
            File.WriteAllBytes("guessGame1.bin", bytes);
        }

        private static void LoadGame()
        {
            var bytes = File.ReadAllBytes("guessGame1.bin");
            _correctNumber = bytes[0];
            var guesses = new byte[bytes.Length - 1];
            Array.Copy(bytes, 1, guesses, 0, guesses.Length);
            _guesses = guesses.ToList();

        }

        private static void Guess(byte number)
        {
            _guesses.Add(number);
        }

    }
}
