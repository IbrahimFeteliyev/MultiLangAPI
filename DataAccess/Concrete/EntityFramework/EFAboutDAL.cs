using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFAboutDAL : EfEntityRepositoryBase<About, AppDbContext>, IAboutDAL
    {
        public async Task<bool> AddAbout(AboutAddDTO aboutAddDTO)
        {
            try
            {
                using var context = new AppDbContext();
                About about = new()
                {
                    PhotoUrl = aboutAddDTO.PhotoUrl,
                };

                await context.Abouts.AddAsync(about);
                await context.SaveChangesAsync();

                for (int i = 0; i < aboutAddDTO.Content.Count; i++)
                {
                    AboutLanguage aboutLanguage = new()
                    {
                        AboutId = about.Id,
                        Content = aboutAddDTO.Content[i],
                        LangCode = aboutAddDTO.LangCode[i]

                    };
                    await context.AboutLanguages.AddAsync(aboutLanguage);
                }

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
