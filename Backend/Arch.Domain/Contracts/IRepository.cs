using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arch.Domain.Core;

namespace Arch.Domain.Contracts
{
    public interface IRepository<T>
         where T: Entity
    {
         void Add(T obj);
         void Edit(T obj);
         T Get(Guid id);
         T Get(Func<T, bool> predicate);
         TViewModel Get<TViewModel>(Guid id);
         TViewModel Get<TViewModel>(Func<T, bool> predicate);
         IEnumerable<TViewModel> GetList<TViewModel>();
         IEnumerable<TViewModel> GetList<TViewModel>(Func<T, bool> predicate);
         bool Any(Func<T, bool> predicate);
         void Save();
    }
}