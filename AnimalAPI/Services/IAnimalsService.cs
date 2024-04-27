namespace AnimalAPI.Services;

using System.Collections.Generic;
using AnimalAPI.Models;
public interface IAnimalsService
{
    List<object> GetAnimals(string orderBy);
    void AddAnimal(AnimalCreationDto animalDto);
    void UpdateAnimal(int id, Animal animal);
    void DeleteAnimal(int id);
}