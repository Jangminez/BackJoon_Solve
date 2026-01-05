namespace BackJoon
{
    class BackJoon2579 : IBackJoon
    {
        /*
            ** 문제 요약 **
            계단은 한 번에 한 계단 or 두 계단씩 오를 수 있음 (각 계단에는 점수)
            연속된 3개의 계단을 모두 밟아서는 안됨
            마지막 계단은 무조건 밟아야함
            -> 계단을 오르며 얻을 수 있는 점수 총합의 최대값

            계단 개수 (1 ~ 300)
            계단 점수 (1 ~ 10,000)

            ** 필요 변수 **
            int n 총 계단의 개수
            int[] scores 계단의 점수

            ** 아이디어 ** 
            DP (동적 프로그래밍)
            dp[,] 테이블 = [현재 계단의 번호, 연속으로 밟은 계단의 수] 
            
            점화식
            dp[i, 1] = Math.Max(dp[i - 2, 1], dp[i - 2, 2]) + scores[i]
            dp[i, 2] = dp[i - 1, 1] + scores[i]

            시간 복잡도 : O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n;
        static int[,] dp;
        static int[] scores;

        public void Solution()
        {
            n = int.Parse(reader.ReadLine());

            dp = new int[n + 1, 3];
            scores = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                scores[i] = int.Parse(reader.ReadLine());
            }

            dp[1, 1] = scores[1];
            if (n >= 2)
            {
                dp[2, 1] = scores[2];
                dp[2, 2] = scores[1] + scores[2];
            }



            for (int i = 3; i <= n; i++)
            {
                dp[i, 1] = Math.Max(dp[i - 2, 1], dp[i - 2, 2]) + scores[i];
                dp[i, 2] = dp[i - 1, 1] + scores[i];
            }

            writer.WriteLine(Math.Max(dp[n, 1], dp[n, 2]));
            writer.Flush();
        }
    }
}