using System;
using System.Linq;
using System.Reflection;
using Arch.CrossCutting.CqrsContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Arch.Infra.IoC
{
    public static class CqrsExtensions
    {
        public static void RegisterCqrs<TPath>(this IServiceCollection services, Func<AssemblyName, bool> filter = null)
        {
            var target = typeof(TPath).Assembly;
            bool FilterTrue(AssemblyName a) => true;
            var handlers = new [] {typeof(ICommandHandler<>), typeof(IQueryHandler<,>)};

            var assemblies = target.GetReferencedAssemblies()
                .Where(filter ?? FilterTrue)
                .Select(Assembly.Load)
                .ToList();
            assemblies.Add(target);

            var types = from implementation in assemblies.SelectMany(a => a.GetExportedTypes())
                        from contract in implementation.GetInterfaces()
                        where contract.IsConstructedGenericType &&
                        handlers.Contains(contract.GetGenericTypeDefinition())
                        select new {contract, implementation};

            foreach(var tp in types)
                services.AddTransient(tp.contract, tp.implementation);                        
        }
    }
}