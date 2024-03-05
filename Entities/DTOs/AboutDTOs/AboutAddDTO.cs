using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AboutDTOs
{
    public class AboutAddDTO
    {
        public string PhotoUrl { get; set; }
        public List<string> Content { get; set; }
        public List<string> LangCode { get; set; }
    }
}
