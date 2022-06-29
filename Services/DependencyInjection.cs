using Contracts.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.Concrete;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AesEncryptionModel>(configuration.GetSection(nameof(AesEncryptionModel)));

            services = services.AddTransient<IAesEncryption, AesEncryption>();

            return services;
        }
    }
}