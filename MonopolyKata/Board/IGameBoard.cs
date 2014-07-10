using System;
namespace MonopolyKata.Board
{
    public interface IGameBoard
    {
        void LandOnNewSpace(MonopolyKata.MonopolyPlayer player);
        int GetNumberOfBoardSpaces();
    }
}
