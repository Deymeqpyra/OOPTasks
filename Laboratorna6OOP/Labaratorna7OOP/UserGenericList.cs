using System.Collections;
public class UserGenericList<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;
    private class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T value)
        {
            Value = value;
        }
    }
    public void AddFirst(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            head = tail = newNode;
        }
        newNode.Next = head; 
        head.Previous = newNode;
        head = newNode;
        count++;
    }

    public void AddLast(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        tail.Next = newNode;
        newNode.Previous = tail;
        tail = newNode;
        count++;
    }

    public void Clear()
    {
        head = tail = null;
        count = 0;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public T Find(T value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current.Value;
            }
            current = current.Next;
        }
        return default(T);
    }

    public T FindLast(T value)
    {
        var current = tail;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current.Value;
            }
            current = current.Previous;
        }
        return default(T);
    }

    public bool RemoveFirst()
    {
        if (head == null) return false;

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Previous = null;
        }

        count--;
        return true;
    }

    public bool RemoveLast()
    {
        if (tail == null) return false;

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Previous;
            tail.Next = null;
        }

        count--;
        return true;
    }

    public bool Remove(T value)
    {
        var current = head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current == head) RemoveFirst();
                else if (current == tail) RemoveLast();
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    count--;
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    public int Count => count;

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
