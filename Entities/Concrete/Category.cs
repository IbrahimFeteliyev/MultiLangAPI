﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public bool IsFeatured { get; set; }
        public List<CategoryLanguage> CategoryLanguages { get; set; }
    }
}
