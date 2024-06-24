using LDKProject.Models;
using LDKProject.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LDKProject.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<CategoryArticle> CategoryArticle { get; set; }
        public DbSet<Event> Event { get; set; }


    }
}
