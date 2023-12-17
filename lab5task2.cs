using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public MyList(params T[] initialValues)
    {
        items = new T[initialValues.Length];
        Array.Copy(initialValues, items, initialValues.Length);
        count = initialValues.Length;
    }

    public MyList(IEnumerable<T> collection)
    {
        items = new T[0];
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = count == 0 ? 4 : count * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }

        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            return items[index];
        }
    }

    public int Count
    {
        get { return count; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class lab5task2
{
    static void Main()
    {
        MyList<int> myList = new MyList<int> { 0, 1, 2, 3};

        myList.Add(777);

        Console.WriteLine($"Elements of my list:\n");
        foreach (var item in myList)
        {
            Console.WriteLine($"Element: {item}");
        }

        Console.WriteLine($"\nTotal number of elements: {myList.Count}");
    }
}
