using System;

namespace TicTacToe
{
  static class Input
  {

    static public int ReadKey(int min, int max)
    {
      int choice;
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.SetCursorPosition(0, Console.CursorTop);
        int.TryParse(keyInfo.KeyChar.ToString(), out choice);
      } while (choice < min || choice > max);
      return choice;
    }

    static public int ReadLine(int min, int max)
    {
      int choice;
      do
      {
        int.TryParse(Console.ReadLine(), out choice);
      } while (choice < min || choice > max);
      return choice;
    }

    static public int Menu()
    {
      int x = 15; //2
      int y = 8;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > 8) y -= 2;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < 10) y += 2;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter) return (y - 8) / 2;
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      }
    }


    static public int Settings()
    {
      int initX = 2;
      int initY = 5;
      int deltaY = 2;
      int numberOfChoice = 4;

      int x = initX;
      int y = initY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberOfChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter) return (y - initY) / deltaY;
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }

    static public void StartMode()
    {
      int initX = 2;
      int initY = 5;
      int deltaY = 2;
      int numberOfChoice = 4;

      int x = initX;
      int y = initY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberOfChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          StartMode[] StartModeValues = (StartMode[])Enum.GetValues(typeof(StartMode));
          Board.startMode = StartModeValues[(y - initY) / deltaY];
          break;
        }
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }

    static public void PlayerColor(APlayer player)
    {
      int initX = 2;
      int initY = 5;
      int deltaX = 22;
      int deltaY = 2;
      int numberChoiceX = 2;
      int numberChoiceY = 6;

      int x = initX;
      int y = initY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.DownArrow && (y == (initY + ((numberChoiceY - 1) * deltaY))) && (x == initX))
        {
          x = initX + deltaX;
          y = initY;
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow && (y == initY) && (x == (initX + ((numberChoiceX - 1) * deltaX))))
        {
          x = initX;
          y = initY + ((numberChoiceY - 1) * deltaY);
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberChoiceY - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.LeftArrow && x > initX) x -= deltaX;
        else if (keyInfo.Key == ConsoleKey.RightArrow && x < (initX + ((numberChoiceX - 1) * deltaX))) x += deltaX;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          int pNum = 0;
          if (player.TheCell == Cell.O) pNum = 1;
          string? colorName = Enum.GetName(typeof(Colors), ((y - initY) / deltaY) + 6 * (x - initX) / deltaX);
          Board.PlayerColors[pNum] = Enum.TryParse(colorName, out ConsoleColor parsedColor) ? parsedColor : ConsoleColor.White;
          // if (colorName != null)
          // {
          //   if (Enum.TryParse(colorName, out ConsoleColor parsedColor))
          //     Board.PlayerColors[pNum] = parsedColor;
          // }

          break;
        }
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }

    static public void AIDifficultyMode()
    {
      int initX = 2;
      int initY = 5;
      int deltaY = 2;
      int numberOfChoice = 5;

      int x = initX;
      int y = initY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberOfChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          AIDifficultyMode[] AIDifficultyModeValues = (AIDifficultyMode[])Enum.GetValues(typeof(AIDifficultyMode));
          Board.aiDifficultyMode = AIDifficultyModeValues[(y - initY) / deltaY];
          break;
        }
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }
  }
}