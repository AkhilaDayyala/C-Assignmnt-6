using System;
using System.Collections.Generic;
using System.Linq;

namespace project5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { PID = 1, Pname = "laptop", Pqty = 10, Amount = 50000 },
                new Product { PID = 2, Pname = "desktop", Pqty = 20, Amount = 60000 },
                new Product { PID = 3, Pname = "Iphone", Pqty = 20, Amount = 160000 }
            };

            Console.WriteLine("Enter who are you (admin/customer):");
            string name = Console.ReadLine();

            if (name.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter the product name:");
                string pname = Console.ReadLine();
                Console.WriteLine("Enter the product quantity:");
                int pqty = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the amount of the product:");
                double amount = double.Parse(Console.ReadLine());

                products.Add(new Product { PID = products.Count + 1, Pname = pname, Pqty = pqty, Amount = amount });

                Console.WriteLine("Product added successfully.");
            }
            else if (name.Equals("customer", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter the product name to search:");
                string pname = Console.ReadLine();

                var product = products.FirstOrDefault(p => p.Pname.Equals(pname, StringComparison.OrdinalIgnoreCase));

                if (product != null)
                {
                    double discountedAmount = product.Amount * 0.5;
                    Console.WriteLine($"Product: {product.Pname}, Quantity: {product.Pqty}, Original Amount: {product.Amount}, Discounted Amount: {discountedAmount}");
                }
                else
                {
                    Console.WriteLine("Product does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid user type.");
            }
        }

        class Product
        {
            public int PID { get; set; }
            public string Pname { get; set; }
            public int Pqty { get; set; }
            public double Amount { get; set; }
        }
    }
}
