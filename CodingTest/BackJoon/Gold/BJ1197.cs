namespace BackJoon
{
    class BackJoon1197 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1197 최소 스패닝 트리
            주어진 그래프의 모든 정점들을 연결하는 부분 그래프 중에서 그 가중치의 합이 최소의 트리를 구해라

            ** 아이디어 ** 
            크루스칼 알고리즘
            모든 간선을 가중치 기준 오름차순 정렬
            Union-Find 활용하여 가중치 낮은 간선부터 확인 후 연결

            ** 시간 복잡도 **
            O(E log E)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] parent;

        public void Solution()
        {
            int[] ve = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int v = ve[0];
            int e = ve[1];
            
            parent = new int[v + 1];
            for(int i = 1; i <= v; i++) parent[i] = i;

            (int v1, int v2, int w)[] edges = new (int v1, int v2, int w)[e];
            for(int i = 0; i < e; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                edges[i] = (input[0], input[1], input[2]);
            }

            Array.Sort(edges, (e1, e2) => e1.w.CompareTo(e2.w));

            long totalWeight = 0;
            for(int i = 0; i < e; i++)
            {
                var curEdge = edges[i];

                int root1 = Find(curEdge.v1);
                int root2 = Find(curEdge.v2);

                if(root1 != root2)
                {
                    Union(root1, root2);
                    totalWeight += curEdge.w;
                }
            }

            writer.WriteLine(totalWeight);
            writer.Flush();
        }

        private int Find(int x)
        {
            if(parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        private void Union(int a, int b)
        {
            if(a != b)
            {
                parent[b] = a;
            }
        }
    }
}