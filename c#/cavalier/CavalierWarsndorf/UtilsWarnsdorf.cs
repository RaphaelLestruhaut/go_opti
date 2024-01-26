using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavalierWarsndorf
{
    class UtilsWarnsdorf
    {
        public static int[] move_x = [2, 1, -1, -2, -2, -1, 1, 2];
        public static int[] move_y = [1, 2, 2, 1, -1, -2, -2, -1];
        public static int size = 0;

        public static void boardDisplay(int[][] board)
        {
            for (int x = 0; x < board.Length; x++)
            {
                string s = "";
                for (int y = 0; y < board[x].Length; y++)
                {
                    s += board[x][y] + " ";
                }
                Console.WriteLine(s);
            }
            Console.WriteLine("-----");
        }

        public static bool isMoveInvalid(int[][] board, int x, int y)
        {
            return x < 0 || x >= size || y < 0 || y >= size || board[x][y] != 0;
        }

        public static (int, int)[] getMoves(int[][] board, int x, int y)
        {
            List<(int, int)> moves = new List<(int, int)>();

            for (int i = 0; i < UtilsWarnsdorf.move_x.Length; i++)
            {
                int temp_x = move_x[i] + x;
                int temp_y = move_y[i] + y;
                if (!UtilsWarnsdorf.isMoveInvalid(board, temp_x, temp_y))
                {
                    moves.Add((temp_x, temp_y));
                }
            }
            return moves.ToArray();
        }

        public static bool playWarsndorf(int[][] board, int x, int y, int nombreMouvement)
        {
            board[x][y] = nombreMouvement;
            (int, int)[] moves = UtilsWarnsdorf.getMoves(board, x, y);
            if (moves.Length == 0)
            {
                bool win = nombreMouvement == size * size;
                if (!win)
                {
                    board[x][y] = 0;
                    return false;
                }
                else
                {
                    UtilsWarnsdorf.boardDisplay(board);
                    Console.WriteLine("VICTORY");
                    return true;
                }
            }
            List<(int, (int, int))> possibleMoves = [];
            foreach (var move in moves)
            {
                (int, int)[] newMove = UtilsWarnsdorf.getMoves(board, move.Item1, move.Item2);
                if (newMove.Length != 0 || nombreMouvement + 1 == size * size)
                {
                    possibleMoves.Add((newMove.Length, move));
                }
            }
            possibleMoves.Sort();
            foreach (var move in possibleMoves)
            {
                if (playWarsndorf(board, move.Item2.Item1, move.Item2.Item2, nombreMouvement + 1))
                {
                    return true;
                }
            }
            board[x][y] = 0;
            return false;
        }
    }
}
