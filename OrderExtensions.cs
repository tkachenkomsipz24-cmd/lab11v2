namespace Lab11v2;

public static class OrderExtensions
{
    public static decimal TotalOrderAmount(this IEnumerable<OrderDetail> details)
    {
        ArgumentNullException.ThrowIfNull(details);
        return details.Sum(d => d.Quantity * d.Product.Price);
    }
}
