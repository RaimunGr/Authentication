using Core.DomainModel.UserAggregate.Data;
using Infra.ApplicationServices.Queries.UserAggregate;
using Infra.ApplicationServices.Utility;
using Infra.Dal;
using Infra.Dal.UserAggregate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infra.ApplicationServices
{
    public static class ApplicationServicesBootstrapper
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(typeof(GetUserByIdQuery).GetTypeInfo().Assembly);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, AppUnitOfWork>();
        }
    }
}
