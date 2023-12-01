using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericArrayList<T>
{
    private ArrayList array;

    public GenericArrayList()
    {
        array = new ArrayList();
    }

    public T this[int index]
    {
        get
        {
            return (T)array[index];
        }
        set
        {
            array[index] = value;
        }
    }

    public void Add(T item)
    {
        array.Add(item);
    }

    public void insert(int index,  T item)
    {
        array.Insert(index, item);
    }

    public void Remove(int index)
    {
        array.RemoveAt(index);
    }

    public void Remove(T item)
    {
        array.Remove(item);
    }

    public int size()
    {
        return array.Count;
    }

    public void Clear()
    {
        array.Clear();
    }
}
