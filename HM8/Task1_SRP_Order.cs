using System;
using System.Collections.Generic;

namespace Task1
{

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Order
    {
        private List<Item> itemList = new List<Item>();

        public List<Item> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public double CalculateTotalSum()
        {
            double sum = 0;
            foreach (Item item in itemList) sum += item.Price;
            return sum;
        }

        public List<Item> GetItems() { return itemList; }
        public int GetItemCount() { return itemList.Count; }
        public void AddItem(Item item) { itemList.Add(item); }
        public void DeleteItem(Item item) { itemList.Remove(item); }
    }

    class OrderPrinter
    {
        public void PrintOrder(Order order)
        {
            Console.WriteLine("--- Замовлення ---");
            int i = 1;
            foreach (Item item in order.GetItems())
            {
                Console.WriteLine(i + ". " + item.Name + " - " + item.Price + " грн");
                i++;
            }
            Console.WriteLine("Разом: " + order.CalculateTotalSum() + " грн");
        }

        public void ShowOrder(Order order)
        {
            Console.WriteLine("Замовлення містить товарів: " + order.GetItemCount());
        }
    }

    class OrderRepository
    {
        public Order Load(int id)
        {
            Console.WriteLine("[Сховище] Замовлення №" + id + " завантажено");
            return new Order();
        }
        public void Save(Order order) { Console.WriteLine("[Сховище] Замовлення збережено"); }
        public void Update(Order order) { Console.WriteLine("[Сховище] Замовлення оновлено"); }
        public void Delete(Order order) { Console.WriteLine("[Сховище] Замовлення видалено"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Завдання 1: принцип єдиної відповідальності (SRP) ===");
            Console.WriteLine();

            Order order = new Order();
            order.AddItem(new Item { Name = "Книжка", Price = 250 });
            order.AddItem(new Item { Name = "Куртка", Price = 2500 });

            OrderPrinter printer = new OrderPrinter();
            printer.ShowOrder(order);
            printer.PrintOrder(order);
            Console.WriteLine();

            OrderRepository repo = new OrderRepository();
            repo.Save(order);
            repo.Update(order);
            repo.Delete(order);

            Console.WriteLine();
            Console.WriteLine("Натисніть Enter, щоб закрити вікно...");
            Console.ReadLine();
        }
    }
}
