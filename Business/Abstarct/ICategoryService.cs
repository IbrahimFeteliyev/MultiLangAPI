using Core.Utilities.Results.Abstract;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;

using static Entities.DTOs.CategoryDTOs.CategoryDTO;


namespace Business.Abstarct
{
    public interface ICategoryService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddCategoryByLanguageAsync(CategoryAddDTO categoryAddDTO, string webRootPath);
        Task<Core.Utilities.Results.Abstract.IResult> UpdateCategoryByLanguageAsync(CategoryAdminDetailDTO categoryEditDTO, IFormFile formFile, string webRootPath);
        Core.Utilities.Results.Abstract.IResult RemoveCategory(int id);
        IDataResult<List<CategoryAdminListDTO>> GetAllCategoriesAdmin(string langCode);
        IDataResult<CategoryAdminDetailDTO> GetCategoryById(int id);

        IDataResult<List<CategoryFeaturedDTO>> GetAllCategoriesFeatured(string langCode);


    }
}
