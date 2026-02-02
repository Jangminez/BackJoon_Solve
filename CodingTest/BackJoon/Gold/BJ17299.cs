namespace BackJoon
{
    class BackJoon17299
    {
        /*
            ** 문제 요약 ** 
            17299 오등큰수
            Aᵢ가 수열 A에서 등장한 횟수 F[Aᵢ] 일때 오등큰수를 구해라
            오등큰수 = 오른쪽에 있으면서 수열 A에서 등장한 횟수가 F(Aᵢ)보다 큰 수 중에서 가장 왼쪽에 있는 수

            ** 아이디어 ** 
            스택
            등장 횟수를 저장할 배열 F에 A를 순회하며 등장 횟수 계산 (원소의 값이 인덱스)
            오등큰수를 구하지 못한 인덱스를 Stack에 Push
            현재 원소가 Stack의 최상단 값의 등장 횟수보다 크다면 현재 원소가 최상단 값의 오큰수
            
            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int[] A = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int[] F = new int[1000001];

            for (int i = 0; i < n; i++)
            {
                F[A[i]]++;
            }

            int[] NGF = new int[n];
            Array.Fill(NGF, -1);

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && F[A[stack.Peek()]] < F[A[i]])
                {
                    NGF[stack.Pop()] = A[i];
                }

                stack.Push(i);
            }

            writer.WriteLine(string.Join(" ", NGF));
            writer.Flush();
        }
    }
}