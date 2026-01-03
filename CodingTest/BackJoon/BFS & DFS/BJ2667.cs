using System.Security.Cryptography.X509Certificates;

namespace BackJoon
{
    public class BackJoon2667 : IBackJoon
    {
        static int n;
        static int[,] map;
        static bool[,] visited;
        static int[] dx = [0, 1, 0, -1];
        static int[] dy = [1, 0, -1, 0];

        static int cnt;

        public void Solution()
        {
            n = int.Parse(Console.ReadLine());
            map = new int[n, n];
            visited = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                string inputMap = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    map[i, j] = inputMap[j] - '0';
                }
            }

            List<int> houseCntList = new List<int>();

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (map[x, y] != 1 || visited[x, y]) continue;
                    cnt = 0;
                    DFS(x, y);
                    houseCntList.Add(cnt);
                }
            }

            houseCntList.Sort();

            Console.WriteLine(houseCntList.Count);
            foreach (var count in houseCntList)
            {
                Console.WriteLine(count);
            }
        }

        public int BFS(int x, int y)
        {
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));

            visited[x, y] = true;
            int houseCnt = 1;

            while (queue.Count > 0)
            {
                var xy = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nx = xy.x + dx[i];
                    int ny = xy.y + dy[i];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < n)
                    {
                        if (map[nx, ny] == 1 && !visited[nx, ny])
                        {
                            queue.Enqueue((nx, ny));
                            visited[nx, ny] = true;
                            houseCnt++;
                        }
                    }
                }
            }

            return houseCnt;
        }

        public void DFS(int x, int y)
        {
            visited[x, y] = true;
            cnt++;

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < n && ny >= 0 && ny < n)
                {
                    if (map[nx, ny] == 1 && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        DFS(nx, ny);
                    }
                }
            }
        }
    }
}