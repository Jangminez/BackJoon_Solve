namespace BackJoon
{
    class BackJoon2206 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            2206 벽 부수고 이동하기
            N * M 크기의 맵, 상하좌우 이동, 1개까지 벽 부시기 가능
            최단 경로를 구해라

            ** 아이디어 ** 
            BFS
            벽을 부순 상태를 관리하며 그래프 탐색

            ** 시간 복잡도 **
            O(N * M * 2)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] dy = { 1, 0, -1, 0 };
        static int[] dx = { 0, 1, 0, -1 };
        static int[,] map;
        static bool[,,] visited;

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int m = input[1];

            map = new int[n, m];
            visited = new bool[n, m, 2];
            for (int i = 0; i < n; i++)
            {
                string mapInput = reader.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = mapInput[j] - '0';
                }
            }

            Queue<(int y, int x, int crashed, int dist)> queue = new Queue<(int y, int x, int crashed, int dist)>();
            visited[0, 0, 0] = true;
            queue.Enqueue((0, 0, 0, 1));
            int result = 0;
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                if (cur.y == n - 1 && cur.x == m - 1)
                {
                    result = cur.dist;
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int ny = cur.y + dy[i];
                    int nx = cur.x + dx[i];

                    if (ny >= 0 && ny < n && nx >= 0 && nx < m)
                    {
                        if (map[ny, nx] == 0)
                        {
                            if (!visited[ny, nx, cur.crashed])
                            {
                                visited[ny, nx, cur.crashed] = true;
                                queue.Enqueue((ny, nx, cur.crashed, cur.dist + 1));
                            }
                        }
                        else if (map[ny, nx] == 1)
                        {
                            if (cur.crashed == 0 && !visited[ny, nx, 1])
                            {
                                visited[ny, nx, 1] = true;
                                queue.Enqueue((ny, nx, 1, cur.dist + 1));
                            }
                        }
                    }

                }
            }

            writer.WriteLine(result == 0 ? -1 : result);
            writer.Flush();
        }
    }
}