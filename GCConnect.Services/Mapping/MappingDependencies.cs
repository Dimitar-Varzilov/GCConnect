using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

public static class MappingDependencies
{
    public static IServiceCollection AddAppMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, typeof(UsersProfile).Assembly);
        return services;
    }
}
