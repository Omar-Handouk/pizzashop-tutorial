using pizzashop_tutorial.Models;

namespace pizzashop_tutorial.Services;

public class PizzaService
{
    public static List<Pizza> Pizzas { get; }
    private static int NextPizzaId = 0;

    static PizzaService() {
        // Initialize initial pizza inventory
        Pizzas = [
            new() { PizzaId = NextPizzaId++, PizzaName = "Classic Italian"},
            new() { PizzaId = NextPizzaId++, PizzaName = "Vegetarian", IsGlutenFree = true}
        ];
    }

    public static void Add(Pizza pizza) {
        pizza.PizzaId = NextPizzaId++;
        Pizzas.Add(pizza);
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int pizzaId) => Pizzas.FirstOrDefault<Pizza>(p => p.PizzaId == pizzaId);

        public static void Update(Pizza pizza) {
        int index = Pizzas.FindIndex(p => p.PizzaId == pizza.PizzaId);
        if (index <= -1) {
            return;
        }

        Pizzas[index] = pizza;
    }

    public static void Delete(int pizzaId){
        Pizza? pizza = Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
        if (pizza is null) {
            return;
        }

        Pizzas.Remove(pizza);
    }
}
