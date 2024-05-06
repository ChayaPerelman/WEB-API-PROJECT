
//global using Microsoft.EntityFrameworkCore;

//using sale_webapi.DAL;
//using sale_webapi.BLL;

//using AutoMapper;
//using sale_webapi;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//internal class Program
//{ 
//    private readonly IConfiguration _config;
//    public Program(IConfiguration config)
//    {
//        _config = config;
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        //clarify code
//        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//            .AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                };
//            });
//    }
//    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//    {
//        //clarify code
//        app.UseAuthentication();

//        app.UseAuthorization();
//        //clarify code

//    }
//    private static void Main(string[] args)
//    {
//        var builder = WebApplication.CreateBuilder(args);

//        builder.Services.AddScoped<IDonorservice, DonorService>();
//        builder.Services.AddScoped<IGiftService, GiftService>();
//        builder.Services.AddScoped<IOrderService, OrderService>();
//        builder.Services.AddScoped<IOrderItemService, OrderItemService>();
//        builder.Services.AddScoped<IUserService, UserService>();
//        builder.Services.AddScoped<IWinnerService, WinnerService>();
//        builder.Services.AddScoped<IAccountService, AccountService>();
//        builder.Services.AddScoped<ITokenService, TokenService>();
//        //builder.Services.AddScoped<IHomeService, HomeService>();
//        //
//        builder.Services.AddScoped<IDonorDal, DonorDal>();
//        builder.Services.AddScoped<IGiftDal, GiftDal>();
//        builder.Services.AddScoped<IOrderItemDal, OrderItemDal>();
//        builder.Services.AddScoped<IOrderDal, OrderDal>();
//        builder.Services.AddScoped<IUserDal, UserDal>();
//        builder.Services.AddScoped<IWinnerDal, WinnerDal>();
//        builder.Services.AddScoped<IAccountDal, AccountDal>();
//        //builder.Services.AddScoped<IHomeDal, HomeDal>();


//        // Add services to the container.

//        builder.Services.AddControllers();
//        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//        builder.Services.AddEndpointsApiExplorer();
//        builder.Services.AddSwaggerGen();
//        builder.Services.AddDbContext<OrdersContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("OrdersContext")));
//        builder.Services.AddCors(options =>
//        {
//            options.AddPolicy("CorsPolicy", //give it the name you want
//                          builder =>
//                          {
//                              builder.WithOrigins("http://localhost:4200",
//                                                   "development web site")
//                                                  .AllowAnyHeader()
//                                                  .AllowAnyMethod()
//                                                  ;
//                          });

//        });

//        var mapperConfig = new MapperConfiguration(mc =>
//        {
//            mc.AddProfile(new MappingProfile());
//        });

//        IMapper mapper = mapperConfig.CreateMapper();
//        builder.Services.AddSingleton(mapper);

//        var app = builder.Build();

//        // Configure the HTTP request pipeline.
//        if (app.Environment.IsDevelopment())
//        {
//            app.UseSwagger();
//            app.UseSwaggerUI();
//        }

//        app.UseHttpsRedirection();
//        app.UseCors("CorsPolicy");
//        app.UseAuthorization();

//        app.MapControllers();

//        app.Run();
//    }
//}


 global using Microsoft.EntityFrameworkCore;

using sale_webapi.DAL;
using sale_webapi.BLL;
//using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using sale_webapi.Middleware;
using Microsoft.OpenApi.Models;
using System.Collections.Immutable;
using sale_webapi.Models;
using sale_webapi.BLL;
using sale_webapi.DAL;
using Swashbuckle.AspNetCore.Filters;
using Castle.Core.Smtp;
using MDriven.MDrivenServer;
using Castle.Core.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Antlr4.Runtime.Misc;

namespace AngularServer1
{
    public class Program
    {
        public IConfiguration Configuration { get; }


        public Program(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        private static void Main(string[] args)
        {         CreateHostBuilder(args).Build().Run();

            //var builder = WebApplication.CreateBuilder(args).Run();
        }
      

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
        });

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddLogging();

            Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           Services.AddScoped<IDonorservice, DonorService>();
            Services.AddScoped<IGiftService, GiftService>();
            Services.AddScoped<IOrderService, OrderService>();
            Services.AddScoped<IOrderItemService, OrderItemService>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IWinnerService, WinnerService>();
            //Services.AddScoped<IAccountService, AccountService>();
            //Services.AddScoped<ITokenService, TokenService>();
            //builder.Services.AddScoped<IHomeService, HomeService>();
            //
            Services.AddScoped<IDonorDal, DonorDal>();
            Services.AddScoped<IGiftDal, GiftDal>();
            Services.AddScoped<IOrderItemDal, OrderItemDal>();
            Services.AddScoped<IOrderDal, OrderDal>();
            Services.AddScoped<IUserDal, UserDal>();
            Services.AddScoped<IWinnerDal, WinnerDal>();
           // Services.AddScoped<IAccountDal, AccountDal>();

            Services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            //Services.AddTransient<IEmailSender, AuthMessageSender>();

            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddDbContext<OrdersContext>(options =>
                                                      options.UseSqlServer(Configuration.GetConnectionString("OrdersContext")));
            Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "development web site")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });

            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            Services.AddMvc();
            Services.AddControllers();
            Services.AddRazorPages();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            //app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/OrderItem"),donorApp =>
            //{
            //    donorApp.UseMiddleware<AuthenticationMiddleware>();
            //});
            app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api/User/login") && !context.Request.Path.StartsWithSegments("/api/Register"), orderApp =>
            {
                orderApp.UseMiddleware<AuthenticationMiddleware>();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            
        }
    }
}




