﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texim.Data.IDAL
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
        void Rollback();

    }
}
