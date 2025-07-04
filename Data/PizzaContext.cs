using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;


public class PizzaContext : DbContext {
    public PizzaContext(DbContextOptions<PizzaContext> options): base(options){}
    public DbSet<Pizza> Pizzas { get; set; }
    
}