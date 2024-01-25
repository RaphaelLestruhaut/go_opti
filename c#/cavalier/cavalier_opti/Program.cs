
using cavalier;

class Hello
{
    static void Main()
    {
        DateTime t0 = DateTime.Now;
        int n = 52;
        int[][] board = new int[n][];

        List<int> list = new List<int>();
        for (int j = 0; j < n; j++)
        {
            list.Add(-1);
        }

        for (int i = 0; i < n; i++)
        {
            board[i] = list.ToArray();
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
        Console.WriteLine(t1 - t0);
    }
}