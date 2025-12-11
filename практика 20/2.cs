using System;
using System.Collections.Generic;

namespace задание2
{
    public class ProductOutOfStockException : Exception
    {
        public string ProductName { get; }
        public int StockLeft { get; }

        public ProductOutOfStockException(string productName, int stockLeft)
            : base($"Товар \"{productName}\" закончился! Осталось: {stockLeft}")
        {
            ProductName = productName;
            StockLeft = stockLeft;
        }
    }
    public class OnlineShop
    {
        private Dictionary<string, int> _inventory;

        public OnlineShop()
        {
            _inventory = new Dictionary<string, int>();
        }
        public void AddProduct(string productName, int quantity)
        {
            if (_inventory.ContainsKey(productName))
                _inventory[productName] += quantity;
            else
                _inventory[productName] = quantity;
        }
        public void Buy(string product, int quantity)
        {
            if (_inventory.ContainsKey(product))
            {
                int stock = _inventory[product];
                Console.WriteLine($"Покупаем {product} => {quantity} шт.");

                if (quantity > stock)
                {
                    throw new ProductOutOfStockException(product, stock);
                }
                _inventory[product] -= quantity;
                Console.WriteLine($"Куплено: {quantity} шт. Остаток: {_inventory[product]}");
            }
            else
            {
                Console.WriteLine($"Товар \"{product}\" не найден в магазине.");
            }
        }
        public int GetStock(string product)
        {
            return _inventory.ContainsKey(product) ? _inventory[product] : 0;
        }
    }
    class Program
    {
        static void Main()
        {
            var shop = new OnlineShop();
            shop.AddProduct("iPhone", 2);
            shop.AddProduct("Samsung Galaxy", 5);
            try
            {
                Console.WriteLine("Покупка iPhone:");
                shop.Buy("iPhone", 1);
                shop.Buy("iPhone", 2);
            }
            catch (ProductOutOfStockException ex)
            {
                Console.WriteLine($"Ошибка: Товар \"{ex.ProductName}\" закончился! Осталось: {ex.StockLeft}");
            }
            try
            {
                Console.WriteLine("Покупка iPhone:");
                shop.Buy("iPhone", 1);
            }
            catch (ProductOutOfStockException ex)
            {
                Console.WriteLine($"Ошибка: Товар \"{ex.ProductName}\" закончился! Осталось: {ex.StockLeft}");
            }
        }
    }
}