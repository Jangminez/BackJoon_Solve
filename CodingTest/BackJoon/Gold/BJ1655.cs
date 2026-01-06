namespace BackJoon
{
    class BackJoon1655 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1655 가운데를 말해요
            정수를 하나씩 얘기하면 지금까지 말한 수 중에서 중간값을 말해야함
            말한 정수의 수 (배열의 길이)가 짝수면 중간값 2개 중에 더 작은 수 

            ** 필요 변수 **
            int n 입력값, 외치는 정수의 개수 
            int[] numbers 외치는 정수를 담아놓을 배열

            ** 아이디어 ** 
            우선순위 큐
            max_heap(left) 과 min_heap(right)으로 나눠서 구현
            원하는 출력값은 max_heap의 최상단 값
            max_heap.Enqueue(value, -value) -> 큰값이 우선순위가 높도록 '-' 부호 
            서로 값의 역전되면 Swap
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());

            PriorityQueue<int, int> left_heap = new PriorityQueue<int, int>();
            PriorityQueue<int,int> right_heap = new PriorityQueue<int, int>();
            for(int i = 0; i < n; i++)
            {
                int value = int.Parse(reader.ReadLine());
                
                if(i % 2 == 0)
                    left_heap.Enqueue(value, -value);
                else
                    right_heap.Enqueue(value, value);
                

                if(right_heap.Count > 0 && left_heap.Peek() > right_heap.Peek())
                {
                    int left = left_heap.Dequeue();
                    int right = right_heap.Dequeue();

                    left_heap.Enqueue(right, -right);
                    right_heap.Enqueue(left, left);
                }

                writer.WriteLine(left_heap.Peek());
            }


            writer.Flush();
        }
    }
}