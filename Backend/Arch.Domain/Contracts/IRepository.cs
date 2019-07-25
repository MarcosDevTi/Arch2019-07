using System;
using System.Collections.Generic;
using Arch.Domain.Core;

namespace Arch.Domain.Contracts
{
    public interface IRepository<T>
         where T: Entity
    {
         void Add(T obj);
         void Edit(T obj);
         T Get(Guid id);
         IEnumerable<TViewModel> Get<TViewModel>();
         void Save();
    }
}