using Core.Utilities.Results.Abstract;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IAboutService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddAboutByLanguageAsync(AboutAddDTO aboutAddDTO);
    }
}
