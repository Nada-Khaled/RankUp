using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {

        }
        public DbSet<ReviewRequests> reviewRequests { get; set; }
        public DbSet<BoardUsers> boardUsers { get; set; }
        public DbSet<BaseDataTable> baseData { get; set; }
        public DbSet<ReviewFormSections> ReviewFormSections { get; set; }
        public DbSet<ReviewFormQuestions> ReviewFormQuestions { get; set; }
        public DbSet<ReviewFormOptions> ReviewFormOptions { get; set; }
        public DbSet<questionType> questionTypes { get; set; }
        public DbSet<ReviewContent> reviewContent { get; set; }
        public DbSet<ToDoList> toDoList { get; set; }
        public DbSet<StatisticalData> statisticalData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string USER_ROLE_ID = "341843f0-add2–42de-afbf-59kkmkmk72cf6";
            modelBuilder.Entity<BaseDataTable>().HasData(new BaseDataTable {id=1, CompanyName = "RankUp",maxCVReviewPerPerson=5,maxCVReviewPerMonth=3 });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = ADMMIN_ROLE_ID,
                ConcurrencyStamp = ADMMIN_ROLE_ID
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "User",
                NormalizedName = "User",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });
            modelBuilder.Entity<questionType>().HasData(
                new questionType { id = 1, type = "multiselect" },
                new questionType { id = 2, type = "slider" },
                new questionType { id = 3, type = "text" },
                new questionType { id = 4, type = "radiobutton" }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
