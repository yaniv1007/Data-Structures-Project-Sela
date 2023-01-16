using System;
using Models;
using System.Threading;

namespace Logic
{
    public class Manager
    {
        public ShoeManager ShoeManager { get; set; }
        public LocationManager LocationManager { get; set; }
        
        public Manager()
        {
            ShoeManager = new ShoeManager();
            LocationManager = new LocationManager();

            StartTimer();
        }

        private void StartTimer()
        {
            TimeSpan dueTime = new TimeSpan(0, 5, 0);
            TimeSpan period = new TimeSpan(0, 5, 0);
            Timer removeUnused = new Timer(RemoveUnpurchasedModels, null, dueTime, period);
        }

        public void Purchase(string brand, string model, int size, int amountToBuy)
        {
            Shoe shoe = ShoeManager.AllModels[brand.ToUpper()][model.ToUpper()];
            
            shoe.UpdateLatestPurchaseDate();                                                // Adding date to queue of dates and update node's date
            ShoeManager.ListOfLatestOrders.MoveToStartByNode(shoe.RefrenceToNodeTimeData);  // Moving node to start of the list
            shoe.Stock[size].Count -= amountToBuy;                                          // Updating amount in stock
            DeleteFromStockWhenZero(brand, model, size, shoe);                              // Deleting from system when size / model / brand is out of stock
        }

        public void RemoveUnpurchasedModels(object obj)
        {
            DateTime dt = DateTime.Now.AddMinutes(-4); // Sets time to delete from

            // Loop inside the list until date is newer than the one we set
            while (ShoeManager.ListOfLatestOrders.End != null &&
                ShoeManager.ListOfLatestOrders.End.Value.lastModelPurchase.CompareTo(dt) < 0)
            {
                if (ShoeManager.ListOfLatestOrders.RemoveLast(out var nodelToDelete))              // If removed successfuly 
                {
                    RemoveItemsThatWasntPurchesdByTime(nodelToDelete.Model, nodelToDelete.Brand);  // So removes from dictionary
                }
            }
        }
        private void RemoveItemsThatWasntPurchesdByTime(string model, string brand)
        {
            // Removes model from dictionary
            ShoeManager.AllModels[brand.ToUpper()].Remove(model.ToUpper());

            if (ShoeManager.AllModels[brand.ToUpper()].Count == 0)
            {
                // Removes brand if has 0 models
                ShoeManager.AllModels.Remove(brand.ToUpper());
            }
        }
        private void DeleteFromStockWhenZero(string brand, string model, int size, Shoe shoe)//
        {
            if (shoe.Stock[size].Count == 0)  // Removes Size
            {
                shoe.Stock.Remove(size);

                if (shoe.Stock.Count == 0)       // Removes Model
                {
                    ShoeManager.ListOfLatestOrders.RemoveByNode(ShoeManager.AllModels[brand.ToUpper()][model.ToUpper()].RefrenceToNodeTimeData); // Removes model's node
                    ShoeManager.AllModels[brand.ToUpper()].Remove(model.ToUpper());  // Removes model from dictionary

                    if (ShoeManager.AllModels[brand.ToUpper()].Count == 0) // Removes Brand
                        ShoeManager.AllModels.Remove(brand.ToUpper());
                }
            }
        }
    }
}
