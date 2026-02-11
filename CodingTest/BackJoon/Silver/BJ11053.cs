namespace BackJoon
{
    class BackJoon11053 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            11053 가장 긴 증가하는 부분 수열
            수열 A가 주어졌을 때 가장 긴 증가하는 부분 수열을 구해라

            ** 아이디어 ** 
            DP
            dp[i] : i가 포함된 가장 긴 증가하는 부분 수열의 길이 

            ** 시간 복잡도 **
            O(N²)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int[] arr = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int[] dp = new int[n];
            Array.Fill(dp, 1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            writer.WriteLine(dp.Max());
            writer.Flush();
        }
    }
}