using Microsoft.EntityFrameworkCore;
using AppleAccounts.Models;

namespace AppleAccounts.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AppleId> AppleIds { get; set; }

}