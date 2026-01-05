namespace BackJoon
{
    // 토마토 문제 BFS 시작점 한 번에 넣어놓고 실행
    // 거리를 측정하 듯 day 값 증가 => 최종 위치 값 - 1 = maxDay
    public class BackJoon7576 : IBackJoon
    {
        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int m, n;
        static int[,] map;
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };

        static int maxDay;
        static int zeroCnt;

        public void Solution()
        {
            int[] sizeInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            m = sizeInput[0];
            n = sizeInput[1];

            map = new int[n, m];

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

            for (int i = 0; i < n; i++)
            {
                int[] inputMap = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = inputMap[j];

                    if (map[i, j] == 1) queue.Enqueue((i, j));
                    if (map[i, j] == 0) zeroCnt++;
                }
            }

            BFS(queue);

            if (zeroCnt > 0) writer.WriteLine(-1);
            else writer.WriteLine(maxDay);

            writer.Flush();
        }

        public void BFS(Queue<(int x, int y)> queue)
        {
            while (queue.Count > 0)
            {
                var curPos = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nx = curPos.x + dx[i];
                    int ny = curPos.y + dy[i];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < m)
                    {
                        if (map[nx, ny] == 0)
                        {
                            map[nx, ny] = map[curPos.x, curPos.y] + 1;
                            maxDay = Math.Max(maxDay, map[nx, ny] - 1);
                            zeroCnt--;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
            }
        }
    }
}