using System;

namespace Task4
{

    interface IPriced
    {
        void SetPrice(double price);
    }

    interface IDiscountable
    {
        void ApplyDiscount(String discount);
        void ApplyPromocode(String promocode);
    }

    interface IColorable
    {
        void SetColor(byte color);
    }

    interface ISizable
    {
        void SetSize(byte size);
    }

    class Book : IPriced, IDiscountable
    {
        private double price;
        private string discount;
        private string promocode;

        public void SetPrice(double price)
        {
            this.price = price;
            Console.WriteLine("Книжка: ціна = " + price + " грн");
        }
        public void ApplyDiscount(String discount)
        {
            this.discount = discount;
            Console.WriteLine("Книжка: знижка = " + discount);
        }
        public void ApplyPromocode(String promocode)
        {
            this.promocode = promocode;
            Console.WriteLine("Книжка: промокод = " + promocode);
        }
    }

    class Outerwear : IPriced, IDiscountable, IColorable, ISizable
    {
        private double price;
        private byte color;
        private byte size;
        private string discount;
        private string promocode;

        public void SetPrice(double price)
        {
            this.price = price;
            Console.WriteLine("Куртка: ціна = " + price + " грн");
        }
        public void ApplyDiscount(String discount)
        {
            this.discount = discount;
            Console.WriteLine("Куртка: знижка = " + discount);
        }
        public void ApplyPromocode(String promocode)
        {
            this.promocode = promocode;
            Console.WriteLine("Куртка: промокод = " + promocode);
        }
        public void SetColor(byte color)
        {
            this.color = color;
            Console.WriteLine("Куртка: колір (код) = " + color);
        }
        public void SetSize(byte size)
        {
            this.size = size;
            Console.WriteLine("Куртка: розмір = " + size);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Завдання 4: принцип розділення інтерфейсу (ISP) ===");
            Console.WriteLine();

            Console.WriteLine("Книжка (лише ціна та знижки):");
            Book book = new Book();
            book.SetPrice(250.0);
            book.ApplyDiscount("10%");
            Console.WriteLine();

            Console.WriteLine("Верхній одяг (усі властивості):");
            Outerwear jacket = new Outerwear();
            jacket.SetPrice(2500.0);
            jacket.SetColor(3);
            jacket.SetSize(48);
            jacket.ApplyPromocode("WINTER2026");

            Console.WriteLine();
            Console.WriteLine("Зверніть увагу: у Book немає SetColor/SetSize - вони їй не потрібні.");

            Console.WriteLine();
            Console.WriteLine("Натисніть Enter, щоб закрити вікно...");
            Console.ReadLine();
        }
    }
}
