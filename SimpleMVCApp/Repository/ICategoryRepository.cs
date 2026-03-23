using SimpleMVCApp.DTOs;
using SimpleMVCApp.Models;

namespace SimpleMVCApp.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<int> SaveCategory(SaveCategoryDto dto);
        Task<bool> DeleteCategory(int id);
    }
}
