﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ORM
{
    public interface IORM<T> where T : class
    {
        DataTable Select();
        bool Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);

    }
}
