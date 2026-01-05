namespace BackJoon
{
    class BackJoon12865 : IBackJoon
    {
        /*
            ** 문제 요약 **
            N개의 물건 중 버틸 수 있는 무게(K) 중에서 최대 가치의 짐싸기
            물품의 수 N(1 ~ 100), 준서가 버틸 수 있는 무게 K(1 ~ 100,000)
            그 이후 N개의 줄의 걸친 각 물건의 무게 W(1 ~ 100,000)와 가치 V(1 ~ 1000)

            ** 필요 변수 **
            int n, k 입력값
            int[,] dp [현재 고려한 물건의 개수, 현재 배낭의 무게 한도]
            (int, int)[] items 물건 리스트 

            ** 아이디어 ** 
            DP (동적 프로그래밍)
            현재 물건의 무게 > 한도 : 이전 상태 유지
            현재 물건의 무게 <= 한도 : Math.Max(이전 상태 유지, 현재 물건 가치 + 남은 무게를 채웠던 값)
            시간 복잡도 : O(N * K) = 10,000,000
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, k;
        static int[,] dp;

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = input[0];
            k = input[1];

            dp = new int[n + 1, k + 1];

            (int weight, int value)[] items = new (int weight, int value)[n + 1];
            for (int i = 1; i <= n; i++)
            {
                int[] objects = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                items[i] = (objects[0], objects[1]);
            }

            for(int i = 1; i <= n; i++)
            {
                int weight = items[i].weight;
                int value = items[i].value;

                for(int w = 1; w <= k; w++)
                {
                    if(weight <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], value + dp[i - 1, w - weight]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            writer.WriteLine(dp[n, k]);
            writer.Flush();
        }
    }
}