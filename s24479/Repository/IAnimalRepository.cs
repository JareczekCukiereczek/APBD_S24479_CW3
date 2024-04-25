using Microsoft.AspNetCore.Mvc;

namespace Animal.Controller;

public interface IAnimalRepository
{
    List<Animal> GetAnimals();
    void AddAnimal(Animal newAnimal);
    void UpdateAnimal(Animal updatedAnimal);
    
    Animal GetAnimalById(int id);
}