using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;

namespace BlogApi.Application;

public static class ApplicationServiceRegistration{
    public static IServiceCollection ConfigureApplicationService(this IServiceCollection services){
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}