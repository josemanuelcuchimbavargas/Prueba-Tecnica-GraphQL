using Backend.GraphQL;
using Backend.Model;
using Core.IService;
using Core.Service;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup()
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
            services.AddDbContext<DBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("conn")));
            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddGraphQL(c => SchemaBuilder.New().AddServices(c).AddType<GraphQLTypes>()
                                                                        .AddQueryType<Query>()
                                                                        .AddMutationType<Mutation>()
                                                                         .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            app.UseGraphQL("/api");
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
