using System;

namespace Models
{
    public class DateOfPurchaseForModel
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime lastModelPurchase { get; set; }

        public DateOfPurchaseForModel(string brand, string model, DateTime date)
        {
            Model = model.ToUpper();
            Brand = brand.ToUpper();
            lastModelPurchase = date;
        }
    }
}
