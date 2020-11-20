using System;
using System.Collections.Generic;
using System.Text;
using GuessTheNumber.DomainModel;

namespace GuessTheNumber.DomainServices
{
    public interface IGameRepository
    {
        Game LoadGame();
        void SaveGame(Game game);
    }
}
