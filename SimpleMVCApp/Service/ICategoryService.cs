using SimpleMVCApp.DTOs;

namespace SimpleMVCApp.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryById(int id);
        Task<bool> DeleteItem(int id);
        Task<int> SaveCategories(SaveCategoryDto dto);
    }
}
