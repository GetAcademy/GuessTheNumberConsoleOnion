using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GuessTheNumber.DomainModel;
using GuessTheNumber.DomainServices;

namespace GuessTheNumber.Infrastructure
{
    public class FileGameRepository : IGameRepository
    {
        public Game LoadGame()
        {
            var bytes = File.ReadAllBytes("guessGame1.bin");
            var correctNumber = bytes[0];
            var guesses = new byte[bytes.Length - 1];
            Array.Copy(bytes, 1, guesses, 0, guesses.Length);
            return new Game(correctNumber, guesses);
        }

        public void SaveGame(Game game)
        {
            var bytes = new byte[game.Guesses.Count + 1];
            bytes[0] = game.CorrectNumber;
            var guesses = game.Guesses.ToArray();
            Array.Copy(
                guesses,
                0,
                bytes,
                1,
                guesses.Length);
            File.WriteAllBytes("guessGame1.bin", bytes);
        }
    }
}
