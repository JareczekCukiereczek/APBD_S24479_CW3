

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Animal.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase

    {
    private readonly IConfiguration _configuration;

    public AnimalController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("animals")]
    public IActionResult GetAnimals()
    {
        AnimalRepository animalRepository = new AnimalRepository();
        var animals = animalRepository.GetAnimals();
        return Ok(animals);
    }

    [HttpPost("animals")]
    public IActionResult AddAnimal([FromBody] Animal newAnimal)
    {
        if (newAnimal == null)
        {
            return BadRequest("Animal object is null");
        }

        AnimalRepository animalRepository = new AnimalRepository();
        animalRepository.AddAnimal(newAnimal);

        return Ok("Animal added successfully");
    }

    [HttpPut("animals/{idAnimal}")]
    public IActionResult UpdateAnimal(int idAnimal, [FromBody] Animal updatedAnimal)
    {
        if (updatedAnimal == null || idAnimal != updatedAnimal.Id)
        {
            return BadRequest("Invalid request data");
        }

        AnimalRepository animalRepository = new AnimalRepository();
        var existingAnimal = animalRepository.GetAnimalById(idAnimal);

        if (existingAnimal == null)
        {
            return NotFound("Animal not found");
        }

        existingAnimal.Name = updatedAnimal.Name;
        existingAnimal.Category = updatedAnimal.Category;
        existingAnimal.Description = updatedAnimal.Description;
        existingAnimal.Area = updatedAnimal.Area;

        animalRepository.UpdateAnimal(existingAnimal);

        return Ok("Animal updated successfully");
    }





    }
}
