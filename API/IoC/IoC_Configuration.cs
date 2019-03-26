using Autofac;
using Business;
using Data;
using Data.Repositories;
using Domain.Interfaces;

namespace API.IoC
{
    public class IoC_Configuration : IIoC_Configuration
    {
        public IContainer Container(ContainerBuilder builder)
        {
            builder.RegisterType<DBContext>().As<IDbContext>();

            //Services
            builder.RegisterType<PersonService>().As<IPersonService>();

            //Repositories
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();

            return builder.Build();
        }
    }
}