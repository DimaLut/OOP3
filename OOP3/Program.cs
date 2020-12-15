using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;


namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Purchaser purchaser = new Purchaser();

            int action = 0;

            while (action != 4)
            {
                switch (action)
                {
                    case 1:
                        seller.ShowProducts();
                        break;
                    case 2:
                        BuyProduct(ref seller, ref purchaser);
                        break;
                    case 3:
                        purchaser.ShowProducts();
                        break;
                    case 4:

                        break;
                }

                Console.Write("Введите номер действия, которое хотите совершить: \n" +
                              "1) Вывести весь товар у продавца \n" +
                              "2) Купить товар \n" +
                              "3) Вывести товар у покупателя \n" +
                              "4) Выход\n");

                action = Convert.ToInt32(Console.ReadLine());
            }


            seller.ShowProducts();
            purchaser.ShowProducts();
        }

        static private void BuyProduct(ref Seller seller, ref Purchaser purchaser)
        {
            seller.ShowProducts();

            int productNumber = Convert.ToInt32(Console.ReadLine());

            seller.Sell(productNumber, ref purchaser);
        }
    }

    class Purchaser
    {
        public List<Product> Products { get; set; }

        public Purchaser()
        {
            Products = new List<Product>();
        }

        public void ShowProducts()
        {
            Console.WriteLine("Список товаров покупателя!");
            foreach (Product product in Products)
            {
                Console.WriteLine("{0}", product.Name);
            }
            Console.WriteLine();
        }
    }

    class Seller
    {
        private List<Product> _products;

        public Seller()
        {
            _products = new List<Product>
            {
                new Product(1, "iPhone 12 mini"),
                new Product(2, "iPhone 12"),
                new Product(3, "iPhone 12 MAX"),
                new Product(4, "iPhone 12 Pro MAX")
            };
        }

        public void Sell(int productNumber, ref Purchaser purchaser)
        {
            Product product = _products.FirstOrDefault(product => product.Number == productNumber);

            if (product == null)
            {
                Console.WriteLine("Товара с заданным номером нет в списке!");
                return;
            }

            purchaser.Products.Add(product);
            _products.Remove(product);
            Console.WriteLine("Продажа товаров прошла успешно!");
        }

        public void ShowProducts()
        {
            Console.WriteLine("Список товаров продавца!\n" +
                              "Какой телефон вы хотите купить?\n");
            foreach (Product product in _products)
            {
                Console.WriteLine("{0} - {1} ", product.Number, product.Name);
            }
            Console.WriteLine();
        }
    }

    class Product
    {
        public int Number { get; }
        public string Name { get; }

        public Product(int number, string name)
        {
            Number = number;
            Name = name;
        }

    }
}

