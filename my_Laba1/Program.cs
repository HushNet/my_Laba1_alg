namespace my_Laba1
{
    internal class Program
    {

        public static int N_op = 0;

        static void Main(string[] args)
        {
            Queue queue = new Queue();


            queue.Push(1);
            queue.Push(4);
            queue.Push(5);
            queue.Push(7);
            queue.Push(0);
            queue.Push(8);
            
            queue.Print();


            insSort(queue);
            
            queue.Print();
            Console.ReadLine();
        }
        
        static void Swap(Queue deck, int i, int j) // 1 + 5 + n * 15 + 11 + 30n = 17 + 45n
        {
            var temp = deck.Get(i); // 1
            deck.Set(i, deck.Get(j)); // 5 + n * 15 + 6 + n * 15 = 11 + 30n
            deck.Set(j, temp); // 5 + n * 15
            
        }
        

        static void insSort(Queue queue)
        {
            int j, k;

            for (int i = 1; i < queue.size; i++)
            {
                j = i - 1;
                k = binSearch(queue, queue.Get(i), 0, j);

                
                for (int m = j; m >= k; m--)
                {
                    Swap(queue, m, m + 1);
                    queue.Print();
                }
            }



        } // 52314

        public static int binSearch(Queue queue, int key, int l, int r)
        {
            int m;

            while (l < r - 1)
            {
                m = (l + r) / 2;
                if (queue.Get(m) < key)
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            } // 0  3 2 5  2

            return r;
        }


            
    }
}