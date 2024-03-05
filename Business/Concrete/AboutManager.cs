using Business.Abstarct;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.Abstract.IResult;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public async Task<IResult> AddAboutByLanguageAsync(AboutAddDTO aboutAddDTO)
        {
            var result = await _aboutDAL.AddAbout(aboutAddDTO);
            if (result)
            {
                return new SuccessResult("About created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
