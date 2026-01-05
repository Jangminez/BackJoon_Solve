namespace BackJoon
{
    class BackJoon1926 : IBackJoon
    {   
        static int n, m;
        static int[,] graph;
        static bool[,] visited;
        static int[] dx = { 1, -1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        public void Solution()
        {
            int[] sizeInput = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            n = sizeInput[0];
            m = sizeInput[1];

            graph = new int[n, m];
            visited = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                int[] inputGraph = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
                for (int j = 0; j < m; j++)
                {
                    graph[i, j] = inputGraph[j];
                }
            }

            int cnt = 0;
            int maxSize = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (graph[i, j] == 1 && !visited[i, j])
                    {
                        cnt++;

                        int size = BFS(i, j);
                        maxSize = Math.Max(maxSize, size);
                    }
                }
            }

            Console.WriteLine(cnt);
            Console.WriteLine(maxSize);
        }

        public int BFS(int x, int y)
        {
            Queue<(int x, int y)> queue = new Queue<(int, int)>();
            queue.Enqueue((x, y));

            visited[x,y] = true;
            int size = 1;

            while(queue.Count > 0)
            {
                var xy = queue.Dequeue();

                for(int i = 0; i < 4; i++)
                {
                    int nx = xy.x + dx[i];
                    int ny = xy.y + dy[i];

                    if(nx >= 0 && nx < n && ny >= 0 && ny < m && graph[nx, ny] == 1 && !visited[nx, ny])
                    {
                        queue.Enqueue((nx, ny));
                        visited[nx, ny] = true;
                        size++;
                    }
                }
            }

            return size;
        }
    }
}