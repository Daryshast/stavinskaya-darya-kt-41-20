using stavinskaya_darya_kt_41_20.Interfaces.DisciplineInterfaces;

namespace stavinskaya_darya_kt_41_20.ServiceExtensions
{
        public static class ServiceExtensions
        {
            public static IServiceCollection AddServices(this IServiceCollection services)
            {

                services.AddScoped<IDisciplineServices, DisciplineServices>();

                return services;
            }
        }
    }
