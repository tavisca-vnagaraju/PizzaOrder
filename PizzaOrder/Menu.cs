using System;
using System.Collections.Generic;

namespace PizzaOrder
{
    public class Menu
    {
        private List<Pizza> _pizzas = new List<Pizza>();

        public List<Pizza> GetPizzaMenu()
        {
            return _pizzas;
        }
        public void AddPizzaToMenu(Pizza pizza)
        {
            _pizzas.Add(pizza);
        }
        public Pizza GetPizza(string name)
        {
            return _pizzas.Find(x => x.Name.Equals(name));
        }
        public void ShowPizzaMenu()
        {
            foreach (var item in _pizzas)
            {
                Console.WriteLine();
                Console.WriteLine( "Name : " + item.Name);
                Console.WriteLine("Category : " + item.Category);
                Console.WriteLine("Price : " + item.Price);
                Console.WriteLine("Size :" + item.Size);
            }
        }
        
    }
}
