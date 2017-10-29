using System;

public class ArrayList<T>
{
    private const int Capacity = 2;
    private T[] items;

    public ArrayList()
    {
        this.items = new T[Capacity];
    }
    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.items[index];
        }

        set
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count == this.items.Length)
        {
            this.Resize();
        }
        this.items[this.Count++] = item;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        T item = this.items[index];
        for (int i = index; i < this.Count; i++)
        {
            this.items[i] = this.items[i + 1];
        }
        this.Count--;
        return item;
    }

    private void Resize()
    {
        T[] copy = new T[this.items.Length * 2];
        for (int i = 0; i < this.items.Length; i++)
        {
            copy[i] = this.items[i];
        }
        this.items = copy;
    }
}
