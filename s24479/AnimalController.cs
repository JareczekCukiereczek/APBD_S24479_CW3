

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
            List<Animal> animals = new List<Animal>();

            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Animal";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Animal animal = new Animal
                            {
                                Id = Convert.ToInt32(reader["IdAnimal"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                Description = reader["Description"].ToString(),
                                Area = reader["Area"].ToString()
                            };
                            animals.Add(animal);
                        }
                    }
                }
            }

            return Ok(animals);
        }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
    }
}
