
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sale_webapi.BLL;
using sale_webapi.DAL;

namespace sale_webapi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        //services.AddTransient<IBookService, BookService>();



        services.AddDbContext<OrdersContext>(options =>
        options.UseSqlServer(config.GetConnectionString("OrdersContext")));

        return services;
    }
}
