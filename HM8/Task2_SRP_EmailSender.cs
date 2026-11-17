using System;

namespace Task2
{

    class Email
    {
        public String Theme { get; set; }
        public String From { get; set; }
        public String To { get; set; }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("[Консоль] " + message);
        }
    }

    class FileLogger : ILogger
    {
        private readonly string path;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public void Log(string message)
        {
            System.IO.File.AppendAllText(path, message + Environment.NewLine);
        }
    }

    class EmailSender
    {
        private readonly ILogger logger;

        public EmailSender(ILogger logger)
        {
            this.logger = logger;
        }

        public void Send(Email email)
        {
            logger.Log("Лист від '" + email.From + "' до '" + email.To +
                       "' (тема: " + email.Theme + ") відправлено");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Завдання 2: SRP + DIP (EmailSender) ===");
            Console.WriteLine();

            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
            Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
            Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
            Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
            Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

            Console.WriteLine("Логування в консоль:");
            EmailSender es = new EmailSender(new ConsoleLogger());
            es.Send(e1);
            es.Send(e2);
            es.Send(e3);
            es.Send(e4);
            es.Send(e5);
            es.Send(e6);

            Console.WriteLine();
            Console.WriteLine("Той самий EmailSender, але лог іде у файл log.txt:");
            EmailSender fileSender = new EmailSender(new FileLogger("log.txt"));
            fileSender.Send(e1);
            Console.WriteLine("Готово (клас EmailSender не змінювався).");

            Console.WriteLine();
            Console.WriteLine("Натисніть Enter, щоб закрити вікно...");
            Console.ReadLine();
        }
    }
}
