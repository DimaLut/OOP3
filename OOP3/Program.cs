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
                        BuyProduct( seller, purchaser);
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

        static private void BuyProduct( Seller seller, Purchaser purchaser)
        {
            seller.ShowProducts();

            int productNumber = Convert.ToInt32(Console.ReadLine());

            Product product = seller.Sell(productNumber);

            if (product != null)
            {
                purchaser.BuyProduct(product);
                Console.WriteLine("Покупка завершена успешно!");
            }

        }
    }

    class Purchaser: User
    {
        

        public Purchaser()
        {
            _products = new List<Product>();
        }

      

        public void BuyProduct(Product product)
        {
            _products.Add(product);
        }
    }

    class Seller: User
    {

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

        public Product Sell(int productNumber)
        {
            Product product = _products.FirstOrDefault(product => product.Number == productNumber);

            if (product == null)
            {
                Console.WriteLine("Товара с заданным номером нет в списке!");
            }

            _products.Remove(product);
            return product;
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

    class User
    {
        public List<Product> _products { get;  private protected set; }
        public void ShowProducts()
        {
            Console.WriteLine("Показать ссписок товаров");
            foreach (Product product in _products)
            {
                Console.WriteLine("{0} - {1} ", product.Number, product.Name);
            }
            Console.WriteLine();
        }
    }
}

