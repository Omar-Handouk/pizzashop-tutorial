using Microsoft.AspNetCore.Mvc;
using pizzashop_tutorial.Models;
using pizzashop_tutorial.Services;

namespace pizzashop_tutorial.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PizzaController(ILogger<PizzaController> _logger) : ControllerBase
{
    private readonly ILogger<PizzaController> _logger = _logger;

    [HttpPost(Name = "CreatePizza")]
    [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] Pizza pizza) {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.PizzaId}, pizza);
    }
    
    [HttpGet(Name = "GetAllPizzas")]
    [ProducesResponseType(typeof(ActionResult<List<Pizza>>), 200)]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}", Name = "GetPizzaById")]
    [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pizza> Get(int id) {
        Pizza? pizza = PizzaService.Get(id);
        return pizza != null ? pizza : NotFound();
    }

    [HttpPut("{id}", Name = "UpdatePizzaById")]
    public IActionResult Update(int id, Pizza pizza) { return Ok();}

    [HttpDelete("{id}", Name = "DeletePizzaById")]
    public IActionResult Delete(int id, Pizza pizza) { return Ok();}
}
