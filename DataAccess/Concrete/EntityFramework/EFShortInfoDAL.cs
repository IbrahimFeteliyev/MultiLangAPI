using Core.DataAccess.EntityFramework;
using Core.Helper;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ShortInfoDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFShortInfoDAL : EfEntityRepositoryBase<ShortInfo, AppDbContext>, IShortInfoDAL
    {
        public async Task<bool> AddShortInfo(ShortInfoAddDTO shortInfoAddDTO)
        {
            try
            {
                using var context = new AppDbContext();
                ShortInfo shortInfo = new()
                {
                    Count = shortInfoAddDTO.Count
                };

                await context.ShortInfos.AddAsync(shortInfo);
                await context.SaveChangesAsync();

                for (int i = 0; i < shortInfoAddDTO.Title.Count; i++)
                {
                    ShortInfoLanguage shortInfoLanguage = new()
                    {
                        ShortInfoId = shortInfo.Id,
                        Title = shortInfoAddDTO.Title[i],
                        LangCode = shortInfoAddDTO.LangCode[i],

                    };
                    await context.ShortInfoLanguages.AddAsync(shortInfoLanguage);
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ShortInfoAdminListDTO> GetAllShortInfosAdminList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.ShortInfos.Select(x => new ShortInfoAdminListDTO
            {
                Id = x.Id,
                Title = x.ShortInfoLanguages.FirstOrDefault(x => x.LangCode == langCode).Title,
                Count = x.Count,
            }).ToList();

            return result;
        }

        public ShortInfoAdminDetailDTO GetShortInfoByIdAdmin(int id)
        {
            using var context = new AppDbContext();

            var result = context.ShortInfos.Include(x => x.ShortInfoLanguages)
                .Select(x => new ShortInfoAdminDetailDTO()
                {
                    Id = x.Id,
                    Count = x.Count,
                    Title = x.ShortInfoLanguages.Select(x => x.Title).ToList(),
                })
                .FirstOrDefault(x => x.Id == id);
            return result;
        }


        public async Task<bool> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO , int Id)
        {
            try
            {
                using var context = new AppDbContext();
                var shortInfo = context.ShortInfos.FirstOrDefault(x => x.Id == Id);

                shortInfo.Count = shortInfoUpdateDTO.Count;
    

                context.ShortInfos.Update(shortInfo);
                await context.SaveChangesAsync();

                var shortInfoLanguage = context.ShortInfoLanguages.Where(x => x.ShortInfoId == shortInfo.Id).ToList();

                for (int i = 0; i < shortInfoLanguage.Count; i++)
                {
                    shortInfoLanguage[i].Title = shortInfoUpdateDTO.Title[i];
                }
                context.ShortInfoLanguages.UpdateRange(shortInfoLanguage);
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
