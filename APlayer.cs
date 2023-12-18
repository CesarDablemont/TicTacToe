using System;

namespace TicTacToe
{
    /// <summary>
    /// Define what a player have to do
    /// </summary>
    abstract class APlayer
    {

        /// <summary>
        /// What is the player : X or O
        /// </summary>
        public Cell TheCell { get; private set; }

        /// <summary>
        /// Helper to have the other player
        /// </summary>
        /// <param name="cell">Current player</param>
        /// <returns>Other player</returns>
        public Cell OtherCell(Cell cell)
        {
            if (cell == Cell.X) return Cell.O;
            return Cell.X;
        }

        /// <summary>
        /// Create a new player
        /// </summary>
        /// <param name="cell">X or O</param>
        public APlayer(Cell cell)
        {
            TheCell = cell;
        }

        /// <summary>
        /// Calculate the position to play
        /// </summary>
        /// <param name="board">the current board game</param>
        /// <returns>the position to play (from 0 to 8)</returns>
        public abstract int ChooseMove(Board board);

    }
}