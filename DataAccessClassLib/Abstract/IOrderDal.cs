﻿using ClassLibEntities.Concrete;
using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
