using Arch.Cqrs.Client.Customer;
using Arch.Cqrs.Handlers.Customer;
using Arch.CrossCutting.AutoMapper;
using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Account;
using Arch.Domain.Contracts;
using Arch.Infra.Data;
using Arch.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arch.Infra.IoC
{
    public class ArchBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            AutoMapperConfig.Register<CreateCustomer>();
            services.AddDbContext<ArchContext>(_ => _.UseSqlite(config.GetConnectionString("ArchConnection")));
            
            services.AddTransient<ICustomerRepository, CustomerRepository>();
             services.AddTransient<IAuthRepository, AuthRepository>();
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProcessor, Processor>();
            services.RegisterCqrs<CustomerCommandHandler>();
           
        }
    }
}