using System;

namespace TicTacToe
{
  class Demo : APlayer
  {

    private Random random = new Random();

    public Demo(Cell cell) : base(cell)
    {
    }

    public override int ChooseMove(Board board)
    {
      int position;
      do
      {
        position = random.Next(9);
      } while (board.BoardCell(position) != Cell.Empty);
      return position;
    }
  }
}