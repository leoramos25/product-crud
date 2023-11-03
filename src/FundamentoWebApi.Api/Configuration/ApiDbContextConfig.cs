using FundamentoWebApi.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FundamentoWebApi.Api.Configuration;

public static class ApiDbContextConfig
{
    public static WebApplicationBuilder AddApiDbContextConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApiDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        return builder;
    }
}