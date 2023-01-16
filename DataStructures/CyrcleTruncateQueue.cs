using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    public class CyrcleTruncateQueue<T> : QueueWithArray<T>, IEnumerable<T>
    {
        int firstInd;
        int lastInd;
        T[] queueArr;

        public CyrcleTruncateQueue()
        {
            queueArr = new T[5];
            lastInd = firstInd = -1;
        }


        public override bool EnQueue(T item)
        {
            // If full than latest item index becomes new item that enqued
            if (IsFull()) firstInd = (firstInd + 1) % queueArr.Length;
            if (IsEmpty()) firstInd = 0;

            lastInd = (lastInd + 1) % queueArr.Length;
            queueArr[lastInd] = item;

            return true;
        }


        internal override bool IsEmpty() => firstInd == -1;
        internal override bool IsFull() => (lastInd + 1) % queueArr.Length == firstInd;


        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Never Purchased\n\n";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\n");

                int tmp = firstInd;

                while (tmp != lastInd)
                {
                    sb.Append(queueArr[tmp] + "\n");
                    tmp = (tmp + 1) % queueArr.Length;
                }

                if (!IsEmpty()) sb.Append(queueArr[tmp] + "\n\n");

                return sb.ToString();
            }
        }
        public string NewestItemToString()
        {
            // Showing only newest date

            if (IsEmpty())
            {
                return "Never Purchased";
            }
            else
            {
                return queueArr[firstInd].ToString();
            }
        }


        public override IEnumerator<T> GetEnumerator()
        {
            int tmp = firstInd;
            if (IsEmpty()) yield break;

            while (tmp != lastInd)
            {
                yield return queueArr[tmp];
                tmp = (tmp + 1) % queueArr.Length;
            }

            yield return queueArr[tmp];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
