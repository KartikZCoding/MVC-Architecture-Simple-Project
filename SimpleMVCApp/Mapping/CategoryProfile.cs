using AutoMapper;
using SimpleMVCApp.DTOs;
using SimpleMVCApp.Models;

namespace SimpleMVCApp.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Entity → DTO
            CreateMap<Category, CategoryDto>();

            // DTO → Entity
            CreateMap<SaveCategoryDto, Category>();

            CreateMap<CategoryDto, Category>();
        }
    }
}
