using System;

namespace LinkedList
{
    public class DoubleLinkedList<T> where T : IComparable
    {
        public ListItem<T> Current { get; internal set; }
        public ListItem<T> Last { get; internal set; }
        public ListItem<T> First { get; internal set; }

        public static DoubleLinkedList<T> operator +(DoubleLinkedList<T> list, T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if(list.First == null)
            {
                list.First = new ListItem<T>(value);
                list.Current = list.First;
                list.Last = list.First;
            }
            else
            {
                list.Last.Append(new ListItem<T>(value));
                list.Last = list.Last.Last();
            }

            return list;
        }

        public static bool operator ==(DoubleLinkedList<T> ListA, DoubleLinkedList<T> ListB)
        {
            ListItem<T> a = ListA.First;
            ListItem<T> b = ListB.First;
            
            while (true)
            {                
                if(a == null || b == null)
                {
                    return a == null && b == null;
                }
                else if(!(a.Value.Equals(b.Value)))
                {
                    return false;
                }

                a = a.Successor;
                b = b.Successor;
            }
        }

        public static bool operator !=(DoubleLinkedList<T> ListA, DoubleLinkedList<T> ListB)
        {
            return !(ListA == ListB);
        }

        public ListItem<T> this[int key]
        {
            get
            {
                if(key < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                ListItem<T> cur = First;

                for(int i = 0; i < key; i++)
                {
                    if(cur.Successor != null)
                    {
                        cur = cur.Successor;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                return cur;
            }
        }
    }

    public class ListItem<T>
    {
        public ListItem<T> Predecessor { get; internal set; }
        public ListItem<T> Successor { get; internal set; }
        public T Value { get; internal set; }

        public ListItem(T value)
        {
            Value = value;
            Predecessor = null;
            Successor = null;
        }

        internal void Append(ListItem<T> listItem)
        {
            listItem.Predecessor = this;
            Successor = listItem;
        }

        internal ListItem<T> Last()
        {
            return Successor == null ? this : Successor.Last();
        }
    }
}