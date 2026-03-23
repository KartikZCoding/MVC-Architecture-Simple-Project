using Dapper;
using Microsoft.Data.SqlClient;
using SimpleMVCApp.DTOs;
using SimpleMVCApp.Models;
using System.Data;

namespace SimpleMVCApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<List<Category>> GetAll()
        {
            using var conn = CreateConnection();
            var result = await conn.QueryAsync<Category>("SP_GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Category> GetById(int id)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<Category>("SP_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> SaveCategory(SaveCategoryDto dto)
        {
            using var conn = CreateConnection();
            var parameters = new
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
            var result = await conn.QuerySingleAsync<int>("SP_SaveCategory", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            using var connection = CreateConnection();
            var affectedRows = await connection.ExecuteAsync("SP_DeleteCategory", new { Id = id }, commandType: CommandType.StoredProcedure);
            return affectedRows > 0;
        }

    }
}
