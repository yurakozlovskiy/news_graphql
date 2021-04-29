using DAL.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewsGraphQL.Models.Mutations;
using NewsGraphQL.Models.Queries;
using NewsGraphQL.Models.Schemes;
using NewsGraphQL.Models.Types;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using DAL.Context;
using AutoMapper;
using DAL.Mapping;
using System.Reflection;
using Newtonsoft.Json;
using NewsGraphQL.Models.InputTypes;

namespace NewsGraphQL
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
            /*services.Configure<MongoConfig>(Configuration.GetSection(nameof(MongoConfig)));
            services.AddSingleton<IConfig>(x => x.GetRequiredService<IOptions<MongoConfig>>().Value);*/

            //services.AddDbContext()
            var dbConfig = new MongoConfig();
            Configuration.Bind("MongoConfig", dbConfig);
            services.AddSingleton(dbConfig);

            services.AddHttpContextAccessor();
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            services.AddHttpContextAccessor();

            /*services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            });*/
            //.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
            /*.AddSystemTextJson()
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseHttpsRedirection();
            app.UseGraphiQl();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
