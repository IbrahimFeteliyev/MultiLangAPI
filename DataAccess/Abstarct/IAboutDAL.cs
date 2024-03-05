using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
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
    public interface IAboutDAL : IEntityRepository<About>
    {
        Task<bool> AddAbout(AboutAddDTO aboutAddDTO);
    }
}

