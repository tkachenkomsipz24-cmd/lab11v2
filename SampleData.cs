namespace Lab11v2;

public static class SampleData
{
    public static List<Order> CreateOrders()
    {
        var laptop = new Product(1, "Ноутбук", 25000.00m);
        var phone = new Product(2, "Смартфон", 15000.00m);
        var headphones = new Product(3, "Навушники", 1800.50m);
        var keyboard = new Product(4, "Клавіатура", 1200.00m);
        var mouse = new Product(5, "Миша", 650.00m);
        var monitor = new Product(6, "Монітор", 7200.00m);
        var printer = new Product(7, "Принтер", 5400.00m);
        var webcam = new Product(8, "Веб-камера", 1100.00m);
        var flashDrive = new Product(9, "Флешка", 350.00m);
        var backpack = new Product(10, "Рюкзак", 1500.00m);
        _ = new Product(11, "Роутер", 1300.00m); // не замовлений жодного разу

        return new List<Order>
        {
            new Order(1, new DateTime(2026, 11, 1), new List<OrderDetail>
            {
                new OrderDetail(1, laptop, 1),
                new OrderDetail(2, mouse, 2),
                new OrderDetail(3, keyboard, 1)
            }),
            new Order(2, new DateTime(2026, 11, 3), new List<OrderDetail>
            {
                new OrderDetail(4, phone, 1),
                new OrderDetail(5, headphones, 2)
            }),
            new Order(3, new DateTime(2026, 11, 5), new List<OrderDetail>
            {
                new OrderDetail(6, monitor, 2),
                new OrderDetail(7, webcam, 1)
            }),
            new Order(4, new DateTime(2026, 11, 8), new List<OrderDetail>
            {
                new OrderDetail(8, flashDrive, 5),
                new OrderDetail(9, backpack, 1),
                new OrderDetail(10, mouse, 1)
            }),
            new Order(5, new DateTime(2026, 11, 10), new List<OrderDetail>
            {
                new OrderDetail(11, printer, 1),
                new OrderDetail(12, headphones, 1),
                new OrderDetail(13, laptop, 1)
            }),
            new Order(6, new DateTime(2026, 11, 12), new List<OrderDetail>
            {
                new OrderDetail(14, keyboard, 2),
                new OrderDetail(15, flashDrive, 3)
            }),
            new Order(7, new DateTime(2026, 11, 15), new List<OrderDetail>
            {
                new OrderDetail(16, phone, 2),
                new OrderDetail(17, monitor, 1),
                new OrderDetail(18, webcam, 2)
            })
        };
    }
}
