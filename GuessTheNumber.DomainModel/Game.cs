using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessTheNumber.DomainModel
{
    public class Game
    {
        public byte CorrectNumber { get; }
        public List<byte> Guesses { get; }

        private static readonly Random Random = new Random();

        public Game(byte correctNumber, byte[] guesses)
        {
            CorrectNumber = correctNumber;
            Guesses = guesses.ToList();
        }

        public Game() : this(
            (byte)Random.Next(0, 100),
            new byte[0])
        {
        }

        public void Guess(int number)
        {
            Guesses.Add((byte)number);
        }

        public string[] GetGuesses()
        {
            if (Guesses.Count == 0)
            {
                return new[] {"Du har ikke tippet noe tall ennå."};
            }
            var lines = new List<string>();
            lines.Add("Du har tippet dette så langt:");
            foreach (var guess in Guesses)
            {
                var evaluation =
                    guess < CorrectNumber ? "for lavt" :
                    guess > CorrectNumber ? "for høyt" :
                    "riktig!";
                lines.Add($"{guess} ({evaluation})");
            }

            return lines.ToArray();
        }
    }
}
