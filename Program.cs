using System.Globalization;
using System.Text;

namespace Lab11v2;

public static class Program
{
    private const int PageSize = 2;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Order> orders = SampleData.CreateOrders();

        Console.WriteLine("=== Замовлення та деталі замовлень (Варіант 2) ===");
        Console.WriteLine($"Усього замовлень: {orders.Count}");
        Console.WriteLine();

        DemoSelectMany(orders);
        Console.WriteLine();
        DemoPagination(orders);
        Console.WriteLine();
        DemoExtension(orders);
    }

    private static void DemoSelectMany(List<Order> orders)
    {
        Console.WriteLine("--- 1. SelectMany: усі замовлені продукти (без дублікатів) ---");

        var nested = orders.Select(o => o.Details);
        var flat = orders.SelectMany(o => o.Details);
        Console.WriteLine($"Select повертає колекцій: {nested.Count()} (вкладені списки)");
        Console.WriteLine($"SelectMany повертає елементів: {flat.Count()} (один плоский список)");

        var products = flat.Select(d => d.Product).Distinct().ToList();
        Console.WriteLine($"Унікальних замовлених продуктів: {products.Count}");

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {products[i].Name} ({Money(products[i].Price)})");
        }
    }

    private static void DemoPagination(List<Order> orders)
    {
        Console.WriteLine($"--- 2. Пагінація: по {PageSize} замовлення на сторінку ---");

        int totalPages = (int)Math.Ceiling(orders.Count / (double)PageSize);

        for (int page = 1; page <= totalPages; page++)
        {
            Console.WriteLine($"Сторінка {page} з {totalPages}:");

            foreach (var order in GetPage(orders, page, PageSize))
            {
                Console.WriteLine($"  Замовлення #{order.Id} від {order.OrderDate:yyyy-MM-dd}, позицій: {order.Details.Count}");
            }
        }
    }

    private static void DemoExtension(List<Order> orders)
    {
        Console.WriteLine("--- 3. Custom Extension: TotalOrderAmount() ---");

        foreach (var order in orders)
        {
            Console.WriteLine($"Замовлення #{order.Id}: {Money(order.Details.TotalOrderAmount())}");
        }

        decimal grandTotal = orders.SelectMany(o => o.Details).TotalOrderAmount();
        Console.WriteLine($"Загальна сума всіх замовлень: {Money(grandTotal)}");
    }

    private static IEnumerable<T> GetPage<T>(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

    private static string Money(decimal value)
    {
        return value.ToString("F2", CultureInfo.InvariantCulture);
    }
}
