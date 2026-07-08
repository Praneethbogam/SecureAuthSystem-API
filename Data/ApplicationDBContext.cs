using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Models;
using System.Collections.Generic;

namespace SecureAuthSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
        DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }


    }
}