using System;
using System.Collections.Generic;
using DataStructures;

namespace Models
{
    public class DistributionPoint : IComparer<DistributionPoint>, IComparable<DistributionPoint>
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public DoubleLinkedList<TimeDistributionPointUsed>.Node RefrenceToNodeDP { get; set; }


        public DistributionPoint(string name, int zipCode)
        {
            Name = name;
            ZipCode = zipCode;
        }


        public int CompareTo(DistributionPoint other)
        {
            // Checks who is bigger by comparing zip codes

            if (ZipCode > other.ZipCode)
                return 1;

            if (ZipCode < other.ZipCode)
                return -1;

            return 0;
        }

        public int Compare(DistributionPoint x, DistributionPoint y)
        {
            // Returns distance

            return Math.Abs(x.ZipCode - y.ZipCode);
        }

        public override string ToString()
        {
            return $"{Name} | Zip Code : {ZipCode}";
        }
    }
}
