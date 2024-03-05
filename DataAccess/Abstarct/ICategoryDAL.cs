using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace DataAccess.Abstarct
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        Task<bool> AddCategory(CategoryAddDTO categoryAddDTO, string webRootPath);
        Task<bool> UpdateCategory(CategoryAdminDetailDTO categoryEditDTO, IFormFile formFile, string webRootPath);
        List<CategoryAdminListDTO> GetAllCategoriesAdminList(string langCode);
        CategoryAdminDetailDTO GetCategoryByIdAdmin(int id);

        List<CategoryFeaturedDTO> GetCategoryFeatureds(string langCode);
    }
}
