

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




    }
}
