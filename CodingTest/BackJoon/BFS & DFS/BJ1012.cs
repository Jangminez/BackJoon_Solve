namespace BackJoon
{
    public class BackJoon1012 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1. 배추들이 상하좌우로 인접해 있는 '군집(덩어리)'의 총 개수를 구하는 문제
            2. 지렁이 한 마리가 인접한 모든 배추를 보호할 수 있으므로, 군집의 수 = 필요한 지렁이 수
            3. 테스트 케이스(T)가 주어지므로 매 케이스마다 맵과 방문 기록 초기화 필요

            ** 필요 변수 **
            int t, m, n, k : 테스트 케이스, 가로, 세로, 배추 개수
            int[,] farm : 배추 위치 저장 (1: 배추, 0: 빈 땅)
            bool[,] visited : 방문 여부 체크 (중복 방문 및 무한 루프 방지)
            int needWorm : 필요한 지렁이 총 개수 (결과값)

            ** 알고리즘 ** 
            맵의 크기가 최대 50 * 50 = 2,500으로 작음 -> DFS 재귀 또는 BFS 모두 가능
            이중 for문으로 맵 전체를 순회하며 '방문하지 않은 배추' 발견 시 탐색 시작
            탐색(DFS/BFS)이 한 번 끝날 때마다 지렁이 수(needWorm) +1
        */
        
        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int t, m, n, k;
        static int[,] farm;
        static bool[,] visited;

        static int[] dm = { 0, 1, 0, -1 };
        static int[] dn = { 1, 0, -1, 0 };

        static int needWorm;

        public void Solution()
        {
            t = int.Parse(reader.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] testCaseInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                m = testCaseInput[0];
                n = testCaseInput[1];
                k = testCaseInput[2];

                farm = new int[m, n];
                visited = new bool[m, n];
                needWorm = 0;

                // 농장에 배추 심기
                for (int j = 0; j < k; j++)
                {
                    int[] cabbageInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

                    farm[cabbageInput[0], cabbageInput[1]] = 1;
                }

                for (int a = 0; a < m; a++)
                {
                    for (int b = 0; b < n; b++)
                    {
                        if (farm[a, b] == 1 && !visited[a, b])
                        {
                            needWorm++;
                            DFS(a, b);
                        }
                    }
                }

                writer.WriteLine(needWorm);
            }


            writer.Flush();
        }

        public void DFS(int startM, int startN)
        {
            visited[startM, startN] = true;

            for (int i = 0; i < 4; i++)
            {
                int nm = startM + dm[i];
                int nn = startN + dn[i];

                if (nm >= 0 && nm < m && nn >= 0 && nn < n)
                {
                    if (farm[nm, nn] == 1 && !visited[nm, nn])
                    {
                        DFS(nm, nn);
                    }
                }
            }
        }

        public void BFS(int startM, int startN)
        {
            Queue<(int m, int n)> queue = new Queue<(int m, int n)>();
            queue.Enqueue((startM, startN));
            visited[startM, startN] = true;

            while (queue.Count > 0)
            {
                var curPos = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nm = curPos.m + dm[i];
                    int nn = curPos.n + dn[i];

                    if (nm >= 0 && nm < m && nn >= 0 && nn < n)
                    {
                        if (farm[nm, nn] == 1 && !visited[nm, nn])
                        {
                            visited[nm, nn] = true;
                            queue.Enqueue((nm, nn));
                        }
                    }
                }
            }
        }
    }
}