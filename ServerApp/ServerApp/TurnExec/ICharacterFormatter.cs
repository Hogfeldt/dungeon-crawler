using System.Collections.Generic;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface ICharacterFormatter
    {
        List<ICharacter> ToList(ICharacter[,] characterGrid);
        ICharacter[,] ToGrid(List<ICharacter> characterList);
    }
}