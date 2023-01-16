using DataStructures;
using Models;

namespace Logic
{
    public class LocationManager
    {
        public BST<DistributionPoint> DistributionPoints { get; set; }
        public DoubleLinkedList<TimeDistributionPointUsed> ListOfUsedDistributionPoint { get; set; }

        public LocationManager()
        {
            DistributionPoints = new BST<DistributionPoint>();
            ListOfUsedDistributionPoint = new DoubleLinkedList<TimeDistributionPointUsed>();
        }


        public bool FindClosestDistributionPoints(int zipCode, out DistributionPoint closestPoint)
        {
            DistributionPoint dpToFind = new DistributionPoint("a", zipCode);

            // Gets closest point
            if (DistributionPoints.FindClosest(dpToFind, out closestPoint))
            {
                return true;
            }
            // If tree is empty than false
            return false;
        }




        public bool AddNewDistributionPoint(string name, int zipCode)
        {
            var dp = new DistributionPoint(name, zipCode);

            if (!DistributionPoints.Search(dp)) // Checks if zip code exists in the system
            {
                ListOfUsedDistributionPoint.AddLast(new TimeDistributionPointUsed(name, zipCode)); // Add to list (for time used check)
                dp.RefrenceToNodeDP = ListOfUsedDistributionPoint.End;                             // Making refrence to the node
                DistributionPoints.Add(dp);                                                        // Adding to the tree

                return true;
            }

            // If distribution point alredy exist (by zip code)
            return false;
        }

        public string PrintByTimeUsed()
        {
            return ListOfUsedDistributionPoint.ToString();
        }

        public void PrintDistributionPoint()
        {
            DistributionPoints.PrintInOrder();
        }

        public bool UpdateTimeUsedPoint(DistributionPoint distributionPointToUpdate)
        {
            distributionPointToUpdate.RefrenceToNodeDP.Value.TimeUsed++;     // Update node's value

            var nodeOfDP = distributionPointToUpdate.RefrenceToNodeDP;
            var tmp1 = nodeOfDP;
            var tmp2 = nodeOfDP;

            if (ListOfUsedDistributionPoint.GetPrevtNode(nodeOfDP, out tmp1))
            {
                while (nodeOfDP.Value.TimeUsed > tmp1.Value.TimeUsed)
                {
                    tmp2 = tmp1;

                    if (!ListOfUsedDistributionPoint.GetPrevtNode(tmp2, out tmp1))
                    {
                        // prev node of node sent is null so the time our node used is the biggest - move to start
                        ListOfUsedDistributionPoint.MoveToStartByNode(nodeOfDP);
                        return true;
                    }
                    // value of tmp1 changed
                }

                // Move node to correct place
                ListOfUsedDistributionPoint.MoveToCorrectPosition(nodeOfDP, tmp1);
                return true;
            }

            // Else prev node of our node is null so node is already at the biggest place

            return false;
        }
    }
}
