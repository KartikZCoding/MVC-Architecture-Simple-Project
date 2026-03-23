using Microsoft.AspNetCore.Mvc;
using SimpleMVCApp.DTOs;
using SimpleMVCApp.Service;

namespace SimpleMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                return Json(new { success = true, data = categories });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                return Json(new { success = true, data = category });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveCategoryDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Json(new { success = false, message = "Category name is required." });

                var result = await _categoryService.SaveCategories(dto);
                var msg = (dto.Id.HasValue && dto.Id > 0)
                    ? "Category updated successfully."
                    : "Category created successfully.";

                return Json(new { success = true, message = msg, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                var result = await _categoryService.DeleteItem(id);
                return Json(new { success = true, message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
