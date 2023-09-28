public class Solutions
{

    public static void Main(string[] args)
    {
        LeetCoding l = new LeetCoding();
        l.TotalNQueens(4);
    }

    //box_index = (row / 3) * 3 + column / 3

    int[,] rws = new int[9, 9];
    int[,] cls = new int[9, 9];

    Dictionary<string,HashSet<int>> visited=new Dictionary<string, HashSet<int>>();

    List<HashSet<int>> boxes = new List<HashSet<int>>();

    public void solveSudoku(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            boxes.Add(new HashSet<int>());
        }

        for (int i = 0; i < 9; i++)
        {

            for (int j = 0; j < 9; j++)
            {
                int idx = (i / 3) * 3 + j / 3;

                if (board[i][j] != '.')
                {
                    rws[i, j] = Convert.ToInt32(board[i][j]);
                    boxes[idx].Add(board[i][j]);
                }

                if (board[j][i] != '.')
                {
                    cls[j, i] = Convert.ToInt32(board[j][i]);
                }
            }
        }
    }

    private void BT(int row,int col,char[][] board)
    {
        
        



    }
}
