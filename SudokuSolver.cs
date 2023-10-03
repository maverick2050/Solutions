public class Solutions
{

    public static void Main(string[] args)
    {
        LeetCoding l = new LeetCoding();
        l.TotalNQueens(4);
    }

    //box_index = (row / 3) * 3 + column / 3
    List<HashSet<int>> rws = new List<HashSet<int>>();
    List<HashSet<int>> cols = new List<HashSet<int>>();

    Dictionary<string, HashSet<int>> visited = new Dictionary<string, HashSet<int>>();

    List<HashSet<int>> boxes = new List<HashSet<int>>();
    char[][] resboard;

    public void SolveSudoku(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            boxes.Add(new HashSet<int>());
        }

        for (int i = 0; i < 9; i++)
        {
            HashSet<int> col = new HashSet<int>();
            HashSet<int> rw = new HashSet<int>();
            for (int j = 0; j < 9; j++)
            {
                int idx = (i / 3) * 3 + j / 3;

                if (board[i][j] != '.')
                {
                    rw.Add(int.Parse(board[i][j].ToString()));
                    boxes[idx].Add(int.Parse(board[i][j].ToString()));
                }

                if (board[j][i] != '.')
                {
                    col.Add(int.Parse(board[j][i].ToString()));
                }
            }

            cols.Add(col);
            rws.Add(rw);
        }
        resboard = board;
        BT(-1, -1);

    }


    private int getnumberToPlaceAt(int r, int c)
    {
        for (int i = 1; i <= 9; i++)
        {
            if ((!visited.ContainsKey(r.ToString() + c.ToString()) || !visited[r.ToString() + c.ToString()].Contains(i)) && !cols[c].Contains(i) && !boxes[(r / 3) * 3 + c / 3].Contains(i) && !rws[r].Contains(i))
            {
                return i;
            }
        }

        return -1;
    }
    private void BT(int row, int col)
    {
        if (row == -1 && col == -1)
        {
            row = 0; col = 0;
        }
        else
        {
            int val = getnumberToPlaceAt(row, col);
            if (val == -1)
            {
                visited.Remove(row.ToString() + col.ToString());
                rws[row].Remove(Convert.ToInt32(resboard[row][col]));
                cols[col].Remove(Convert.ToInt32(resboard[row][col]));
                boxes[(row / 3) * 3 + col / 3].Remove(Convert.ToInt32(resboard[row][col]));
                resboard[row][col] = '.';
                return;
            }

            resboard[row][col] = (char)(val + '0');

            if (!visited.ContainsKey(row.ToString() + col.ToString()))
            {
                visited.Add(row.ToString() + col.ToString(), new HashSet<int> { val });
            }
            else
            {
                visited[row.ToString() + col.ToString()].Add(val);
            }

            rws[row].Add(val);
            cols[col].Add(val);
            int idx = (row / 3) * 3 + col / 3;
            boxes[idx].Add(val);
        }

        for (int i = row; i < 9; i++)
        {
            for (int j = col; j < 9; j++)
            {
                if (resboard[i][j] == '.')
                {
                    BT(i, j);
                    int val = getnumberToPlaceAt(row, col);
                    if (val == -1)
                    {
                        visited.Remove(row.ToString() + col.ToString());
                        rws[row].Remove(Convert.ToInt32(resboard[row][col]));
                        cols[col].Remove(Convert.ToInt32(resboard[row][col]));
                        boxes[(row / 3) * 3 + col / 3].Remove(Convert.ToInt32(resboard[row][col]));
                        resboard[row][col] = '.';
                        return;
                    }
                    else
                    {
                        resboard[row][col] = (char)(val + '0');

                        if (!visited.ContainsKey(row.ToString() + col.ToString()))
                        {
                            visited.Add(row.ToString() + col.ToString(), new HashSet<int> { val });
                        }
                        else
                        {
                            visited[row.ToString() + col.ToString()].Add(val);
                        }

                        rws[row].Add(val);
                        cols[col].Add(val);
                        int idx = (row / 3) * 3 + col / 3;
                        boxes[idx].Add(val);
                        i=row;
                        j=col;
                    }
                }
            }
        }
    }
}
