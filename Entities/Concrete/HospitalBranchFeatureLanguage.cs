﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HospitalBranchFeatureLanguage : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LangCode { get; set; }
        public int HospitalBranchFeatureId { get; set; }
        public HospitalBranchFeature HospitalBranchFeature { get; set; }
    }
}
