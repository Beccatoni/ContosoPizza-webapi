using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController: ControllerBase {
    public PizzaController(){

    }

    //Get all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
    // Get by id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);
        if(pizza is null) return NotFound();
        return pizza;
    }
    // Posst action
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    // CreatedAtAction creates a 201 response with the location of the new resource
    }


    // Put action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza){
       if (id != pizza.Id) return BadRequest();
       var existingPizza = PizzaService.Get(id);
       if(existingPizza is null) return NotFound();
       PizzaService.Update(pizza);
       return NoContent();
       // NoContent returns a 204 response with no content
    }

    // Delete action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var pizza = PizzaService.Get(id);
        if(pizza is null) return NotFound();
        PizzaService.Delete(id);
        return NoContent();
    }

}