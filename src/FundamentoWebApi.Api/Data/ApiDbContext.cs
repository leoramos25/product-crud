using FundamentoWebApi.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FundamentoWebApi.Api.Data;

public class ApiDbContext : IdentityDbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}