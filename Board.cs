using System;

namespace TicTacToe
{
  public enum Cell
  {
    Empty,
    X,
    O
  }

  public enum GameState
  {
    InGame,
    Victory,
    Draw
  }

  public enum StartMode
  {
    P1,
    P2,
    Alternate,
    LastLose
  }

  public enum Colors
  {
    Red,
    Green,
    Yellow,
    Blue,
    Magenta,
    Cyan,
    DarkRed,
    DarkGreen,
    DarkYellow,
    DarkBlue,
    DarkMagenta,
    DarkCyan
  }

  public enum AIDifficultyMode
  {
    Impossible,
    Hard,
    Intermediate,
    Easy,
    Noob
  }


  class Board
  {
    Cell[] board { get; set; } = new Cell[9];
    static public StartMode startMode { get; set; } = StartMode.P1;
    public APlayer? startPlayer { get; set; }
    public APlayer? losePlayer { get; set; }
    static public ConsoleColor[] PlayerColors { get; set; } = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Blue };
    public static AIDifficultyMode aiDifficultyMode { get; set; } = AIDifficultyMode.Impossible;

    public void NewBoard()
    {
      for (int i = 0; i < 9; i++)
        board[i] = Cell.Empty;
    }

    public Cell BoardCell(int position)
    {
      return board[position];
    }

    public void WriteCell(int position, Cell value)
    {
      board[position] = value;
    }


    public bool IsBoardFull()
    {
      for (int i = 0; i < 9; i++)
        if (BoardCell(i) == Cell.Empty) return false;
      return true;
    }

    public bool DoesGameHasAWinner()
    {
      for (int i = 0; i < 9; i += 3) // cas ligne horizontal
        if ((BoardCell(i) != Cell.Empty) && (BoardCell(i) == BoardCell(i + 1)) && (BoardCell(i + 1) == BoardCell(i + 2))) return true;
      for (int i = 0; i < 3; i++) // cas ligne vertical
        if ((BoardCell(i) != Cell.Empty) && (BoardCell(i) == BoardCell(i + 3)) && (BoardCell(i + 3) == BoardCell(i + 6))) return true;
      // cas ligne diagonale vers le bas
      if ((BoardCell(0) != Cell.Empty) && (BoardCell(0) == BoardCell(4)) && (BoardCell(4) == BoardCell(8))) return true;
      // cas ligne diagonale vers le haut
      if ((BoardCell(2) != Cell.Empty) && (BoardCell(2) == BoardCell(4)) && (BoardCell(4) == BoardCell(6))) return true;
      return false;
    }

    public bool IsWinningPlayer(Cell cell)
    {
      for (int i = 0; i < 9; i += 3) // cas ligne horizontal
        if ((BoardCell(i) == cell) && (BoardCell(i) == BoardCell(i + 1)) && (BoardCell(i + 1) == BoardCell(i + 2))) return true;
      for (int i = 0; i < 3; i++) // cas ligne vertical
        if ((BoardCell(i) == cell) && (BoardCell(i) == BoardCell(i + 3)) && (BoardCell(i + 3) == BoardCell(i + 6))) return true;
      // cas ligne diagonale vers le bas
      if ((BoardCell(0) == cell) && (BoardCell(0) == BoardCell(4)) && (BoardCell(4) == BoardCell(8))) return true;
      // cas ligne diagonale vers le haut
      if ((BoardCell(2) == cell) && (BoardCell(2) == BoardCell(4)) && (BoardCell(4) == BoardCell(6))) return true;
      return false;
    }

    public int[] WinningPlayerCells()
    {
      // renvoyer la ligne gagnante et test le vainqueur sur la ligne gagnante
      int[] winCells = new int[3];

      // cas ligne horizontal
      for (int i = 0; i < 9; i += 3)
      {
        if ((BoardCell(i) == BoardCell(i + 1)) && (BoardCell(i + 1) == BoardCell(i + 2)) && (BoardCell(i) != Cell.Empty))
        {
          winCells[0] = i;
          winCells[1] = i + 1;
          winCells[2] = i + 2;
          return winCells;
        }
      }
      // cas ligne vertical
      for (int i = 0; i < 3; i++)
      {
        if ((BoardCell(i) == BoardCell(i + 3)) && (BoardCell(i + 3) == BoardCell(i + 6)) && (BoardCell(i) != Cell.Empty))
        {
          winCells[0] = i;
          winCells[1] = i + 3;
          winCells[2] = i + 6;
          return winCells;
        }
      }
      // cas ligne diagonale vers le bas
      if ((BoardCell(0) == BoardCell(4)) && (BoardCell(4) == BoardCell(8)) && (BoardCell(0) != Cell.Empty))
      {
        winCells[0] = 0;
        winCells[1] = 4;
        winCells[2] = 8;
        return winCells;
      }
      // cas ligne diagonale vers le haut
      else if ((BoardCell(2) == BoardCell(4)) && (BoardCell(4) == BoardCell(6)) && (BoardCell(2) != Cell.Empty))
      {
        winCells[0] = 2;
        winCells[1] = 4;
        winCells[2] = 6;
        return winCells;
      }

      return winCells;
    }


    public APlayer StartPlayer(APlayer p1, APlayer p2)
    {
      switch (startMode)
      {
        case StartMode.P1:
          return p1;

        case StartMode.P2:
          return p2;

        case StartMode.Alternate:
          if (startPlayer == p1) return p2;
          else return p1;

        case StartMode.LastLose:
          if (losePlayer == p1) return p1;
          else return p2;

        default:
          return p1;
      }
    }

    public void updateLosePlayer(APlayer p1, APlayer p2)
    {
      if (IsWinningPlayer(p1.TheCell)) losePlayer = p2;
      else if (IsWinningPlayer(p2.TheCell)) losePlayer = p1;
      else if (startPlayer == p1) losePlayer = p1;
      else losePlayer = p2;
    }
  }
}