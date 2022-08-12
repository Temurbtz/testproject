using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class ApplicationDbContext:IdentityDbContext<Author>
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

         public DbSet<Author>   Authors {get;set;}

          public DbSet<Photo>   Photoes {get;set;}

           public DbSet<Text>   Texts {get;set;}

        
    }
}