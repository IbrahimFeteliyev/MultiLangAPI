using Core.DataAccess.EntityFramework;
using Core.Helper;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDAL : EfEntityRepositoryBase<Category, AppDbContext>, ICategoryDAL
    {
        public async Task<bool> AddCategory(CategoryAddDTO categoryAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Category category = new()
                {
                    PhotoUrl = await categoryAddDTO.PhotoUrl.SaveFileAsync(webRootPath),
                    IsFeatured = false  
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                for (int i = 0; i < categoryAddDTO.CategoryName.Count; i++)
                {
                    CategoryLanguage categoryLanguage = new()
                    {
                        CategoryId = category.Id,
                        CategoryName = categoryAddDTO.CategoryName[i],
                        LangCode = categoryAddDTO.LangCode[i]

                    };
                    await context.CategoryLanguages.AddAsync(categoryLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<CategoryFeaturedDTO> GetCategoryFeatureds(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.CategoryLanguages
                .Include(x => x.Category)
                .Where(x => x.LangCode == langCode && x.Category.IsFeatured == true)
                .Select(x => new CategoryFeaturedDTO(x.Category.Id, x.CategoryName, x.Category.PhotoUrl)).ToList();

            return result;
        }
        public List<CategoryAdminListDTO> GetAllCategoriesAdminList(string langCode)
        {

            using var context = new AppDbContext();

            var result = context.Categories.Select(x => new CategoryAdminListDTO
            {
                Id = x.Id,
                CategoryName = x.CategoryLanguages.FirstOrDefault(x => x.LangCode == langCode).CategoryName,
                PhotoUrl = x.PhotoUrl,
                IsFeatured = x.IsFeatured,
            }).ToList();

            return result;
        }

        public CategoryAdminDetailDTO GetCategoryByIdAdmin(int id)
        {
            using var context = new AppDbContext();

            var result = context.Categories.Include(x => x.CategoryLanguages)
                .Select(x => new CategoryAdminDetailDTO()
                {
                    Id = x.Id,
                    IsFeatured = x.IsFeatured,
                    PhotoUrl = x.PhotoUrl,
                    CategoryName = x.CategoryLanguages.Select(x => x.CategoryName).ToList(),
                    //LangCode = x.CategoryLanguages.Select(x => x.CategoryName).ToList()
                })
                .FirstOrDefault(x => x.Id == id);
            return result;
        }


        public async Task<bool> UpdateCategory(CategoryAdminDetailDTO categoryEditDTO, IFormFile formFile, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var category = context.Categories.FirstOrDefault(x => x.Id == categoryEditDTO.Id);

                category.IsFeatured = categoryEditDTO.IsFeatured;
                if (formFile != null)
                {
                    category.PhotoUrl = await formFile.SaveFileAsync(webRootPath);
                }

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                var categoryLanguage = context.CategoryLanguages.Where(x => x.CategoryId == category.Id).ToList();

                for (int i = 0; i < categoryLanguage.Count; i++)
                {
                    categoryLanguage[i].CategoryName = categoryEditDTO.CategoryName[i];
                }
                context.CategoryLanguages.UpdateRange(categoryLanguage);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
