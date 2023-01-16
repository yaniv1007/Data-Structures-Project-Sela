using System;
using Models;
using Logic;

namespace UI
{
    public class Menu
    {
        Manager manager;

        public Menu()
        {
            Console.WriteLine("Welcome to shoe warhouse system\n");

            manager = new Manager();

            LoadData();
            Start();
        }

        private void Start()
        {
            bool b = false;

            Console.WriteLine("[1] Add new distribution point\n" +
                              "[2] Add stock\n" +
                              "[3] View all stock\n" +
                              "[4] View all distribution points\n" +
                              "[5] Place new order\n");

            while (!b)
            {
                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":     // Add new distribution point    finished

                        Console.Clear();
                        MenuAddDistributionPoint();

                        b = true;
                        break;

                    case "2":     // Add new / update stock

                        Console.Clear();
                        MenuAddStock();
                        b = true;
                        break;

                    case "3":     // View all stock

                        Console.Clear();
                        MenuViewAllStock();
                        b = true;
                        break;

                    case "4":     // View all distribution points

                        Console.Clear();
                        MenuViewDistributionPoints();
                        b = true;
                        break;

                    case "5":     // Place new order

                        Console.Clear();
                        MenuPurchaseNew();
                        b = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 5\n");
                        break;
                }
            }

            Start();
        }

        private void MenuAddDistributionPoint()
        {
            bool b = false;
            int zipCode = default;

            Console.Write("New distribution point name: ");
            string name = Console.ReadLine();

            while (!b)
            {
                Console.Write("New distribution point Zip Code (Numbers only): ");
                b = int.TryParse(Console.ReadLine(), out zipCode);
            }

            if (manager.LocationManager.AddNewDistributionPoint(name, zipCode))
            {
                Console.WriteLine($"\nDistribution point {name} added successfully");
            }
            else
            {
                Console.WriteLine($"\nDistribution point ''{name}'' already exists in the system");
            }

            Console.WriteLine("\nWould you like to add another Distribution point?");

            if (MenuYesOrNo())
            {
                Console.Clear();
                MenuAddDistributionPoint();
            }

            Console.Clear();
        }


        private void MenuAddStock()
        {
            bool b = false;

            while (!b)
            {
                Console.WriteLine("[1] Print all models\n" +
                                  "[2] Add model\n" +
                                  "[3] Add model and stock\n" +
                                  "[4] Go back to main menu\n");

                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":      // Print all models
                        Console.Clear();
                        Console.WriteLine(manager.ShoeManager.PrintAllModels());
                        break;

                    case "2":      // Add model

                        Console.Clear();
                        MenuAddModel();
                        b = true;
                        break;
                    case "3":     // Add model and stock

                        Console.Clear();
                        MenuAddModelAndStockNew();
                        b = true;
                        break;

                    case "4":     // Go back to main menu

                        b = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 4\n");
                        break;
                }
            }

            Start();
        }
        private void MenuAddModel()
        {
            Console.Write("Type brand's name: ");
            string brand = Console.ReadLine();

            Console.Write("Type model's name: ");
            string model = Console.ReadLine();

            manager.ShoeManager.AddStock(brand, model);

            Console.Clear();
        }
        private void MenuAddModelAndStockNew()
        {
            bool b = false;
            int size = default;
            int count = default;

            Console.Write("Type brand's name: ");
            string brand = Console.ReadLine();

            Console.Write("Type model's name: ");
            string model = Console.ReadLine();

            while (!b)
            {
                Console.Write("Type model's size (numbers only): ");
                b = int.TryParse(Console.ReadLine(), out size);
            }

            b = false;

            while (!b)
            {
                Console.Write("Type size count (numbers only): ");
                b = int.TryParse(Console.ReadLine(), out count);
            }

            manager.ShoeManager.AddStock(brand, model, size, count);
            Console.Clear();
        }

        private void MenuViewAllStock()
        {
            bool b = false;

            Console.WriteLine("[1] Print all models\n" +
                              "[2] Print all and sizes in stock\n" +
                              "[3] Print all models with last purchase dates\n" +
                              "[4] Go back to main menu\n");

            while (!b)
            {
                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":     // Print all models

                        Console.Clear();
                        Console.WriteLine(manager.ShoeManager.PrintAllModels());
                        b = true;
                        break;

                    case "2":     // Print all models and stock

                        Console.Clear();
                        Console.WriteLine(manager.ShoeManager.PrintAllModelsAndStock());
                        b = true;
                        break;

                    case "3":     // Print all models with last purchase dates

                        Console.Clear();
                        Console.WriteLine(manager.ShoeManager.PrintAllModelsWithDates());
                        b = true;
                        break;

                    case "4":     // Go back to main menu

                        Console.Clear();
                        b = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 4\n");
                        break;
                }
            }

            Start();
        }

        private void MenuViewDistributionPoints()
        {
            bool b = false;

            Console.WriteLine("[1] Print all distribution points\n" +
                              "[2] Print all distribution points by order of most used\n" +
                              "[3] Go back to main menu\n");

            while (!b)
            {
                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":

                        Console.Clear();
                        manager.LocationManager.PrintDistributionPoint();

                        MenuViewDistributionPoints();
                        break;

                    case "2":

                        Console.Clear();
                        Console.WriteLine(manager.LocationManager.PrintByTimeUsed());

                        MenuViewDistributionPoints();
                        break;

                    case "3":     // Go back to main menu

                        Console.Clear();
                        b = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 3\n");
                        break;
                }
            }

            Start();
        }

        private void MenuPurchaseNew()
        {
            bool b = false;

            while (!b)
            {
                Console.WriteLine("[1] Purchase by brand's name\n" +
                                  "[2] Purchase by brand's name and model's name\n" +
                                  "[3] Go back to main menu\n");


                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":

                        Console.Clear();
                        MenuPurchaseByBrand();
                        break;

                    case "2":

                        Console.Clear();
                        MenuPurchaseByBrandAndModel();
                        break;

                    case "3":

                        Console.Clear();
                        b = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 3\n");
                        break;
                }
            }

            Start();
        }
        private void MenuPurchaseByBrand()
        {
            Console.Write("Type brand's name: ");
            string brand = Console.ReadLine();

            if (!manager.ShoeManager.PrintBrandModels(brand, out string message))
            {
                Console.WriteLine(message + "\n");
            }
            else
            {
                Console.WriteLine("\n" + message);
                Console.WriteLine("Would you like to purchase one of this models?");
                if (MenuYesOrNo())
                {
                    PurchaseNew(brand);
                }
                else
                {
                    Console.Clear();
                }

            }
        }
        private void MenuPurchaseByBrandAndModel()
        {
            Console.Write("Type brand's name: ");
            string brand = Console.ReadLine();

            Console.Write("Type model's name: ");
            string model = Console.ReadLine();

            if (!manager.ShoeManager.PrintModelsStock(brand, model, out string message))
            {
                Console.WriteLine(message + "\n");
            }
            else
            {
                Console.WriteLine("\n" + message);
                Console.WriteLine("Would you like to purchase from one of this sizes in stock?");
                if (MenuYesOrNo())
                {
                    PurchaseNew(brand, model);
                }
                else
                {
                    Console.Clear();
                }
            }
        }


        private void PurchaseNew(string brand)
        {
            bool b = false;
            int size = default;
            int amount = default;


            //Checks if brand exist
            if (!manager.ShoeManager.IsBrandExistInSystem(brand))
            {
                Console.WriteLine($"Brand {brand} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            Console.Write("Type model's name: ");
            string model = Console.ReadLine();

            //Checks if model exist
            if (!manager.ShoeManager.IsModelExistInSystem(brand, model))
            {
                Console.WriteLine($"Model {model} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            while (!b)
            {
                Console.Write("Type model's size ");
                b = int.TryParse(Console.ReadLine(), out size);
            }

            //Checks if size exist
            if (!manager.ShoeManager.IsSizeExistInSystem(brand, model, size))
            {
                Console.WriteLine($"Size {size} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            b = false;

            while (!b)
            {
                Console.Write("Type amount to buy: ");
                b = int.TryParse(Console.ReadLine(), out amount);
            }

            //Checks if size exist
            if (!manager.ShoeManager.IsAmountlExistInSystem(brand, model, size, amount))
            {
                Console.WriteLine($"Amount typed is bigger than amount in stock \n");
                MenuPurchaseNew();
            }



            MenuChoosePoint(out DistributionPoint chosenDP);
            manager.Purchase(brand, model, size, amount);
            manager.LocationManager.UpdateTimeUsedPoint(chosenDP);

            Console.Clear();
            Console.WriteLine($"Purchase completed\nModel: {model}\nSize: {size}\nAmount: {amount}\n" +
                              $"Your order will arrive to {chosenDP} in 48 hours\n\n");

            Start();
        }
        private void PurchaseNew(string brand, string model)
        {
            bool b = false;
            int size = default;
            int amount = default;

            if (!manager.ShoeManager.IsBrandExistInSystem(brand))
            {
                Console.WriteLine($"Brand {brand} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            if (!manager.ShoeManager.IsModelExistInSystem(brand, model))
            {
                Console.WriteLine($"Model {model} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            while (!b)
            {
                Console.Write("Type model's size: ");
                b = int.TryParse(Console.ReadLine(), out size);
            }

            if (!manager.ShoeManager.IsSizeExistInSystem(brand, model, size))
            {
                Console.WriteLine($"Size {size} doesnt exist in stock\n");
                MenuPurchaseNew();
            }

            b = false;

            while (!b)
            {
                Console.Write("Type amount to buy: ");
                b = int.TryParse(Console.ReadLine(), out amount);
            }

            if (!manager.ShoeManager.IsAmountlExistInSystem(brand, model, size, amount))
            {
                Console.WriteLine($"Amount typed is bigger than amount in stock \n");
                MenuPurchaseNew();
            }



            MenuChoosePoint(out DistributionPoint chosenDP);

            manager.Purchase(brand, model, size, amount);

            manager.LocationManager.UpdateTimeUsedPoint(chosenDP);

            Console.Clear();
            Console.WriteLine($"Purchase completed\nModel: {model}\nSize: {size}\nAmount: {amount}\n" +
                              $"Your order will arrive to {chosenDP} in 48 hours\n\n");

            Start();
        }
        private bool MenuChoosePoint(out DistributionPoint chosenDP)
        {
            bool b = false;
            int zipCode = default;

            while (!b)
            {
                Console.Write("Type adress for delivary Zip Code (numbers only): ");
                b = int.TryParse(Console.ReadLine(), out zipCode);
            }

            manager.LocationManager.FindClosestDistributionPoints(zipCode, out chosenDP);
            return true;

        }

        public bool MenuYesOrNo()
        {
            bool yn = false;
            Console.WriteLine("[1] Yes\n[2] No\n");

            while (!yn)
            {
                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":     // Yes - extract to const 

                        return true;

                    case "2":     // No

                        return false;

                    default:
                        Console.WriteLine("Invalid input, type a number between 1 - 2");
                        break;
                }
            }

            return false;
        }


        private void LoadData()
        {
            LoadDistrubutionPoints();
            LoadStock();
            LoadPurchase();

        }
        private void LoadPurchase()
        {
            manager.Purchase("vans", "slip on", 45, 5);
            manager.Purchase("vans", "slip on", 45, 5);
            manager.Purchase("vans", "slip on", 45, 5);
            manager.Purchase("nike", "Air Jordan", 42, 1);
            manager.Purchase("nike", "Air Jordan", 43, 4);
            manager.Purchase("nike", "Air Jordan", 43, 4);
            manager.Purchase("nike", "Air Jordan", 43, 4);
            manager.Purchase("nike", "Air Jordan", 43, 4);
            manager.Purchase("nike", "Air Jordan", 42, 1);
            manager.Purchase("nike", "Air Jordan", 42, 1);
            manager.Purchase("adidas", "Stan smith", 42, 1);
            manager.Purchase("adidas", "Stan smith", 42, 1);
            manager.Purchase("adidas", "Stan smith", 43, 1);
            manager.Purchase("vans", "Old Skool w", 45, 2);
            manager.Purchase("vans", "Old Skool w", 45, 2);
            manager.Purchase("vans", "Old Skool w", 45, 2);
            manager.Purchase("vans", "Old Skool w", 45, 2);
            manager.Purchase("vans", "Old Skool w", 45, 2);
            manager.Purchase("vans", "Old Skool w", 45, 2);
        }
        private void LoadStock()
        {
            manager.ShoeManager.AddStock("nike", "Air force 1", 38, 56);
            manager.ShoeManager.AddStock("nike", "Air force 1", 39, 43);
            manager.ShoeManager.AddStock("nike", "Air force 1", 40, 100);
            manager.ShoeManager.AddStock("nike", "Air force 1", 41, 70);
            manager.ShoeManager.AddStock("nike", "Air force 1", 42, 60);
            manager.ShoeManager.AddStock("nike", "Air force 1", 43, 100);
            manager.ShoeManager.AddStock("nike", "Air force 1", 44, 98);
            manager.ShoeManager.AddStock("nike", "Air force 1", 45, 40);

            manager.ShoeManager.AddStock("nike", "Air Jordan", 40, 100);
            manager.ShoeManager.AddStock("nike", "Air Jordan", 41, 55);
            manager.ShoeManager.AddStock("nike", "Air Jordan", 42, 150);
            manager.ShoeManager.AddStock("nike", "Air Jordan", 43, 60);
            manager.ShoeManager.AddStock("nike", "Air Jordan", 44, 200);
            manager.ShoeManager.AddStock("nike", "Air Jordan", 45, 80);

            manager.ShoeManager.AddStock("nike", "Blazer", 38, 80);
            manager.ShoeManager.AddStock("nike", "Blazer", 39, 55);
            manager.ShoeManager.AddStock("nike", "Blazer", 40, 80);
            manager.ShoeManager.AddStock("nike", "Blazer", 41, 80);
            manager.ShoeManager.AddStock("nike", "Blazer", 42, 80);
            manager.ShoeManager.AddStock("nike", "Blazer", 45, 80);
            manager.ShoeManager.AddStock("nike", "Blazer", 46, 80);

            manager.ShoeManager.AddStock("nike", "Cortez", 38, 20);
            manager.ShoeManager.AddStock("nike", "Cortez", 39, 50);
            manager.ShoeManager.AddStock("nike", "Cortez", 40, 100);
            manager.ShoeManager.AddStock("nike", "Cortez", 41, 70);
            manager.ShoeManager.AddStock("nike", "Cortez", 42, 100);
            manager.ShoeManager.AddStock("nike", "Cortez", 45, 80);
            manager.ShoeManager.AddStock("nike", "Cortez", 46, 100);

            manager.ShoeManager.AddStock("adidas", "Stan smith", 42, 50);
            manager.ShoeManager.AddStock("adidas", "Stan smith", 43, 80);
            manager.ShoeManager.AddStock("adidas", "Stan smith", 44, 74);
            manager.ShoeManager.AddStock("adidas", "Stan smith", 45, 80);
            manager.ShoeManager.AddStock("adidas", "Stan smith", 46, 90);
            manager.ShoeManager.AddStock("adidas", "Stan smith", 47, 100);

            manager.ShoeManager.AddStock("adidas", "superstar", 42, 100);
            manager.ShoeManager.AddStock("adidas", "superstar", 43, 50);
            manager.ShoeManager.AddStock("adidas", "superstar", 44, 67);
            manager.ShoeManager.AddStock("adidas", "superstar", 45, 50);
            manager.ShoeManager.AddStock("adidas", "superstar", 46, 80);
            manager.ShoeManager.AddStock("adidas", "superstar", 47, 30);

            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 42, 100);
            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 43, 55);
            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 44, 150);
            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 45, 60);
            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 46, 200);
            manager.ShoeManager.AddStock("adidas", "Ultra Boost", 47, 80);

            manager.ShoeManager.AddStock("vans", "Old Skool w", 40, 100);
            manager.ShoeManager.AddStock("vans", "Old Skool w", 41, 100);
            manager.ShoeManager.AddStock("vans", "Old Skool w", 42, 100);
            manager.ShoeManager.AddStock("vans", "Old Skool w", 43, 100);
            manager.ShoeManager.AddStock("vans", "Old Skool w", 44, 100);
            manager.ShoeManager.AddStock("vans", "Old Skool w", 45, 100);

            manager.ShoeManager.AddStock("vans", "slip on", 40, 55);
            manager.ShoeManager.AddStock("vans", "slip on", 41, 80);
            manager.ShoeManager.AddStock("vans", "slip on", 42, 20);
            manager.ShoeManager.AddStock("vans", "slip on", 43, 6);
            manager.ShoeManager.AddStock("vans", "slip on", 44, 50);
            manager.ShoeManager.AddStock("vans", "slip on", 45, 50);
        }
        private void LoadDistrubutionPoints()
        {
            manager.LocationManager.AddNewDistributionPoint("Raanana", 500);
            manager.LocationManager.AddNewDistributionPoint("Metula", 999);
            manager.LocationManager.AddNewDistributionPoint("Haifa", 760);
            manager.LocationManager.AddNewDistributionPoint("Natanya", 680);
            manager.LocationManager.AddNewDistributionPoint("Herzliya", 470);
            manager.LocationManager.AddNewDistributionPoint("Ramat Gan", 450);
            manager.LocationManager.AddNewDistributionPoint("Eilat", 100);
            manager.LocationManager.AddNewDistributionPoint("Jerusalem", 300);
            manager.LocationManager.AddNewDistributionPoint("Beer Sheva", 250);
            manager.LocationManager.AddNewDistributionPoint("Kiryat Shmona", 950);
            manager.LocationManager.AddNewDistributionPoint("Dimona", 200);
            manager.LocationManager.AddNewDistributionPoint("Givatayim", 430);
            manager.LocationManager.AddNewDistributionPoint("Holon", 400);
            manager.LocationManager.AddNewDistributionPoint("Hod HaSharon", 490);
            manager.LocationManager.AddNewDistributionPoint("Ofakim", 270);
            manager.LocationManager.AddNewDistributionPoint("Tiberias", 800);
            manager.LocationManager.AddNewDistributionPoint("Acre", 780);
            manager.LocationManager.AddNewDistributionPoint("Yavne", 350);
            manager.LocationManager.AddNewDistributionPoint("Ariel", 440);
            manager.LocationManager.AddNewDistributionPoint("Beit Shemesh", 280);
            manager.LocationManager.AddNewDistributionPoint("Hadera", 720);

            manager.LocationManager.FindClosestDistributionPoints(123, out DistributionPoint closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);

            manager.LocationManager.FindClosestDistributionPoints(780, out closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);

            manager.LocationManager.FindClosestDistributionPoints(403, out closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);

            manager.LocationManager.FindClosestDistributionPoints(580, out closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);

            manager.LocationManager.FindClosestDistributionPoints(300, out closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
            manager.LocationManager.UpdateTimeUsedPoint(closestPoints);
        }
    }
}
