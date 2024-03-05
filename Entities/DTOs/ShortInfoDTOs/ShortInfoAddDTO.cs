using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ShortInfoDTOs
{
    public class ShortInfoAddDTO
    {
        public string Count { get; set; }
        public List<string> Title { get; set; }
        public List<string> LangCode { get; set; }
    }
}
