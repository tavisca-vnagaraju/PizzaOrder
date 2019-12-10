using System;
using System.Collections.Generic;

namespace PizzaOrder
{
    public class Order
    {
        public List<Pizza> Items { get; private set; }
        public double TotalPrice { get; private set; }
        
        public void Place(Cart cart)
        {
            Items = cart.GetCartItems();
            TotalPrice = cart.GetCartPrice();
        }
        public void ViewOrderItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine();
                Console.WriteLine("Name : " + item.Name + "  " +item.Size);
                Console.WriteLine("Type : " + item.Type + " Toppings " + item.Toppings);
                Console.WriteLine("Price : " + item.Price);
            }
            Console.WriteLine("\nTotal Price is  " + this.TotalPrice);
        }
    }
}
