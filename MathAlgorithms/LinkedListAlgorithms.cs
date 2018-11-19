using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithms
{
    /// <summary>
    /// Implements IClonable for Deep Copying
    /// Deep Copy: value types are copied and it uses Clone() method to create a true copy of object References by creating instances on the memory heap for cloned instances.
    /// Shallow Copy: value types are copied but Reference Types are shared
    /// </summary>
    public class LinkedListNode : ICloneable
    {
        public int _Value;
        public LinkedListNode _NextNode;

        public LinkedListNode(int value)
        {
            _Value = value;
            _NextNode = null;
        }

        /// <summary>
        /// Implemented for Deep-Copying by creating a new instance of the Node on the Heap
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var newCopy = new LinkedListNode(_Value);
            newCopy._NextNode = new LinkedListNode(_NextNode._Value);
            return newCopy;
        }
    }

    public class LinkedList
    {
        private LinkedListNode _Head;
        public int Count { get; private set; }

        public LinkedList(LinkedListNode head)
        {
            _Head = head ?? throw new ArgumentNullException(nameof(head), $"cannot have null value for ${nameof(head)}");
            Count = 1;
        }

        public void Append(int value)
        {
            if (_Head._NextNode == null)
                _Head._NextNode = new LinkedListNode(value);
            else
            {
                var node = _Head;
                while (node != null)
                {
                    node = node._NextNode;
                    if (node._NextNode == null) {
                        node._NextNode = new LinkedListNode(value);
                        break;
                    }
                }
            }
            Count = Count + 1;
        }

        public void Display()
        {
            if (_Head._NextNode == null)
                Console.WriteLine(_Head._Value);
            else
            {
                var node = _Head;
                while (node != null) {
                    Console.WriteLine(node._Value);
                    node = node._NextNode;
                }
            }
        }

        public void Remove()
        {
            LinkedListNode prev = _Head;
            if (Count == 1)
                return;
            else
            {
                var node = _Head;
                while (node != null)
                {
                    prev = node;
                    node = node._NextNode; 
                    if (node._NextNode == null) {
                        prev._NextNode = null;
                        break;
                    }
                }
            }

            Count = Count - 1;
        }
    }

    public class LinkedListAlgorithms
    {
        private LinkedListAlgorithms() { }
        private static readonly LinkedListAlgorithms _Instance = new LinkedListAlgorithms();
        public static LinkedListAlgorithms Instance => _Instance;
    }
}
