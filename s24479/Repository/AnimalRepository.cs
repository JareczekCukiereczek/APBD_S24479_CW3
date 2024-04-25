using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Animal.Controller{
    public class AnimalRepository
    {
        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            //string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection("Data Source=localhost,1433;Initial Catalog=master;User=SA;Password=Password12345;TrustServerCertificate=True"))
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

            return animals;
        }
        public void AddAnimal(Animal newAnimal)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost,1433;Initial Catalog=master;User=SA;Password=Password12345;TrustServerCertificate=True"))
            {
                string query = "INSERT INTO Animal (Name, Category, Description, Area) VALUES (@Name, @Category, @Description, @Area)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", newAnimal.Name);
                    command.Parameters.AddWithValue("@Category", newAnimal.Category);
                    command.Parameters.AddWithValue("@Description", newAnimal.Description);
                    command.Parameters.AddWithValue("@Area", newAnimal.Area);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}