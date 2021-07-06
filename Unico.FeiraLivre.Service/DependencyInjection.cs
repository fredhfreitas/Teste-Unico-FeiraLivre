using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Unico.FeiraLivre.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }       
    }
}

