namespace AnimalAPI.Services;

using System.Collections.Generic;
using AnimalAPI.Models;
using AnimalAPI.Repositories;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimlasRepository _animalsRepository;

    public AnimalsService(IAnimlasRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public List<object> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public void AddAnimal(AnimalCreationDto animalDto)
    {
        _animalsRepository.AddAnimal(animalDto);
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        _animalsRepository.UpdateAnimal(id, animal);
    }

    public void DeleteAnimal(int id)
    {
        _animalsRepository.DeleteAnimal(id);
    }
}
