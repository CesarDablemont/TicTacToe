using System;
using TicTacToe;

internal class Program
{
  static void Main()
  {

    Board board = new Board();
    Display display = new Display();

    APlayer p1 = new PlayerHuman(Cell.X);
    APlayer p2 = new PlayerAI(Cell.O);

    display.hideCursor();
    display.Menu();

    while (true)
    {
      switch (Input.Menu())
      {
        case 0:
          display.showCursor();
          board.startPlayer = board.StartPlayer(p1, p2);
          APlayer player = board.startPlayer;
          GameState gameState = GameState.InGame;

          board.NewBoard();
          display.BoardShow(board, (player == p1) ? p2 : p1);

          while (gameState == GameState.InGame)
          {
            int playerMoov = player.ChooseMove(board);
            board.WriteCell(playerMoov, player.TheCell);
            display.BoardShow(board, player);

            if (board.DoesGameHasAWinner()) gameState = GameState.Victory;
            else if (board.IsBoardFull()) gameState = GameState.Draw;
            player = (player.TheCell == p1.TheCell) ? p2 : p1;
          }

          board.updateLosePlayer(p1, p2);
          display.EndGame(gameState, board);
          Console.ReadKey();
          break;

        case 1:
          display.Settings();
          switch (Input.Settings())
          {
            case 0:
              display.StartMode();
              Input.StartMode();
              break;

            case 1:
              display.PlayerColor();
              Input.PlayerColor(p1);
              break;

            case 2:
              display.PlayerColor();
              Input.PlayerColor(p2);
              break;

            case 3:
              display.AIDifficultyMode();
              Input.AIDifficultyMode();
              break;
          }
          break;

        default:
          display.hideCursor();
          display.Menu();
          break;
      }

      display.hideCursor();
      display.Menu();
    }
  }
}