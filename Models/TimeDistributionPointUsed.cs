namespace Models
{
    public class TimeDistributionPointUsed
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public int TimeUsed { get; set; }

        public TimeDistributionPointUsed(string name, int zipCode)
        {
            Name = name;
            ZipCode = zipCode;
            TimeUsed = 0;
        }


        public override string ToString()
        {
            return $"Time Used: {TimeUsed} | {Name} | Zip Code: {ZipCode}";
        }
    }
}
