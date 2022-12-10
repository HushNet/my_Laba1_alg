namespace my_Laba1;

public class Queue
{
    private Item head = null;
    private Item tail = null;
    public int size = 0;
    public static int N_op = 0;

    //добавляет в конец списка новый эл-т
    public void Push(int value) // 7
    {
        Item item = new Item(value, null); // 1
        if (head == null) // 2
        {
            head = item;
        }

        ;
        if (tail != null) // 2
        {
            tail.next = item;
        }

        tail = item; // 1
        size++; // 1
    }

    public int Pop() // 6
    {
        if (head == null)
        {
            throw new Exception("Queue is empty!!!");
        }

        int val = head.value; // 1
        head = head.next; // 1
        if (size == 1) tail = null; // 2
        size--; // 1

        return val; // 1
    }

    // 345
    public int Get(int index) // 2 + n/2 * (13 + 2) + 2 + n/2 * (13 + 2) +  1 + 1 = 6 + n * 15
    {
        for (int i = 0; i < index; i++) // 2 + n/2 * (13 + 2)
        {
            Push(Pop()); // 13
        }

        int val = head.value; // 1
        for (int i = index; i < size; i++) //  2 + n/2 * (13 + 2)
        {
            Push(Pop()); // 13
        }

        return val; // 1
    }


    public void Set(int index, int newValue) // 2 + n/2 * (13 + 2) + 2 + n/2 * (13 + 2) + 1 = 5 + n * 15
    {
        for (int i = 0; i < index; i++) // 2 + n/2 * (13 + 2)
        {
            Push(Pop());
        }

        head.value = newValue; // 1
        for (int i = index; i < size; i++) // 2 + n/2 * (13 + 2)
        {
            Push(Pop());
        }
    }


    public void Print()
    {
        Item current = head;
        while (current != null)
        {
            Console.Write(" " + current.value);
            current = current.next;
        }

        Console.WriteLine();
    }

    public int GetNop()
    {
        return N_op;
    }
}