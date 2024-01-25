
using cavalier;

class Hello
{
    static void Main()
    {
        DateTime t0 = DateTime.Now;
        int n = 50;
        int[][] board = new int[n][];

        for (int i = 0; i < n; i++) 
        {
            int[] ligne = new int[50];
            for (int j = 0; j < n; j++)
            {
                ligne[j] = -1;
            }
            board[i] = ligne;
        }

        /*int[][] board = [
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1]
        ];*/

        Utils.boardDisplay(board);

        Utils.size = n;

        Utils.playHeuristique(board, 0, 0, 1);
        DateTime t1 = DateTime.Now;
        Console.WriteLine(t1-t0);
    }
}