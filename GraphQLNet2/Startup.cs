using DAL;
using DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using GraphQLNet2.Models.Schemas;
using GraphQL.Types;
using GraphQLNet2.Models.Types;
using GraphQLNet2.Models.InputTypes;
using GraphQLNet2.Models.Mutations;
using GraphQLNet2.Models.Queries;
using GraphQL;
using GraphiQl;

namespace GraphQLNet2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var dbConfig = new MongoConfig();
            Configuration.Bind("MongoConfig", dbConfig);

            services.AddHttpContextAccessor();
            services.AddSingleton(dbConfig);
            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddAutoMapper(typeof(INewsRepository).Assembly);
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<NewsQuery>();
            services.AddScoped<NewsMutation>();
            services.AddScoped<NewsType>();
            services.AddScoped<NewsInputType>();
            services.AddScoped<CommentType>();
            services.AddScoped<ISchema, NewsSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
