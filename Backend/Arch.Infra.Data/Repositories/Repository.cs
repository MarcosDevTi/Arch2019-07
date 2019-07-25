using System;
using System.Collections.Generic;
using System.Linq;
using Arch.Domain.Contracts;
using Arch.Domain.Core;
using AutoMapper.QueryableExtensions;

namespace Arch.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T: Entity
    {
        protected readonly ArchContext _context;
        public Repository(ArchContext context)
        {
            _context = context;
        }
        public void Add(T obj)
        {
            _context.Add(obj);
        }

        public void Edit(T obj)
        {
            _context.Attach(obj);
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<TViewModel> Get<TViewModel>()
        {
            return _context.Set<T>().ProjectTo<TViewModel>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}