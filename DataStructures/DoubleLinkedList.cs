using System.Text;

namespace DataStructures
{
    public class DoubleLinkedList<T>
    {
        public Node Start { get; private set; }
        public Node End { get; internal set; }

        public void AddFirst(T val)
        {
            Node n = new Node(val);

            if (Start == null)
            {
                Start = n;
            }
            else
            {
                n.next = Start;
                n.next.prev = n;
                Start = n;
            }

            if (End == null) End = n;
        }
        public void AddLast(T val) 
        {
            if (Start == null)
            {
                AddFirst(val);
                return;
            }

            Node n = new Node(val);
            End.next = n;
            n.prev = End;
            End = End.next;
        }

        public bool RemoveFirst(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (Start == null) return false; // List is empty

            saveRemovedValue = Start.Value;
            Start = Start.next;
            if (Start == null) End = null; // List has only one value
            return true;
        }
        public bool RemoveLast(out T saveRemovedValue)
        {
            saveRemovedValue = default;
            if (Start == null) return false;

            saveRemovedValue = End.Value;

            End = End.prev;
            if (End == null)
            {
                Start = null;
                return true;
            }

            End.next = null;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = Start;

            while (tmp != null)
            {
                sb.Append(tmp.Value.ToString() + "\n");
                tmp = tmp.next;
            }

            return sb.ToString();
        }

        public void MoveToStartByNode(Node nodeToMove)
        {
            if (nodeToMove.next != null) 
            {
                if (nodeToMove.prev != null) // Node is in the middle of the list
                {
                    nodeToMove.next.prev = nodeToMove.prev;
                    nodeToMove.prev.next = nodeToMove.next;

                    nodeToMove.prev = null;
                    nodeToMove.next = Start;
                    Start.prev = nodeToMove;
                    Start = nodeToMove;
                }
            }
            else
            {
                if (nodeToMove.prev != null) // Node is last
                {
                    End = nodeToMove.prev;
                    End.next = null;
                    nodeToMove.prev = null;
                    nodeToMove.next = Start;
                    Start.prev = nodeToMove;
                    Start = nodeToMove;

                }

                // Else node is start and he doesnt get to this function
            }
        }
        public void MoveToCorrectPosition(Node nodeToMove, Node biggerNode)
        {
            if (nodeToMove.next == null)  // Node is last
            {
                nodeToMove.prev.next = null;
                End = nodeToMove.prev;
            }
            else                          // Node is in the middle
            {
                nodeToMove.prev.next = nodeToMove.next;
                nodeToMove.next.prev = nodeToMove.prev;
            }

            biggerNode.next.prev = nodeToMove;
            nodeToMove.next = biggerNode.next;
            biggerNode.next = nodeToMove;
            nodeToMove.prev = biggerNode;
        }
        public bool GetPrevtNode(Node nodeToGet, out Node tmp)
        {
            tmp = nodeToGet;
            if (nodeToGet.prev == null) return false;  // Start node

            tmp = nodeToGet.prev;
            return true;
        }
        public void RemoveByNode(Node nodeToRemove)
        {
            if(nodeToRemove.next == null)
            {
                if(nodeToRemove.prev == null)
                {
                    // node is only node in the list
                    Start = null;
                    End = null;
                }
                else
                {
                    // node is End node
                    End = nodeToRemove.prev;
                    nodeToRemove.prev.next = null;
                }
            }
            else
            {
                if(nodeToRemove.prev == null)
                {
                    // node is Start node
                    nodeToRemove.next.prev = null;
                    Start = nodeToRemove.next;
                }
                else
                {
                    nodeToRemove.next.prev = nodeToRemove.prev;
                    nodeToRemove.prev.next = nodeToRemove.next;
                }
            }
        }

        public class Node
        {
            public T Value { get; internal set; }
            internal Node next;
            internal Node prev;

            public Node(T value)
            {
                Value = value;
            }
        }
    }
}
