using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryDTOs
{
    public class CategoryAddDTO
    {
        public IFormFile PhotoUrl { get; set; }
        public List<string> CategoryName { get; set; }
        public List<string> LangCode { get; set; }
    }
}
