using ComicBookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComicBookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ComicCompany> ComicCompanies { get; set; }
        public DbSet<ComicCategory> ComicCategories { get; set; }
        public DbSet<ComicInfo> ComicInfos { get; set; }
        public DbSet<ComicOrder> ComicOrders { get; set; }
    }
}
