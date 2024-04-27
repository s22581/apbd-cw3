using System.Collections.Generic;
using AnimalAPI.Models;

namespace AnimalAPI.Repositories;

public interface IAnimlasRepository
{
    List<object> GetAnimals(string orderBy);
    void AddAnimal(AnimalCreationDto animalDto);
    void UpdateAnimal(int id, Animal animal);
    void DeleteAnimal(int id);
}