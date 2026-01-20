namespace BackJoon
{
    class BackJoon1697 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1697 숨바꼭질
            X + 1, X - 1, X * 2 / 로 이동할 수 있을때 동생을 찾을 가장 빠른 시간을 구해라
 
            ** 아이디어 ** 
            BFS 
            각 위치에서 이동가능한 경로 Queue에 넣으며 탐색
            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int k = input[1];

            int[] time = new int[100001];
            Array.Fill(time, -1);

            time[n] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                int[] nextPos = { cur + 1, cur - 1, cur * 2 };

                foreach (var next in nextPos)
                {
                    if (next >= 0 && next < time.Length && time[next] == -1)
                    {
                        time[next] = time[cur] + 1;

                        if (next == k)
                        {
                            break;
                        }

                        queue.Enqueue(next);
                    }
                }
            }

            writer.WriteLine(time[k]);
            writer.Flush();
        }
    }
}