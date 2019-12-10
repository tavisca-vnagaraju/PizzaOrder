using PizzaOrder;
using System;
using Xunit;

namespace PizzaOrderFixature
{
    public class PizzaOrderFixature
    {
        [Fact]
        public void Check_For_PizzaSize_Default_Size()
        {
            Pizza pizza = new Pizza("Cheese Pizza", Category.Veg,400);
            Assert.Equal("Regular", pizza.Size.ToString());
        }
        [Fact]
        public void Check_For_PizzaType_Default_Type()
        {
            Pizza pizza = new Pizza("Cheese Pizza", Category.Veg,400);
            Assert.Equal("Italian", pizza.Type.ToString());
        }
        [Fact]
        public void Check_For_Pizza_Name()
        {
            Pizza pizza = new Pizza("Cheese Pizza", Category.Veg,400);
            Assert.Equal("Cheese Pizza", pizza.Name);
        }
        [Fact]
        public void Check_For_Pizza_Category()
        {
            Pizza pizza = new Pizza("Cheese Pizza", Category.Veg,400);
            Assert.Equal("Veg", pizza.Category.ToString());
        }
        [Fact]
        public void Check_For_Menu_Null_Pizza()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 200);
            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 200);
            Menu menu = new Menu();
            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);
            Assert.Null(menu.GetPizza("Mayo Pizza"));
        }
        [Fact]
        public void Check_For_Menu()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 200);
            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 200);
            ButterPizza.SetSize(PizzaSize.Large);
            ButterPizza.SetType(PizzaTypes.Butter);
            Menu menu = new Menu();
            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);
            Assert.Equal(CheesePizza, menu.GetPizza("Cheese Pizza"));
        }
        [Fact]
        public void Check_For_Cart_Items()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 10);

            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 20);
            ButterPizza.SetType(PizzaTypes.Butter); // price adds by 20

            Pizza MayoPizza = new Pizza("Mayo Pizza", Category.Veg, 30);
            MayoPizza.SetToppings(PizzaToppings.Mayo); // price adds by 10

            Menu menu = new Menu();
            
            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);
            menu.AddPizzaToMenu(MayoPizza);

            Cart cart = new Cart(menu);
            cart.AddToCart(CheesePizza);
            cart.AddToCart(ButterPizza);

            Assert.Equal(CheesePizza.Name, cart.GetCartItems()[0].Name);
        }
        [Fact]
        public void Check_For_Cart_Items_Total_Price()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 10);

            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 20);
            ButterPizza.SetType(PizzaTypes.Butter); // price adds by 20

            Pizza MayoPizza = new Pizza("Mayo Pizza", Category.Veg, 30);
            MayoPizza.SetToppings(PizzaToppings.Mayo); // price adds by 10

            Menu menu = new Menu();

            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);
            menu.AddPizzaToMenu(MayoPizza);

            Cart cart = new Cart(menu);
            cart.AddToCart(CheesePizza);
            cart.AddToCart(ButterPizza);

            Assert.Equal(50, cart.GetCartPrice());
        }
        [Fact]
        public void Check_Non_Menu_Item_should_Not_Get_Added_To_Cart()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 10);

            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 20);
            ButterPizza.SetType(PizzaTypes.Butter); // price adds by 20

            Pizza MayoPizza = new Pizza("Mayo Pizza", Category.Veg, 30);
            MayoPizza.SetToppings(PizzaToppings.Mayo); // price adds by 10

            Menu menu = new Menu();

            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);

            Cart cart = new Cart(menu);
            cart.AddToCart(CheesePizza);
            cart.AddToCart(MayoPizza);

            Assert.Equal(10, cart.GetCartPrice());
        }
        [Fact]
        public void Check_For_Order()
        {
            Pizza CheesePizza = new Pizza("Cheese Pizza", Category.Veg, 10);

            Pizza ButterPizza = new Pizza("Butter Pizza", Category.Veg, 20);
            ButterPizza.SetType(PizzaTypes.Butter); // price adds by 20

            Pizza MayoPizza = new Pizza("Mayo Pizza", Category.Veg, 30);
            MayoPizza.SetToppings(PizzaToppings.Mayo); // price adds by 10

            Menu menu = new Menu();

            menu.AddPizzaToMenu(CheesePizza);
            menu.AddPizzaToMenu(ButterPizza);
            menu.AddPizzaToMenu(MayoPizza);

            Cart cart = new Cart(menu);
            cart.AddToCart(CheesePizza);
            cart.AddToCart(ButterPizza);
            cart.AddToCart(MayoPizza);

            Order order = new Order();
            order.Place(cart);

            Assert.Equal(90, order.TotalPrice);
        }
    }
}