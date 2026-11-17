using System;

namespace Task3
{
    class BadRectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public int GetRectangleArea() { return Width * Height; }
    }

    class BadSquare : BadRectangle
    {
        public override int Width
        {
            get { return base.Width; }
            set { base.Height = value; base.Width = value; }
        }
        public override int Height
        {
            get { return base.Height; }
            set { base.Height = value; base.Width = value; }
        }
    }

    abstract class Shape
    {
        public abstract int GetArea();
    }

    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : Shape
    {
        public int Side { get; set; }

        public override int GetArea()
        {
            return Side * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Завдання 3: принцип заміщення Лісков (LSP) ===");
            Console.WriteLine();

            Console.WriteLine("ДО виправлення:");
            BadRectangle bad = new BadSquare();
            bad.Width = 5;
            bad.Height = 10;
            Console.WriteLine("Очікували 5 * 10 = 50, а отримали: " + bad.GetRectangleArea());
            Console.WriteLine("Причина: сетери BadSquare змінюють обидві сторони одразу.");
            Console.WriteLine();

            Console.WriteLine("ПІСЛЯ виправлення:");
            Rectangle rect = new Rectangle { Width = 5, Height = 10 };
            Square sq = new Square { Side = 5 };
            Console.WriteLine("Прямокутник 5 x 10: " + rect.GetArea());
            Console.WriteLine("Квадрат зі стороною 5: " + sq.GetArea());

            Console.WriteLine();
            Console.WriteLine("Обидві фігури можна використовувати як Shape:");
            Shape[] shapes = { rect, sq };
            foreach (Shape s in shapes)
                Console.WriteLine(" - " + s.GetType().Name + ": площа = " + s.GetArea());

            Console.WriteLine();
            Console.WriteLine("Натисніть Enter, щоб закрити вікно...");
            Console.ReadLine();
        }
    }
}
