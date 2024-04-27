using AnimalAPI.Models;
using AnimalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly AnimalsService _animalService;

    public AnimalsController(AnimalsService animalService)
    {
        _animalService = animalService;
    }
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(AnimalCreationDto animalDto)
    {
        _animalService.AddAnimal(animalDto);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        _animalService.UpdateAnimal(id, animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalService.DeleteAnimal(id);
        return NoContent();
    }
}