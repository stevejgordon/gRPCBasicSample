using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ClientPropertyStore>();

            services.AddGrpc();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting(routes =>
            {
                routes.MapGrpcService<PropertyService>();
            });
        }
    }
}