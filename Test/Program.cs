using System;
using System.Linq;
using Pras.Models;

namespace Pras.ConsoleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContextFactory().CreateDbContext(args);

            // Проверяем таблицу Bases
            Console.WriteLine("=== Bases ===");
            foreach (var b in context.Bases.ToList())
            {
                Console.WriteLine($"Id: {b.Id}, Email: {b.Email}, Status: {b.Status}");
            }

            // Проверяем таблицу Users
            Console.WriteLine("\n=== Users ===");
            foreach (var u in context.Users.ToList())
            {
                Console.WriteLine($"Id: {u.Id}, Email: {u.Email}, Admin: {u.IsAdmin}");
            }

            // Проверяем таблицу Products
            Console.WriteLine("\n=== Products ===");
            foreach (var p in context.Products.ToList())
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, BaseId: {p.BaseId}");
            }

            // Проверяем таблицу Checks
            Console.WriteLine("\n=== Checks ===");
            foreach (var c in context.Checks.ToList())
            {
                Console.WriteLine($"Id: {c.Id}, UserId: {c.UserId}, BaseId: {c.BaseId}");
            }

            // Проверяем таблицу Invoices
            Console.WriteLine("\n=== Invoices ===");
            foreach (var i in context.Invoices.ToList())
            {
                Console.WriteLine($"Id: {i.Id}, BaseId: {i.BaseId}");
            }

            // Проверяем таблицу CheckProducts
            Console.WriteLine("\n=== CheckProducts ===");
            foreach (var cp in context.CheckProducts.ToList())
            {
                Console.WriteLine($"Id: {cp.Id}, CheckId: {cp.CheckId}, ProductId: {cp.ProductId}");
            }
        }
    }
}
