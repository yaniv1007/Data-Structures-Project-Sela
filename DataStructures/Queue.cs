using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class QueueWithArray<T> : IEnumerable<T>
    {
        int firstInd;
        int lastInd;
        T[] queueArray;

        public QueueWithArray(int size = 30)
        {
            queueArray = new T[size];
            lastInd = firstInd = -1;
        }

        public virtual bool EnQueue(T item) //insert/push
        {
            if (IsFull()) return false;
            if (IsEmpty())
            {
                firstInd = lastInd = 0;
                queueArray[0] = item;
                return true;
            }
            lastInd = (lastInd + 1) % queueArray.Length;
            queueArray[lastInd] = item;
            return true;
        }
        public bool DeQueue(out T item)
        {
            item = default;
            if (IsEmpty()) return false;
            item = queueArray[firstInd];
            if (firstInd == lastInd)
            {
                firstInd = lastInd = -1;
                return true;
            }
            firstInd = (lastInd + 1) % queueArray.Length;
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (IsEmpty()) return "empty!!!";
            int firstIndexCopy = firstInd;
            while (firstIndexCopy != lastInd)
            {
                sb.Append(queueArray[firstIndexCopy]);
                firstIndexCopy = (firstIndexCopy + 1) % queueArray.Length;
            }
            sb.Append(queueArray[firstIndexCopy]);

            return sb.ToString();
        }
        internal virtual bool IsEmpty() => firstInd == -1;

        internal virtual bool IsFull()
        {
            return firstInd - lastInd == 1 || lastInd - firstInd == queueArray.Length - 1;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            int firstIndexCopy = firstInd;
            if (IsEmpty()) yield break;

            while (firstIndexCopy != lastInd)
            {
                yield return (queueArray[firstIndexCopy]);
                firstIndexCopy = (firstIndexCopy + 1) % queueArray.Length;
            }
            yield return (queueArray[firstIndexCopy]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

