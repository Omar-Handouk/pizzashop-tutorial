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
        return CreatedAtAction(nameof(Get), new { id = pizza.PizzaId}, pizza);
    }
    
    [HttpGet(Name = "GetAllPizzas")]
    [ProducesResponseType(typeof(ActionResult<List<Pizza>>), 200)]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}", Name = "GetPizzaById")]
    [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pizza> Get([FromRoute] int id) {
        Pizza? pizza = PizzaService.Get(id);
        return pizza != null ? pizza : NotFound();
    }

    [HttpPut("{id}", Name = "UpdatePizzaById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id,[FromBody] Pizza pizza) {
        if (id != pizza.PizzaId) {
            return BadRequest();
        }
        
        Pizza? dbPizza = PizzaService.Get(id);
        if (dbPizza is null) {
            return NotFound();
        }

        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeletePizzaById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id) {
        Pizza? pizza = PizzaService.Get(id);
        if (pizza == null) {
            return NotFound();
        }

        PizzaService.Delete(id);

        return NoContent();
    }
}
