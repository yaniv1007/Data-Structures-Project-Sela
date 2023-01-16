using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace Models
{
    public class Shoe
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Dictionary<int, CountAndSize> Stock { get; set; }
        public CyrcleTruncateQueue<DateTime> LastPurchaseDates { get; set; }
        public DoubleLinkedList<DateOfPurchaseForModel>.Node RefrenceToNodeTimeData { get; set; }


        public Shoe(string brand, string model, DoubleLinkedList<DateOfPurchaseForModel>.Node refrenceToNodeTmeData)
        {
            Brand = brand;
            Model = model;
            RefrenceToNodeTimeData = refrenceToNodeTmeData;

            Stock = new Dictionary<int, CountAndSize>();
            LastPurchaseDates = new CyrcleTruncateQueue<DateTime>();
            LastPurchaseDates.EnQueue(DateTime.Now);
        }


        public override string ToString()
        {
            return Model;
        }

        public string PrintStock() // Prints all model's stock
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Model);

            foreach(var size in Stock)
            {
                sb.AppendLine($"Size - {size.Value.Size} | Amount = {size.Value.Count}");
            }
            
            return sb.ToString();
        }

        public void UpdateLatestPurchaseDate()
        {
            // Updates queue and list of latest dates

            LastPurchaseDates.EnQueue(DateTime.Now);
            RefrenceToNodeTimeData.Value.lastModelPurchase = DateTime.Now;
        }
    }
}
