﻿using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal : EFEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        
    }
}
