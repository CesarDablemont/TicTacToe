using System;
using System.Threading;

namespace TicTacToe
{
  class Display
  {
    readonly string upArrow = char.ConvertFromUtf32(0x2191);
    readonly string leftArrow = char.ConvertFromUtf32(0x2190);
    readonly string rightArrow = char.ConvertFromUtf32(0x2192);
    readonly string downArrow = char.ConvertFromUtf32(0x2193);
    readonly string enter = char.ConvertFromUtf32(0x21A9);

    // https://www.compart.com/fr/unicode/search?q=diagonal#characters
    readonly string crosse1 = char.ConvertFromUtf32(0x2572); // \
    readonly string crosse2 = char.ConvertFromUtf32(0x2573); // X
    readonly string crosse3 = char.ConvertFromUtf32(0x2571); // /

    // https://www.compart.com/fr/unicode/search?q=arc#characters
    readonly string arc1 = char.ConvertFromUtf32(0x256D); // ╭
    readonly string arc2 = char.ConvertFromUtf32(0x256E); // ╮
    readonly string arc3 = char.ConvertFromUtf32(0x2570); // ╰
    readonly string arc4 = char.ConvertFromUtf32(0x256F); // ╯

    public void hideCursor()
    {
      Console.CursorVisible = false;
    }
    public void showCursor()
    {
      Console.CursorVisible = true;
    }

    public void Menu()
    {
      Console.Clear();
      // https://patorjk.com/software/taag/#p=display&f=Ivrit&t=Morpion
      Console.WriteLine("  _____ _        _____            _____          ");
      Console.WriteLine(" |_   _(_) ___  |_   _|_ _  ___  |_   _|__   ___ ");
      Console.WriteLine("   | | | |/ __|   | |/ _` |/ __|   | |/ _ \\ / _ \\");
      Console.WriteLine("   | | | | (__    | | (_| | (__    | | (_) |  __/");
      Console.WriteLine("   |_| |_|\\___|   |_|\\__,_|\\___|   |_|\\___/ \\___|");
      Console.WriteLine("\n");
      Console.WriteLine("             ┌───┐");
      Console.WriteLine("             │   │  START THE GAME");
      Console.WriteLine("             ├───┤");
      Console.WriteLine("             │   │  SETTINGS");
      Console.WriteLine("             └───┘");
      // Console.SetCursorPosition(2, Console.CursorTop - 4);
    }


    public static void WriteInColor(ConsoleColor color, string text)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Console.ForegroundColor = color;
      Console.Write(text);
      Console.ForegroundColor = originalColor;
    }

    public static void WriteAtPosition(int x, int y, string text)
    {
      Console.SetCursorPosition(x, y);
      Console.Write(text);
    }


    public void Grid()
    {
      Console.WriteLine("     ┌───────┬───────┬───────┐");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     ├───────┼───────┼───────┤");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     ├───────┼───────┼───────┤");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     │       │       │       │");
      Console.WriteLine("     └───────┴───────┴───────┘");

      // display controls
      int x = 39; // centré en x
      int y = 3;
      Console.SetCursorPosition(x - 3, y);
      Console.Write("Controls");
      Console.SetCursorPosition(x - 5, y + 1);
      Console.Write("────────────");
      Console.SetCursorPosition(x, y + 2);
      Console.Write(upArrow);
      Console.SetCursorPosition(x - 2, y + 3);
      Console.Write($"{leftArrow} {enter} {rightArrow}");
      Console.SetCursorPosition(x, y + 4);
      Console.Write(downArrow);
    }

    public void Turn(APlayer player)
    {
      Console.SetCursorPosition(34, 9);
      // NOTE Cell.O = Player 2
      if (player.TheCell == Cell.O) WriteInColor(Board.PlayerColors[0], "Player 1 turn");
      else WriteInColor(Board.PlayerColors[1], "Player 2 turn");
    }

    public void OneCell(Cell cell)
    {
      switch (cell)
      {
        case Cell.Empty:
          Console.Write("     ");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          Console.Write("     ");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          Console.Write("     ");
          break;
        case Cell.X:
          WriteInColor(Board.PlayerColors[0], $" {crosse1} {crosse3} ");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          WriteInColor(Board.PlayerColors[0], $"  {crosse2}  ");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          WriteInColor(Board.PlayerColors[0], $" {crosse3} {crosse1} ");
          break;

        case Cell.O:
          WriteInColor(Board.PlayerColors[1], $"{arc1}───{arc2}");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          WriteInColor(Board.PlayerColors[1], "│   │");
          Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          WriteInColor(Board.PlayerColors[1], $"{arc3}───{arc4}");

          // WriteInColor(Board.PlayerColors[1], " __  ");
          // Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          // WriteInColor(Board.PlayerColors[1], "/  \\ ");
          // Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          // WriteInColor(Board.PlayerColors[1], "\\__/ ");

          // WriteInColor(Board.PlayerColors[1], "/───\\");
          // Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          // WriteInColor(Board.PlayerColors[1], "│   │");
          // Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
          // WriteInColor(Board.PlayerColors[1], "\\───/");
          break;
      }
    }

    public void Cells(Board board)
    {
      for (int y = 0; y < 3; y++)
      {
        for (int x = 0; x < 3; x++)
        {
          Console.SetCursorPosition(7 + 8 * x, 1 + 4 * y);
          OneCell(board.BoardCell(x + y * 3));
        }
      }
      Console.SetCursorPosition(13, 14);
    }

    public void BoardShow(Board board, APlayer player)
    {
      Console.Clear();
      Grid();
      Turn(player);
      Cells(board);
    }


    void ErasedCell(Board board)
    {
      for (int i = 0; i < 3; i++)
      {
        int y = board.WinningPlayerCells()[i] / 3; // ex: 7/3 = 2 (quotient)
        int x = board.WinningPlayerCells()[i] % 3; // ex: 7%3 = 1 (reste)
        Console.SetCursorPosition(7 + 8 * x, 1 + 4 * y);
        OneCell(Cell.Empty);
      }
      Console.SetCursorPosition(13, 14);
    }

    public void Win(Board board)
    {
      Console.CursorVisible = false;
      Console.WriteLine($"The {board.BoardCell(board.WinningPlayerCells()[0])} Win !");

      int numberOfExecutions = 10;
      for (int i = 0; i < numberOfExecutions; i++)
      {
        if (i % 2 != 0)
        {
          Console.Clear();
          Grid();
          Cells(board);
          Console.WriteLine($"The {board.BoardCell(board.WinningPlayerCells()[0])} Win !");
        }
        else ErasedCell(board);

        Thread.Sleep(250);
      }
      Console.CursorVisible = true;
    }

    public void EndGame(GameState gameState, Board board)
    {
      if (gameState == GameState.Victory) Win(board);
      else
      {
        Console.Clear();
        Grid();
        Cells(board);
        Console.Write("  Draw");
      }
    }



    public void Settings()
    {
      Console.Clear();
      // Console.WriteLine("┌────────────────────────────────────────┐");
      // Console.WriteLine("│                SETTINGS                │");
      // Console.WriteLine("└────────────────────────────────────────┘");
      Console.WriteLine("╔════════════════════════════════════════╗");
      Console.WriteLine("║                SETTINGS                ║");
      Console.WriteLine("╚════════════════════════════════════════╝");
      Console.WriteLine();
      Console.WriteLine("┌───┐                   ");
      Console.WriteLine("│   │  Start mode       ");
      Console.WriteLine("├───┤                   ");
      Console.WriteLine("│   │  Player 1 Color   ");
      Console.WriteLine("├───┤                   ");
      Console.WriteLine("│   │  Player 2 Color   ");
      Console.WriteLine("├───┤                   ");
      Console.WriteLine("│   │  AI Difficulty    ");
      Console.WriteLine("└───┘                   ");
    }

    public void StartMode()
    {
      Console.Clear();
      Console.WriteLine("╔════════════════════════════════════════╗");
      Console.WriteLine("║               START MODE               ║");
      Console.WriteLine("╚════════════════════════════════════════╝");
      Console.WriteLine();
      Console.WriteLine("┌───┐                                ");
      Console.WriteLine("│   │  Player 1                      ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Player 2                      ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Alternate P1 / P2             ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Last loser (Alternate if draw)");
      Console.WriteLine("└───┘                                ");
    }

    public void PlayerColor()
    {
      Console.Clear();
      Console.WriteLine("╔════════════════════════════════════════╗");
      Console.WriteLine("║              CHOOSE COLOR              ║");
      Console.WriteLine("╚════════════════════════════════════════╝");
      Console.WriteLine();
      Console.WriteLine("┌───┐                 ┌───┐");
      for (int i = 0; i < 6; i++)
      {
        string? colorName = Enum.GetName(typeof(Colors), i);
        string? colorDarkName = Enum.GetName(typeof(Colors), i + 6);
        if (colorName != null && colorDarkName != null)
        {
          Console.Write("│   │  ");
          if (Enum.TryParse(colorName, out ConsoleColor parsedColor)) WriteInColor(parsedColor, colorName);
          Console.SetCursorPosition(22, Console.CursorTop);
          Console.Write("│   │  ");
          if (Enum.TryParse(colorDarkName, out ConsoleColor parsedColorDark)) WriteInColor(parsedColorDark, colorDarkName);
          if (i < 5) Console.Write("\n├───┤                 ├───┤\n");
        }
      }
      Console.WriteLine("\n└───┘                 └───┘");
    }

    public void AIDifficultyMode()
    {
      Console.Clear();
      Console.WriteLine("╔════════════════════════════════════════╗");
      Console.WriteLine("║           AI Difficulty Mode           ║");
      Console.WriteLine("╚════════════════════════════════════════╝");
      Console.WriteLine();
      Console.WriteLine("┌───┐                                ");
      Console.WriteLine("│   │  Impossible                    ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Hard                          ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Intermediate                  ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Easy                          ");
      Console.WriteLine("├───┤                                ");
      Console.WriteLine("│   │  Noob                          ");
      Console.WriteLine("└───┘                                ");
    }
  }
}