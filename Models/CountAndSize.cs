namespace Models
{
    public class CountAndSize
    {
        public int Size { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"Size: {Size}\nCount: {Count}";
        }
    }
}
