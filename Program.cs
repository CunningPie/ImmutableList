using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableList
{

    class Node<T>
    {
        public Node<T> Next;
        private readonly T Val;
        public T Value {get => Val; }
        public Node(T newVal)
        {
            Val = newVal;
        }
    }

    class ImmutableList<T>
    {
        Node<T> Head;

        public ImmutableList()
        {
        }

        public ImmutableList(T val)
        {
            Head = new Node<T>(val);
        }

        public T GetValue(int pos)
        {
            Node<T> t = Head;
            try
            {
                for (int i = 0; i < pos; i++)
                    t = t.Next;
                return t.Value;
            }
            catch
            {
            
            }

            return default(T);
        }

        public void AddValue(int pos, T val)
        {
            try
            {
                if (Head == null && pos != 0)
                    throw new Exception();
                else if (Head == null)
                    Head = new Node<T>(val);
                else
                {
                    Node<T> t = Head;

                    for (int i = 0; i < pos - 1; i++)
                        if (t.Next != null)
                            t = t.Next;

                    Node<T> newNode = new Node<T>(val);
                    if (pos == 0)
                    {
                        newNode.Next = t;
                        Head = newNode;
                    } 
                    else if(t != null)
                    {
                        newNode.Next = t.Next;
                        t.Next = newNode;
                    }
                }
            }
            catch
            { }
        }

        public T DeleteValue(int pos)
        {
            try
            {
                Node<T> t = Head;
                if (pos == 0)
                {
                    Head = t.Next;
                    return t.Value;
                }
                else
                {
                    while (t != null && pos - 1 != 0)
                    {
                        t = t.Next;
                        pos--;
                    }
                    Node<T> del = t.Next;
                    t.Next = del.Next;
                    return del.Value;
                }
            }
            catch
            {

            }
            return default(T);
        }

        public void DisplayList()
        {
            try
            {
                Node<T> t = Head;

                while (t != null)
                {
                    Console.Write(t.Value + " ");
                    t = t.Next;
                }
                Console.Write("\n");
            }
            catch
            {

            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ImmutableList<int> IL = new ImmutableList<int>();

            IL.AddValue(0, 2);
            IL.AddValue(1, 3);
            IL.AddValue(2, 5);
            IL.AddValue(3, 7);
            IL.AddValue(2, -3);
            IL.AddValue(0, 9);
            IL.AddValue(1, 12);

            IL.DeleteValue(0);
            IL.DeleteValue(3);
            IL.DeleteValue(-5);
            IL.DeleteValue(99);

            IL.DisplayList();

            Console.WriteLine("Value: " + IL.GetValue(2));
            Console.WriteLine("Value: " + IL.GetValue(4));
            Console.WriteLine("Value: " + IL.GetValue(-1));
            Console.WriteLine("Value: " + IL.GetValue(3));

            Console.ReadKey();
        }
    }
}
