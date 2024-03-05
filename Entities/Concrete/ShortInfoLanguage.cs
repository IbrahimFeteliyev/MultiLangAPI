using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShortInfoLanguage : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LangCode { get; set; }
        public int ShortInfoId { get; set; }
        public ShortInfo ShortInfo { get; set; }
    }
}
