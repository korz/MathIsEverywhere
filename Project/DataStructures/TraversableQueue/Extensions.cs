using System.Collections.Generic;
using System.Linq;

namespace DataStructures.TraversableQueue
{
    public static class Extensions
    {
        public static LinkedList<T> ToLinkedList<T>(this Queue<T> queue)
        {
            return new LinkedList<T>(queue);
        }

        public static LinkedListNode<T> CutFirstNode<T>(this LinkedList<T> linkedList)
        {
            if (linkedList.Count == 0) return null;

            var node = linkedList.First;

            linkedList.RemoveFirst();

            return node;
        }

        public static IList<T> ToList<T>(this TraversableQueue<T> queue)
        {
            return queue.ToArray().ToList();
        }

        public static IEnumerable<T> Traverse<T>(this TraversableQueue<T> queue)
        {
            var current = queue.PeekNode();

            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }

            yield return current.Value;
        }   
    }
}
