using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService : IPizzaService 
{
    // private List<Pizza> Pizzas { get; }
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public List<Pizza> GetAll() => _context.Pizzas.AsNoTracking().ToList();

    public Pizza? Get(int id) => _context.Pizzas.AsNoTracking().FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var pizza = _context.Pizzas.Find(id);
        if (pizza is null) return;
        _context.Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        if(!_context.Pizzas.Any(p => p.Id == pizza.Id)) return;
        _context.Pizzas.Update(pizza);
        _context.SaveChanges();
    }
}