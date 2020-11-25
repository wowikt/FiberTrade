using LinqExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            BankOperation[] operations = new[]
            {
                new BankOperation
                {
                    Amount = 100000,
                    Rest = 100000,
                    Date = new DateTime(2020, 11, 23),
                    Description = "Зарплата"
                },
                new BankOperation
                {
                    Amount = -5000,
                    Rest = 95000,
                    Date = new DateTime(2020, 11, 23),
                    Description = "Оплата коммунальных услуг"
                },
                new BankOperation
                {
                    Amount = -2000,
                    Rest = 93000,
                    Date = new DateTime(2020, 11, 23),
                    Description = "Покупка продуктов"
                },
                new BankOperation
                {
                    Amount = -3000,
                    Rest = 90000,
                    Date = new DateTime(2020, 11, 23),
                    Description = "Банковский перевод",
                    PersonCode = "ИИ"
                },
                new BankOperation
                {
                    Amount = -2000,
                    Rest = 88000,
                    Date = new DateTime(2020, 11, 23),
                    Description = "Банковский перевод",
                    PersonCode = "ТТ"
                },
            };

            Person[] persons = new[]
            {
                new Person
                {
                    PersonCode = "ИИ",
                    FirstName = "Иван",
                    LastName = "Иванов"
                },
                new Person
                {
                    PersonCode = "ПП",
                    FirstName = "Петр",
                    LastName = "Петров"
                },
            };

            Console.WriteLine($"Баланс операций = {operations.Sum(op => op.Amount)}");
            Console.WriteLine($"Сумма расходов = {-operations.Where(op => op.Amount < 0).Sum(op => op.Amount)}");
            var salary = operations.First(op => op.Description == "Зарплата");
            Console.WriteLine($"Зарплата = {salary.Amount}");

            var bankTransfers = from op in operations
                                join p in persons on op.PersonCode equals p.PersonCode into pers
                                from p in pers.DefaultIfEmpty()
                                where op.Description == "Банковский перевод"
                                select new { Amount = -op.Amount, p?.FirstName, p?.LastName };

            if (bankTransfers.Any())
            {
                Console.WriteLine("Банковские переводы:");
                foreach (var item in bankTransfers)
                {
                    Console.WriteLine($"{item.Amount} => {item.FirstName ?? "неизвестно"} {item.LastName}");
                }
            }

            Console.ReadLine();
        }
    }
}
