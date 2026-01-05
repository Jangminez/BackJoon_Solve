namespace BackJoon
{
    class BackJoon15650 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1 ~ N 까지의 자연수 중 중복 없이 M개를 고른 수열
            단 오름차순만 출력

            ** 필요 변수 **
            int n, m : 문제의 입력값
            int[] : 현재 선택된 수열을 저장할 배열

            ** 아이디어 ** 
            오름차순만 골라서 출력해야함 (조합)
            재귀 호출 시 현재 인덱스보다 큰 값을 다음 루프의 시작점으로 전달
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, m;
        static int[] sequence;

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = input[0];
            m = input[1];

            sequence = new int[m];

            Recursion(1, 0);

            writer.Flush();
        }

        public void Recursion(int start, int depth)
        {
            if (depth == m)
            {
                for (int i = 0; i < m; i++)
                {
                    writer.Write(sequence[i] + " ");
                }
                writer.WriteLine();
                return;
            }

            for (int i = start; i <= n; i++)
            {
                sequence[depth] = i;
                Recursion(i + 1, depth + 1);
            }
        }
    }
}