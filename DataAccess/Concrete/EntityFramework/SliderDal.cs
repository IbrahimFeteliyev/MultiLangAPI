﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SliderDal : EfEntityRepositoryBase<Slider, AppDbContext>, ISliderDal
    {
    }
}