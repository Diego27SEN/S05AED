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
            Count = 0;
            return;
        }

        Node<T> Evaluator = head.Next;
        head.SetNext(null);
        head = Evaluator;
        head.SetPrev(null); 
    }

    public void RemoveFrom(Node<T> node)
    {
        if (node == null) return;


        if (node.Prev != null) // Si el nodo a eliminar no es el primero, desconectamos el nodo anterior del nodo a eliminar
        {
            node.Prev.SetNext(null);
        }
        else
        {
            head = null;
        }

        tail = node.Prev;

        Node<T> current = node; // Empezamos a eliminar desde el nodo dado

        while (current != null)
        {
            Node<T> next = current.Next;

            current.SetPrev(null);
            current.SetNext(null);

            current = next;
        }

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
        if (pivot == null)    // Si no hay un nodo pivot, simplemente agregamos el nuevo nodo al final de la lista
        {
            Add(value);
            return;
        }

        if (pivot != tail)
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

    public void Remove(Node<T> node)
    {
        if (node == null) return;

        if (node.Prev != null)
            node.Prev.SetNext(node.Next);
        else
            head = node.Next;

        if (node.Next != null)
            node.Next.SetPrev(node.Prev);
        else
            tail = node.Prev;

        node.SetNext(null);
        node.SetPrev(null);

        ReCount();
    }

   


}