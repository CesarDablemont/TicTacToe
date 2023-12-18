using System;

namespace TicTacToe
{
  class PlayerHuman : APlayer
  {
    public PlayerHuman(Cell cell) : base(cell)
    {
    }

    public override int ChooseMove(Board board)
    {
      // // OLD
      // int initX = 2;
      // int initY = 1;
      // int deltaX = 4;
      // int deltaY = 2;
      int initX = 7;
      int initY = 1;
      int deltaX = 8;
      int deltaY = 4;
      int lineChoice = 3;
      int rowChoice = 3;

      int x = initX + deltaX;
      int y = initY + deltaY;
      int moov = 0;
      bool validMoov = false;
      do
      {
        Console.SetCursorPosition(x, y);
        ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Attend qu'une touche soit pressée
                                                    // Déplace le curseur en fonction de la touche pressée
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((rowChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.LeftArrow && x > initX) x -= deltaX;
        else if (keyInfo.Key == ConsoleKey.RightArrow && x < (initX + ((lineChoice - 1) * deltaX))) x += deltaX;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          moov = (x / deltaX) + 3 * (y / deltaY);
          if (board.BoardCell(moov) == Cell.Empty)
            validMoov = true;
        }
      } while (!validMoov);
      return moov;
    }
  }
}