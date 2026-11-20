namespace Lab11v2;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

public class OrderDetail
{
    public int Id { get; }
    public int ProductId { get; }
    public int Quantity { get; }
    public Product Product { get; }

    public OrderDetail(int id, Product product, int quantity)
    {
        Id = id;
        Product = product;
        ProductId = product.Id;
        Quantity = quantity;
    }
}

public class Order
{
    public int Id { get; }
    public DateTime OrderDate { get; }
    public List<OrderDetail> Details { get; }

    public Order(int id, DateTime orderDate, List<OrderDetail> details)
    {
        Id = id;
        OrderDate = orderDate;
        Details = details;
    }
}
