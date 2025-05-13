using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

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

    // Put action

    // Delete action

}