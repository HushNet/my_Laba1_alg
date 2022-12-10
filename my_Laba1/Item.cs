namespace my_Laba1;

public class Item
{
    public int value = 0; //само значение
    public Item next = null; //ссылка на след item

    //базовый конструктор как класс, тк значение передается по ссылке. работа идет из области в памяти
    public Item(int value, Item next)
    {
        this.value = value;
        this.next = next;
    }
}