namespace BackJoon
{
    public class BackJoon2178 : IBackJoon
    {
        // BFS & DFS 공통
        static int n, m;
        static int[,] map;
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };

        // BFS 변수
        static int[,] distance;

        // DFS 변수
        static bool[,] visited;
        static int minDist;

        public void Solution()
        {
            int[] sizeInput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            n = sizeInput[0];
            m = sizeInput[1];

            map = new int[n, m];
            distance = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string inputMap = Console.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    map[i, j] = inputMap[j] - '0';
                }
            }

            // BFS
            distance[0, 0] = 1;
            BFS(0, 0);

            // DFS
            // visited[0, 0] = true;
            // DFS(0, 0, 1);

            Console.WriteLine(distance[n - 1, m - 1]);
        }

        public void BFS(int x, int y)
        {
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            while (queue.Count > 0)
            {
                var curPos = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nx = curPos.x + dx[i];
                    int ny = curPos.y + dy[i];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < m)
                    {
                        if (map[nx, ny] == 1 && distance[nx, ny] == 0)
                        {
                            distance[nx, ny] = distance[curPos.x, curPos.y] + 1;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
            }
        }

        // DFS + 백트래킹 (시간 초과 : 100 * 100)
        public void DFS(int x, int y, int dist)
        {
            if (dist >= minDist) return;

            if (x == n - 1 && y == m - 1)
            {
                minDist = Math.Min(minDist, dist);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < n && ny >= 0 && ny < m)
                {
                    if (map[nx, ny] == 1 && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        DFS(nx, ny, dist + 1);
                        visited[nx, ny] = false;
                    }
                }
            }
        }
    }
}