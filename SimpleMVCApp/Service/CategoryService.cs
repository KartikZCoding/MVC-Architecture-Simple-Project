using AutoMapper;
using SimpleMVCApp.DTOs;
using SimpleMVCApp.Repository;

namespace SimpleMVCApp.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception($"No record found for id:{id}!");
            }
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<int> SaveCategories(SaveCategoryDto dto)
        {
            return await _categoryRepository.SaveCategory(dto);
        }

        public async Task<bool> DeleteItem(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception($"Item not found with id:{id}");
            }
            await _categoryRepository.DeleteCategory(id);
            return true;
        }
    }
}
