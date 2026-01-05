namespace BackJoon
{
    class BackJoon15649 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1 ~ N 까지의 자연수 중 중복 없이 M개를 고른 수열

            ** 필요 변수 **
            int n, m : 문제의 입력값
            bool[] : 방문 여부 확인
            int[] : 현재 선택된 수열을 저장할 배열

            ** 아이디어 ** 
            백트래킹 사용
            1 부터 N까지 루프 돌며 미방문 숫자 선택
            선택 후 재귀, 호출 종료 후 방문 해제
            재귀 종료 조건: depth == M
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, m;
        static bool[] visited;
        static int[] sequence;
        
        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = input[0];
            m = input[1];

            visited = new bool[n + 1];
            sequence = new int[m];

            Recursion(0);

            writer.Flush();
        }

        public void Recursion(int depth)
        {
            if (depth == m)
            {
                for(int i = 0; i < m; i++)
                {
                    writer.Write(sequence[i] + " ");
                }
                writer.WriteLine();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    sequence[depth] = i;
                    Recursion(depth + 1);

                    visited[i] = false;
                }
            }
        }
    }
}