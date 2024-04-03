using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}

class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.GetTotalCost();
        }
        if (Customer.IsInUSA())
        {
            totalPrice += 5; // Shipping cost for USA
        }
        else
        {
            totalPrice += 35; // Shipping cost for non-USA
        }
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} ({product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{Customer.Name}\n";
        label += $"{Customer.Address.GetFullAddress()}\n";
        return label;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address
        {
            StreetAddress = "123 Main St",
            City = "New York",
            StateProvince = "NY",
            Country = "USA"
        };
        Customer customer1 = new Customer
        {
            Name = "Alice",
            Address = address1
        };

        Product product1 = new Product
        {
            Name = "Laptop",
            ProductId = "12345",
            Price = 999.99,
            Quantity = 1
        };
        Product product2 = new Product
        {
            Name = "Mouse",
            ProductId = "67890",
            Price = 19.99,
            Quantity = 2
        };

        Order order1 = new Order
        {
            Products = new List<Product> { product1, product2 },
            Customer = customer1
        };

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");
    }
}
