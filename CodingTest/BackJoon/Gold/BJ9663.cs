namespace BackJoon
{
    class BackJoon9663 : IBackJoon
    {
        /*
            ** 문제 요약 **
            N x N 체스판에서 N개의 퀸을 서로 공격하지 못하게 배치하는 경우의 수

            ** 필요 변수 **
            int n 입력값
            int[] board index 가 행, 값은 열
            int cnt 가능한 방법의 수 카운팅

            ** 아이디어 ** 
            백트래킹
            첫 행부터 한 칸씩 퀸을 놓는다
            놓을때마다 유효한지 체크 (가로, 세로, 대각선)
            가능하면 다음 행으로, 불가능 하면 다른 칸
            N만큼의 행에 도달하면 모든 퀸을 놓았으므로 카운트 증가
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n;
        static int[] board;
        static int cnt = 0;

        public void Solution()
        {
            n = int.Parse(reader.ReadLine());

            board = new int[n];

            DFS(0);

            writer.WriteLine(cnt);
            writer.Flush();
        }

        public void DFS(int row)
        {
            if (row == n)
            {
                cnt++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsPossible(row, col))
                {
                    board[row] = col;
                    DFS(row + 1);
                }
            }
        }

        public bool IsPossible(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                // 세로 & 대각선 체크
                if (board[i] == col || Math.Abs(row - i) == Math.Abs(col - board[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}