using System;

class Program
{
    static void Main(string[] args)
    {
        Address a1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer c1 = new Customer("Jane Smith", a1);
        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Notebook", "N100", 3.00, 5));
        o1.AddProduct(new Product("Pen Set", "P200", 8.50, 2));

        Address a2 = new Address("45 Maple Ave", "Toronto", "ON", "Canada");
        Customer c2 = new Customer("Liam Chen", a2);
        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Backpack", "B300", 40.00, 1));
        o2.AddProduct(new Product("Water Bottle", "W400", 12.25, 2));
        o2.AddProduct(new Product("Sticker Pack", "S500", 2.00, 4));

        foreach (Order o in new List<Order> { o1, o2 })
        {
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine($"Total: ${o.GetTotalCost():F2}\n");
        }
    }
}