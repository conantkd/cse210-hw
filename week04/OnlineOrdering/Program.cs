using System;

class Program
{
    static void Main(string[] args)
    {
        Address colombiaAddress = new Address("Calle 10 #5-20", "Bogota", "Cundinamarca", "Colombia");
        Customer colombiaCustomer = new Customer("David Valdez", colombiaAddress);
        Order colombiaOrder = new Order(colombiaCustomer);
        colombiaOrder.AddProduct(new Product("Backpack", "B310", 28.00m, 1));
        colombiaOrder.AddProduct(new Product("Water Bottle", "W420", 12.00m, 2));
        colombiaOrder.AddProduct(new Product("Lunch Box", "L515", 9.50m, 1));

        Address floridaAddress = new Address("123 Centre Street", "Fernandina Beach", "Florida", "USA");
        Customer floridaCustomer = new Customer("Tatiana Vega", floridaAddress);
        Order floridaOrder = new Order(floridaCustomer);
        floridaOrder.AddProduct(new Product("Notebook", "N100", 3.00m, 5));
        floridaOrder.AddProduct(new Product("Pen", "P205", 1.50m, 4));

        DisplayOrder(colombiaOrder);
        DisplayOrder(floridaOrder);
    }

    private static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: {order.GetTotalCost():C}");
        Console.WriteLine();
    }
}