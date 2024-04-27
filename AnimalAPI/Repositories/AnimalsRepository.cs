namespace AnimalAPI.Repositories;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AnimalAPI.Models;
using Microsoft.Extensions.Configuration;

public class AnimalsRepository : IAnimlasRepository
{
    private readonly string _connectionString;

    public AnimalsRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
     public List<object> GetAnimals(string orderBy)
        {
            List<object> animals = new List<object>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string queryString = $"SELECT * FROM Animal ORDER BY {orderBy}";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var animal = new
                    {
                        IdAnimal = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Category = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Area = reader.IsDBNull(4) ? null : reader.GetString(4)
                    };
                    animals.Add(animal);
                }
            }

            return animals;
        }

        public void AddAnimal(AnimalCreationDto animalDto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string queryString = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", animalDto.Name);
                command.Parameters.AddWithValue("@Description", animalDto.Description);
                command.Parameters.AddWithValue("@Category", animalDto.Category);
                command.Parameters.AddWithValue("@Area", animalDto.Area);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void UpdateAnimal(int id, Animal animal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string queryString = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@Description", animal.Description);
                command.Parameters.AddWithValue("@Category", animal.Category);
                command.Parameters.AddWithValue("@Area", animal.Area);
                command.Parameters.AddWithValue("@IdAnimal", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAnimal(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string queryString = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@IdAnimal", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    
}

