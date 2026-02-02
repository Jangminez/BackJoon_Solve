namespace BackJoon
{
    class BackJoon17298 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            17298 오큰수
            크기가 N인 수열에서 각 원소에 대해 오큰수를 구해라
            오큰수 = 해당 원소보다 더 크고 오른쪽에 있으면서 가장 왼쪽에 있는 수

            ** 아이디어 ** 
            스택
            오큰수를 구하지 못한 인덱스를 Stack에 Push
            현재 원소가 Stack의 최상단 값보다 크다면 현재 원소가 최상단 값의 오큰수
            
            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n;
        static int[] A;

        public void Solution()
        {
            n = int.Parse(reader.ReadLine());
            A = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int[] NGE = new int[n];
            Array.Fill(NGE, -1);

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && A[stack.Peek()] < A[i])
                {
                    NGE[stack.Pop()] = A[i];
                }

                stack.Push(i);
            }

            writer.WriteLine(string.Join(" ", NGE));
            writer.Flush();
        }
    }
}