using System;
public class SimplyLinkedList<T>
{
    public class Node
    {
        public T Value;
        public Node Next;
        public float Weight;

        public Node(T value, float weight = 0)
        {
            Value = value;
            Weight = weight;
            Next = null;
        }
    }
    public Node Head;
    public int Length;
    public void InsertNodeAtStart(T value, float weight = 0)
    {
        Node newNode = new Node(value, weight);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
        Length++;
    }
    public void InsertNodeAtEnd(T value, float weight = 0)
    {
        Node newNode = new Node(value, weight);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = newNode;
        }
        Length++;
    }
    public Node GetNodeAtPosition(int position)
    {
        if (position >= Length || position < 0)
        {
            throw new ArgumentOutOfRangeException("Position is out of range");
        }

        Node current = Head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        return current;
    }
    public T GetValueAtPosition(int position)
    {
        return GetNodeAtPosition(position).Value;
    }
}