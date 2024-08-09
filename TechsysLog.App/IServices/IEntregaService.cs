﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLog.Domain.Entity;
using TechsysLog.Domain.ObjectValue;

namespace TechsysLog.App.IServices
{
    public interface IEntregaService : IDisposable
    {
        Task<IContractResult> Delete(int id);
        Task<IContractResult> Delete(Guid id);
        Task<IContractResult> Insert(Entrega model);
        Task<IContractResult> Update(Entrega model);
        IContractResult ListAll();
        Task<IContractResult> GetById(int id);
        Task<IContractResult> GetById(Guid id);
    }
}


