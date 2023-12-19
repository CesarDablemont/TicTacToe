using System;
using System.Drawing;

namespace TicTacToe
{
  static class Input
  {
    static int LastMenuChoice { get; set; } = 0;
    static int LastSettingsChoice { get; set; } = 0;

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
      int initX = 14;
      int initY = 8;
      int deltaY = 2;
      int numberOfChoice = 3;

      int x = initX;
      int y = initY + LastMenuChoice * deltaY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberOfChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          LastMenuChoice = (y - 8) / deltaY;
          return LastMenuChoice;
        }
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
      int y = initY + LastSettingsChoice * deltaY;
      while (true)
      {
        Display.WriteAtPosition(x, y, "X");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow && y > initY) y -= deltaY;
        else if (keyInfo.Key == ConsoleKey.DownArrow && y < (initY + ((numberOfChoice - 1) * deltaY))) y += deltaY;
        else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
        {
          LastSettingsChoice = (y - initY) / deltaY;
          return LastSettingsChoice;
        }
        else return -1;
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }

    static public void StartMode()
    {
      int initX = 2;
      int initY = 5;
      int deltaY = 2;
      int numberOfChoice = 4;

      StartMode[] values = (StartMode[])Enum.GetValues(typeof(StartMode));
      int startModeIndex = Array.IndexOf(values, Board.startMode);

      int x = initX;
      int y = initY + startModeIndex * deltaY;
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
        else break;
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

      int pNum = 0;
      if (player.TheCell == Cell.O) pNum = 1;

      string playerColor = Board.PlayerColors[pNum].ToString();
      int playerColorIndex = Array.IndexOf(Enum.GetNames(typeof(Colors)), playerColor);
      int playerColorPositionX = playerColorIndex / 6;
      int playerColorPositionY = playerColorIndex % 6;

      int x = initX + playerColorPositionX * deltaX;
      int y = initY + playerColorPositionY * deltaY;
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
          string? colorName = Enum.GetName(typeof(Colors), ((y - initY) / deltaY) + 6 * (x - initX) / deltaX);
          Board.PlayerColors[pNum] = Enum.TryParse(colorName, out ConsoleColor parsedColor) ? parsedColor : ConsoleColor.White;
          // if (colorName != null)
          // {
          //   if (Enum.TryParse(colorName, out ConsoleColor parsedColor))
          //     Board.PlayerColors[pNum] = parsedColor;
          // }

          break;
        }
        else break;
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }

    static public void AIDifficultyMode()
    {
      int initX = 2;
      int initY = 5;
      int deltaY = 2;
      int numberOfChoice = 5;

      AIDifficultyMode[] values = (AIDifficultyMode[])Enum.GetValues(typeof(AIDifficultyMode));
      int aiDifficultyModeIndex = Array.IndexOf(values, Board.aiDifficultyMode);

      int x = initX;
      int y = initY + aiDifficultyModeIndex * deltaY;
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
        else break;
        Display.WriteAtPosition(Console.CursorLeft - 1, Console.CursorTop, " ");
      };
    }
  }
}