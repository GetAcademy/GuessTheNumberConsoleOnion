using System;
using GuessTheNumber.DomainModel;
using GuessTheNumber.DomainServices;

namespace GuessTheName.ApplicationServices
{
    public class GameService
    {
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game NewGame()
        {
            return new Game();
        }

        public void SaveGame(Game game)
        {
            _gameRepository.SaveGame(game);
        }

        public Game LoadGame()
        {
            return _gameRepository.LoadGame();
        }

        public void Guess(Game game, int number)
        {
            game.Guess(number);
        }
    }
}
