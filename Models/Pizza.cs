namespace pizzashop_tutorial.Models;

public class Pizza
{
    public int PizzaId { get; set; }
    public string? PizzaName { get; set; }
    public bool IsGlutenFree { get; set; } = false;
}
