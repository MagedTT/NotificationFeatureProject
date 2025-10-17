using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotificationFeatureProject.Models;

namespace NotificationFeatureProject.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Pet> Pets { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
