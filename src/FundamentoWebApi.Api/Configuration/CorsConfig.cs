namespace FundamentoWebApi.Api.Configuration;

public static class CorsConfig
{
    public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Development", builder =>
            {
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });

            options.AddPolicy("Production", builder =>
            {
                builder
                .WithOrigins("https://localhost:9000")
                .WithMethods("POST")
                .AllowAnyHeader();
            });
        });
        return builder;
    }
}