namespace BackJoon
{
    class BackJoon2252 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            2252 줄 세우기
            일부 학생들의 키를 비교한 결과를 가지고 줄을 세워라
            여러가지면 아무거나 출력

            ** 아이디어 ** 
            위상 정렬
            진입 차수 관리 : 자신 보다 앞서야 할 학생의 수 카운트
            진입 차수 0인 학생들 먼저 Queue에 삽입
            큐에서 꺼내 줄 세우고, 그 뒤에 서야하는 학생들의 진입 차수 감소 (해당 학생의 진입차수가 0이라면 Queue에 삽입)
            위 과정 반복

            ** 시간 복잡도 **
            O(V + M)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] nm = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = nm[0];
            int m = nm[1];

            List<int>[] adj = new List<int>[n + 1];
            for(int i = 1; i <= n; i++) adj[i] = new List<int>();

            int[] indegree = new int[n + 1]; 
            for(int i = 0; i < m; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                int a = input[0];
                int b = input[1];

                adj[a].Add(b);
                indegree[b]++;
            }

            Queue<int> queue = new Queue<int>();
            for(int i = 1; i <= n; i++)
            {
                if(indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
            
            List<int> result = new List<int>();
            while(queue.Count > 0)
            {
                int cur = queue.Dequeue();

                result.Add(cur);

                foreach(int s in adj[cur])
                {
                    indegree[s]--;

                    if(indegree[s] == 0) 
                        queue.Enqueue(s);
                }
            }

            foreach(int s in result)
            {
                writer.Write($"{s} ");
            }
            writer.Flush();
        }
    }
}