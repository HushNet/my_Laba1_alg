using System.Diagnostics;

namespace my_Laba1
{
    internal class Program
    {

        public static ulong N_op = 0;

        static void Main(string[] args)
        {
            Queue queue = new Queue();
            Random rand = new Random();



            for (int i = 1; i <= 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                for (int j = 0; j < 300; j++)
                {
                    queue.Push(rand.Next(1, 3000));
                }
                stopwatch.Start();
                insSort(queue);
                stopwatch.Stop();
                Console.WriteLine($"Номер сортировки: {i} Количество отсортированных элементов: {queue.size} " +
                                  $"Время сортировки(ms): {stopwatch.ElapsedMilliseconds} " +
                                  $"Количество операций (N_op): {N_op + queue.GetNop()}");
            }

            

            

            Console.ReadLine();
        }
        
        static void Swap(Queue deck, int i, int j) // 1 + 5 + n * 15 + 11 + 30n = 17 + 45n
        {
            N_op += 1;
            var temp = deck.Get(i); // 1
            deck.Set(i, deck.Get(j)); // 5 + n * 15 + 6 + n * 15 = 11 + 30n
            deck.Set(j, temp); // 5 + n * 15
            
        }
        

        static void insSort(Queue queue) // 2 + n * (log2(n) * (12 + 15n) + 1 + 17(n/2)^2 + 45n(n/2)^2) = 2 + 15n^2log(n) + 12nlog(n) + 7n + 45/4
        {
            int j, k;

            for (int i = 1; i < queue.size; i++) // 2 + n * (log2(n) * (12 + 15n) + 1 + 17(n/2)^2 + 45n(n/2)^2)
            {
                N_op += 1;
                k = binSearch(queue, queue.Get(i), 0, i); // log2(n) * (12 + 15n) + 1

                N_op += 2;
                for (int m = i; m > k; m--) // (n/2)^2 * (17 + 45n) = 17(n/2)^2 + 45n(n/2)^2
                {
                    N_op += 2;
                    Swap(queue, m - 1, m); // 17 + 45n
                }
            }



        }
        public static int binSearch(Queue queue, int key, int l, int r) // log2(n) * (12 + 15n) + 1
        {
            int m;
            
            while (l <= r) // log2(n) * (3 + 9 + 15n) + 1 = log2(n) * (12 + 15n)
            {
                N_op += 3; 
                m = (l + r) / 2; // 3
                N_op += 2;
                if (queue.Get(m) < key) // 6 + n * 15 + 1 + 2 = 9 + 15n
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            N_op += 1;
            return l; // 1
        }


            
    }
}