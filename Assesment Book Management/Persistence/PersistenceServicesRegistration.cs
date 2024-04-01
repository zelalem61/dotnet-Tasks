using Application.Contracts.Persistence;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence;

public static class PersistenceServicesRegistration
{
   

    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookMgtDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("BookConnectionString")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}






     
