using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Core;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.Commands.ArticleCommands;
using Blog.Application.Commands.CommentCommands;
using Blog.Application.Commands.UserCommands;
using Blog.Application.Email;
using Blog.Application.Queries;
using Blog.Application.Queries.ArticleQuery;
using Blog.Application.Queries.Comment;
using Blog.Application.Queries.User;
using Blog.EfDataAccess;
using Blog.Implementation.Commands;
using Blog.Implementation.Commands.EfArticlesCommand;
using Blog.Implementation.Commands.EfCommentCommand;
using Blog.Implementation.Commands.EfUserCommands;
using Blog.Implementation.Email;
using Blog.Implementation.Logging;
using Blog.Implementation.Queries;
using Blog.Implementation.Queries.ArticlesQuery;
using Blog.Implementation.Queries.CommentQuery;
using Blog.Implementation.Queries.UserQuery;
using Blog.Implementation.Validators.ArticleValidators;
using Blog.Implementation.Validators.CategoryValidators;
using Blog.Implementation.Validators.CommentValidators;
using Blog.Implementation.Validators.UserValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Blog.Api
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
            
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<BlogContext>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
            services.AddTransient<IGetAllCategoriesQuery, EfGetAllCategoriesQuery>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<ICreateArticleCommand, EfCreateArticleCommand>();
            services.AddTransient<IDeleteArticleCommand, EfDeleteArticleCommand>();
            services.AddTransient<IGetArticleQuery, EfGetArticleCommand>();
            services.AddTransient<IGetAllArticlesQuery, EfGetAllArticlesQuery>();
            services.AddTransient<IUpdateArticleCommand, EfUpdateArticleCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetAllUsersQuery, EfGetAllUsersQuery>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IGetCommentQuery, EfGetCommentQuery>();
            services.AddTransient<IGetAllCommentsQuery, EfGetAllCommentsQuery>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateComment>();
            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
              

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateArticleValidator>();
            services.AddTransient<UpdateArticleValidtor>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<JwtManager>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
