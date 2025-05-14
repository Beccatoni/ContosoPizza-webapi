using ContosoPizza.Models;

public interface IPizzaService
{
    List<Pizza> GetAll();
    Pizza? Get(int id);
    void Add(Pizza pizza);
    void Update(Pizza pizza);
    void Delete(int id);
}