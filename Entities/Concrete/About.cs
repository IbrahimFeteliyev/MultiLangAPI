﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public List<AboutLanguage> AboutLanguages { get; set; }

    }
}
