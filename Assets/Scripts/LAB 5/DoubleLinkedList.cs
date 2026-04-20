using Sirenix.OdinInspector.Editor.Validation;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DoubleLinkedList<T> //: MonoBehaviour
{
    public Node<T> head = null;
    public Node<T> tail = null;
    public int Count;
    public Node<T> pivot;

    //->O(1)
    public virtual void Add(T value)
    {
        Node<T> newNode = new(value);

        //-> Cuando no hay nuingun elemento en la lista
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            pivot = newNode; 
        }
        else if(head != null )
        {
            tail.SetNext(newNode);
            newNode.SetPrev(tail);
            tail = newNode;
            pivot = newNode;
        }
        Count++;
    }


    //->O(1)
    public virtual void RemoveLast()
    {

        //Node<T> Evaluator = head;

        if (Count == 0)
        {
            Debug.Log("La lista esta vacia");
            return;
        }
        else if (Count == 1)
        {
            head = null;
            tail = null;
            Count--;
        }
        else if (Count >= 2)
        {
            Node<T> Evaluator = tail.Prev;
            tail.SetPrev(null);
            Evaluator.SetNext(null);
            tail = Evaluator;


            Count--;
        }
       

    }
    //-> O(1)
    public virtual void RemoveFirst()
    {

        if (Count <= 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }

        Node<T> Evaluator = head.Next;
        head.SetNext(null);
        head = Evaluator;
        Count--;


    }

    public virtual void RemoveFromPosition(Node<T> position) 
    {
        if (position.Next == tail)
        {
            RemoveLast();
            return;
        }
        if(position == head)
        {
            RemoveFirst();
            return;
        }
        position.Next.SetPrev(null);
        position.SetNext(null);
        tail = position;

        ReCount();

    }

    public void ReCount()
    {
        Count = 0;
        Node<T> Evaluator = head;
        while (Evaluator != null)
        {
            Count++;
            Evaluator = Evaluator.Next;
        }
    }

    public virtual void TraverseInOrder(Action<Node<T>> action)
    {
        Node<T> Evaluator = head;
        while (Evaluator != null)
        {
            //  Debug.Log(Evaluator.Value);
            action(Evaluator);

            Evaluator = Evaluator.Next;
        }
    }
    public virtual void TraverseInReverse(Action<Node<T>> action)
    {
        Node<T> Evaluator = tail;
        while (Evaluator != null)
        {
            //  Debug.Log(Evaluator.Value);
            action(Evaluator);

            Evaluator = Evaluator.Prev;
        }
    }

    public void MoveNext()
    {
        if (pivot != null && pivot.Next != null)
        {
            pivot = pivot.Next;
        }
    }

    public void MovePrev()
    {
        if (pivot != null && pivot.Prev != null)
        {
            pivot = pivot.Prev;
        }
    }

    public void AddWithRewrite(T value)
    {
       
        if (pivot != tail) // Si el pivote no es el último nodo, eliminamos los nodos siguientes al pivote
        {
            RemoveFrom(pivot.Next);
        }

        Node<T> newNode = new(value);

        pivot.SetNext(newNode);
        newNode.SetPrev(pivot);

        tail = newNode;
        pivot = newNode;

        Count++;
    }

}
