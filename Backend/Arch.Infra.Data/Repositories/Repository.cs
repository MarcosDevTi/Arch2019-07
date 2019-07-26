using System;
using System.Collections.Generic;
using System.Linq;
using Arch.Domain.Contracts;
using Arch.Domain.Core;
using AutoMapper;
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
        public void Add(T obj) =>
            _context.Add(obj);

        public void Edit(T obj) =>
            _context.Attach(obj);

        public T Get(Guid id) =>
             _context.Set<T>().Find(id);

        public T Get(Func<T, bool> predicate) =>
             _context.Set<T>().FirstOrDefault(predicate);

        public TViewModel Get<TViewModel>(Guid id) =>
            Mapper.Map<TViewModel>(_context.Set<T>().Find(id));

        public TViewModel Get<TViewModel>(Func<T, bool> predicate) =>
             Mapper.Map<TViewModel>(_context.Set<T>().FirstOrDefault(predicate));

        public IEnumerable<TViewModel> GetList<TViewModel>() =>
             _context.Set<T>().ProjectTo<TViewModel>();

        public IEnumerable<TViewModel> GetList<TViewModel>(Func<T, bool> predicate) =>
             _context.Set<T>().ProjectTo<TViewModel>();

        public bool Any(Func<T, bool> predicate) =>
            _context.Set<T>().Any(predicate);

        public void Save() =>
            _context.SaveChanges();
    }
}