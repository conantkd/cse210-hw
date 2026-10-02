using System.Collections.Generic;
using System.Linq;

public class Order
{
    private readonly List<Product> _products;
    private Customer _customer;

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        return _products.Sum(product => product.GetTotalCost()) + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(product => $"{product.Name} (ID: {product.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address}";
    }
}