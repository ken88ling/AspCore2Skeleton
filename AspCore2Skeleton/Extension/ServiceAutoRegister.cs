using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspCore2Skeleton.Extension
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ServiceAutoRegister(this IServiceCollection services, params Assembly[] assemblies)
        {
            var publicClassTypes = assemblies.SelectMany(x => x.GetExportedTypes()
                .Where(
                    y => y.IsClass
                         && !y.IsAbstract
                         && !y.IsGenericType
                         && !y.IsNested
                         && y.Name.EndsWith("Service"))
            );

            foreach (var classType in publicClassTypes)
            {
                var interfaces = classType.GetTypeInfo().ImplementedInterfaces
                    .Where(i => i != typeof(IDisposable) && (i.IsPublic));
                if (interfaces.Any())
                {
                    foreach (var intfc in interfaces)
                    {
                        services.Add(new ServiceDescriptor(intfc, classType, ServiceLifetime.Singleton));
                    }
                }
                else
                {
                    services.Add(new ServiceDescriptor(classType, classType, ServiceLifetime.Singleton));
                }
            }

            return services;
        }
    }
}
