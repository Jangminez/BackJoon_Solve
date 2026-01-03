namespace BackJoon
{
    class Program
    {
        /*
            ** 문제 요약 **
            R * C 크기의 보드
            상하좌우 인접한 네 칸중 한 칸 
            새로 이동한 칸의 알파벳 != 지금까지 나온 칸의 알파벳
            좌측 상단 시작
            지날 수 있는 최대 칸 수

            ** 필요 변수 **
            int r, c
            보드 int[,]
            방문여부 bool[,]
            지나온 알파벳 int[26] A - Z 
            지나온 칸의 수

            ** 알고리즘 ** 
            보드의 최대 크기 = 20 * 20 = 400 => DFS 재귀 가능
            백트래킹
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int r, c;
        static char[,] board;

        static int[] alphabets = new int[26];
        static int maxDist = 1; // 시작 칸 포함


        static int[] dr = { 0, 1, 0, -1 };
        static int[] dc = { 1, 0, -1, 0 };

        static void Main(string[] args)
        {
            new Program().Solution();
        }

        public void Solution()
        {
            int[] sizeInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            r = sizeInput[0];
            c = sizeInput[1];

            board = new char[r, c];

            for (int i = 0; i < r; i++)
            {
                string alphabetInput = reader.ReadLine();

                for (int j = 0; j < c; j++)
                {
                    board[i, j] = alphabetInput[j];
                }
            }

            DFS(0, 0, maxDist);

            writer.WriteLine(maxDist);
            writer.Flush();
        }

        public void DFS(int y, int x, int dist)
        {
            alphabets[board[y, x] - 'A'] = 1;
            maxDist = Math.Max(maxDist, dist);

            for (int i = 0; i < 4; i++)
            {
                int ny = y + dr[i];
                int nx = x + dc[i];

                if (ny >= 0 && ny < r && nx >= 0 && nx < c)
                {
                    if (alphabets[board[ny, nx] - 'A'] != 1)
                    {
                        DFS(ny, nx, dist + 1);
                    }
                }
            }

            // 백트래킹을 위한 방문 여부 제거
            alphabets[board[y, x] - 'A'] = 0;
        }
    }
}