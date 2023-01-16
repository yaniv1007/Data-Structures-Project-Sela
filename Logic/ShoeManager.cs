using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using Models;

namespace Logic
{
    public class ShoeManager
    {
        public Dictionary<string, Dictionary<string, Shoe>> AllModels { get; set; }
        public DoubleLinkedList<DateOfPurchaseForModel> ListOfLatestOrders { get; set; }


        public ShoeManager()
        {
            AllModels = new Dictionary<string, Dictionary<string, Shoe>>();
            ListOfLatestOrders = new DoubleLinkedList<DateOfPurchaseForModel>();
        }


        public void AddStock(string brand, string model)
        {
            // Adding new model with zero stock
            AddStock(brand, model, 0, 0);
        }
        public void AddStock(string brand, string model, int size, int count)
        {
            if (!AllModels.ContainsKey(brand.ToUpper())) // If model's brand doenst exist - new brand added
            {
                var d1 = new Dictionary<string, Shoe>();
                AllModels.Add(brand.ToUpper(), d1);
            }

            if (!AllModels[brand.ToUpper()].ContainsKey(model.ToUpper())) // If model doenst exist - new model added
            {
                // Adding new model to newest place in the purchase date list and makes reference for the node
                ListOfLatestOrders.AddFirst(new DateOfPurchaseForModel(brand, model, DateTime.Now));
                Shoe newShoe = new Shoe(brand, model, ListOfLatestOrders.Start);

                // Adding new model to the dictionary
                AllModels[brand.ToUpper()].Add(model.ToUpper(), newShoe);
            }

            if (!AllModels[brand.ToUpper()][model.ToUpper()].Stock.ContainsKey(size)) // If size doesnt exist in the model - new size added
            {
                CountAndSize stockToAdd = new CountAndSize { Size = size, Count = count };
                AllModels[brand.ToUpper()][model.ToUpper()].Stock.Add(size, stockToAdd);
            }
            else // adding count to existing size's count
            {
                AllModels[brand.ToUpper()][model.ToUpper()].Stock[size].Count += count;
            }
        }

        public string PrintAllModels() // Print all models
        {
            bool b;
            StringBuilder sb = new StringBuilder();

            foreach (var brand in AllModels)
            {
                b = false;
                string brandString = brand.Key.ToString();

                sb.Append("\n" + FixBrandPrint(brandString) + "\n");

                foreach (var shoe in AllModels[brandString])
                {
                    sb.Append(shoe.Value.Model + "\n");
                    b = true;
                }
                if (!b) sb.Append("Doesnt have models\n");
            }

            return sb.ToString();
        }
        public string PrintAllModelsWithDates() // Print all models with last dates purchased
        {
            bool b;
            StringBuilder sb = new StringBuilder();

            foreach (var brand in AllModels)
            {
                b = false;
                string brandString = brand.Key.ToString();

                sb.Append(FixBrandPrint(brandString) + "\n");

                foreach (var shoe in AllModels[brandString])
                {
                    sb.Append(shoe.Value.Model);
                    sb.Append(shoe.Value.LastPurchaseDates);
                    b = true;
                }

                if (!b) sb.Append("Doesnt have models\n");
            }

            return sb.ToString();
        }
        public string PrintAllModelsAndStock() // Print all models and their stock
        {
            bool b;
            StringBuilder sb = new StringBuilder();

            foreach (var brand in AllModels)
            {
                b = false;
                string brandString = brand.Key.ToString();

                sb.Append("\n" + FixBrandPrint(brandString) + "\n");

                foreach (var shoe in AllModels[brandString])
                {
                    sb.Append(shoe.Value.PrintStock() + "\n");
                    b = true;
                }
                if (!b) sb.Append("Doesnt have models\n");
            }

            return sb.ToString();
        }

        public bool PrintBrandModels(string brand, out string message) // Print all models of one brand
        {
            if (!IsBrandExistInSystem(brand))
            {
                message = $"Brand {brand} doesn't exist in the system";
                return false;
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var shoe in AllModels[brand.ToUpper()])
                {
                    sb.AppendLine(shoe.Value.PrintStock());
                }

                message =  sb.ToString();
                return true;
            }
        }
        public bool PrintModelsStock(string brand, string model, out string message) // Print all stock of one model
        {
            if (!IsBrandExistInSystem(brand))
            {
                message = $"Brand {brand} doesn't exist in the system";
                return false;
            }
            else
            {
                if (!IsModelExistInSystem(brand, model))
                {
                    message = $"Model {model} doesn't exist in the system";
                    return false;

                }
                else
                {
                    message = AllModels[brand.ToUpper()][model.ToUpper()].PrintStock();
                    return true;
                }
            }
        }

        public bool IsBrandExistInSystem(string brand) => AllModels.ContainsKey(brand.ToUpper());
        public bool IsModelExistInSystem(string brand, string model) => AllModels[brand.ToUpper()].ContainsKey(model.ToUpper());
        public bool IsSizeExistInSystem(string brand, string model, int size) => AllModels[brand.ToUpper()][model.ToUpper()].Stock.ContainsKey(size);
        public bool IsAmountlExistInSystem(string brand, string model, int size, int amountToBuy)
        {
            if (AllModels[brand.ToUpper()][model.ToUpper()].Stock[size].Count >= amountToBuy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string FixBrandPrint(string s)
        {
            // Fix brand's print (Capital letter in the beginning)
            StringBuilder a = new StringBuilder();
            a.Append(s[0].ToString());

            for (int i = 1; i < s.Length; i++)
            {
                string c = s[i].ToString();
                a.Append(c.ToLower());
            }

            return a.ToString();
        }
    }
}
