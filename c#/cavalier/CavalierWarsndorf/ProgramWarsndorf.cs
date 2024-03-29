﻿using CavalierWarsndorf;

class Hello
{
    static void Main()
    {
        DateTime t0 = DateTime.Now;
        int n = 8;
        int[][] board = new int[n][];

        for (int i = 0; i < n; i++)
        {
            board[i] = new int[n];
        }

        /*int[][] board = [
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1]
        ];*/


        UtilsWarnsdorf.boardDisplay(board);

        UtilsWarnsdorf.size = n;

        UtilsWarnsdorf.playWarsndorf(board, 0, 0, 1);
        DateTime t1 = DateTime.Now;
        Console.WriteLine(t1 - t0);
        Console.WriteLine(n);
    }
}