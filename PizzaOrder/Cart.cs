using System;
using System.Collections.Generic;

namespace PizzaOrder
{
    public class Cart
    {
        private List<Pizza> _items = new List<Pizza>();
        private double _total_price=0;
        private List<Pizza> _menuItems;

        public Cart(Menu menu)
        {
            this._menuItems = menu.GetPizzaMenu();
        }

        public void AddToCart(Pizza pizza)
        {
            if (this.IsPizzaInMenu(pizza))
            {
                _items.Add(pizza);
                _total_price += pizza.Price;
            }
        }
        public List<Pizza> GetCartItems()
        {
            return _items;
        }
        public double GetCartPrice()
        {
            return _total_price;
        }
        private bool IsPizzaInMenu(Pizza pizza)
        {
            if(_menuItems.Find(x => x.Name.Equals(pizza.Name)) != null)
            {
                return true;
            }
            return false;
        }
    }
}
