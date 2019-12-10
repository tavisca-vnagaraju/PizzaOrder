namespace PizzaOrder
{
    public class Pizza
    {
        public string Name { get; }
        public double Price { get; private set; }
        public Category Category { get; }
        public PizzaSize Size { get; private set; }
        public PizzaTypes Type { get; private set; }
        public PizzaToppings Toppings { get; private set; }

        public Pizza(string name,Category category,double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
        public void SetSize(PizzaSize pizzaSize)
        {
            this.Size = pizzaSize;
            switch (pizzaSize)
            {   
                case PizzaSize.Medium:
                    this.Price = 40 + this.Price;
                    break;
                case PizzaSize.Large:
                    this.Price = 100 + this.Price;
                    break;
                default:
                    break;
            }
        }
        public void SetType(PizzaTypes pizzaTypes)
        {
            this.Type = pizzaTypes;
            this.Price = 20 + this.Price;
        }
        public void SetToppings(PizzaToppings pizzaToppings)
        {
            this.Toppings = pizzaToppings;
            this.Price = 10 + this.Price;
        }
    }
}
