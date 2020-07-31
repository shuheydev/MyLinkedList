using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace MyLinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public MyLinkedListNode<T>? First => this._head.next == this._tail ? null : this._head.next;
        public MyLinkedListNode<T>? Last => this._tail.previous == this._head ? null : this._tail.previous;

        #region LinkedListの先頭と末尾のダミーノード
        //リスト本体の要素ではない.
        private MyLinkedListNode<T> _head { get; set; }
        private MyLinkedListNode<T> _tail { get; set; }
        #endregion

        public int Count { get; private set; }
        public MyLinkedList()
        {
            this._head = new MyLinkedListNode<T>();
            this._tail = new MyLinkedListNode<T>();

            Connect(this._head, this._tail);
        }

        public void AddLast(T value)
        {
            var node = new MyLinkedListNode<T>(value);
            Insert(this._tail.previous, this._tail, node);
            this.Count++;
        }

        public void AddFirst(T value)
        {
            var node = new MyLinkedListNode<T>(value);
            Insert(this._head, this._head.next, node);
            this.Count++;
        }

        public MyLinkedListNode<T> Find(T value)
        {
            for (var node = this._head.next; node != this._tail; node = node.next)
            {
                if (node.item.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        public void Remove(MyLinkedListNode<T> targetNode)
        {
            for (var node = this._head.next; node != this._tail; node = node.next)
            {
                if (node==targetNode)
                {
                    RemoveAt(node);
                    Count--;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var node = this._head.next; node != this._tail; node = node.next)
            {
                yield return node.item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private static void Connect(MyLinkedListNode<T> node1, MyLinkedListNode<T> node2)
        {
            node1.next = node2;
            node2.previous = node1;
        }

        private static void Insert(MyLinkedListNode<T> node1, MyLinkedListNode<T> node2, MyLinkedListNode<T> newNode)
        {
            Connect(node1, newNode);
            Connect(newNode, node2);
        }

        private static void RemoveAt(MyLinkedListNode<T> node)
        {
            Connect(node.previous, node.next);
        }
    }

    public class MyLinkedListNode<T>
    {
        internal T item;
        internal MyLinkedListNode<T>? next = null;
        internal MyLinkedListNode<T>? previous = null;

        public T Item => item;
        public MyLinkedListNode<T>? Next => next;
        public MyLinkedListNode<T>? Previous => previous;

        public MyLinkedListNode()
        {

        }
        public MyLinkedListNode(T item)
        {
            this.item = item;
        }
    }
}
