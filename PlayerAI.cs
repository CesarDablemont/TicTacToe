using System;

namespace TicTacToe
{
  class PlayerAI : APlayer
  {
    private Random random = new Random();

    public PlayerAI(Cell cell) : base(cell)
    {
    }

    public override int ChooseMove(Board board)
    {
      int bestMove = -1;
      int bestScore = int.MinValue;
      for (int i = 0; i < 9; i++)
      {
        if (board.BoardCell(i) == Cell.Empty)
        {
          // Essayer ce coup
          board.WriteCell(i, TheCell);
          int score = Minimax(board, 0, false, TheCell);
          board.WriteCell(i, Cell.Empty); // Réinitialiser la case car on a pas de copie du board

          // Mettre à jour le meilleur coup
          if (score > bestScore)
          {
            bestScore = score;
            bestMove = i;
          }
          // Si le il y a un autre coup equivalant on met de l'aléatoire
          else if (score == bestScore)
          {
            if (random.Next(3) == 0 || bestMove == -1)
            {
              bestScore = score;
              bestMove = i;
            }
          }
        }
      }
      return bestMove;
    }

    int Minimax(Board board, int depth, bool isMaximizingPlayer, Cell player)
    {
      Cell opponent = (player == Cell.X) ? Cell.O : Cell.X;

      if (board.IsWinningPlayer(player)) return 100 / (depth + 1); // L'IA gagne
      if (board.IsWinningPlayer(opponent)) return -100 / (depth + 1); // Le joueur gagne
      if (board.IsBoardFull()) return 0; // Match nul


      AIDifficultyMode[] values = (AIDifficultyMode[])Enum.GetValues(typeof(AIDifficultyMode));
      int position = Array.IndexOf(values, Board.aiDifficultyMode);
      int maxDepth = 9 - position;

      if (isMaximizingPlayer)
      {
        int bestScore = int.MinValue;
        for (int i = 0; i < maxDepth; i++)
        {
          if (board.BoardCell(i) == Cell.Empty)
          {
            board.WriteCell(i, player);
            int score = Minimax(board, depth + 1, false, player);
            board.WriteCell(i, Cell.Empty);
            bestScore = Math.Max(bestScore, score);
          }
        }
        return bestScore;
      }
      else
      {
        int bestScore = int.MaxValue;
        for (int i = 0; i < maxDepth; i++)
        {
          if (board.BoardCell(i) == Cell.Empty)
          {
            board.WriteCell(i, opponent);
            int score = Minimax(board, depth + 1, true, player);
            board.WriteCell(i, Cell.Empty); // Réinitialiser la case
            bestScore = Math.Min(bestScore, score);
          }
        }
        return bestScore;
      }
    }

  }
}