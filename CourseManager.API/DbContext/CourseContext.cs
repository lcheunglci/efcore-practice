﻿using CourseManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.API.DbContexts
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public CourseContext()
        { }

        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CourseManagerDB;Trusted_Connection=True;");
        //    }
        //}
    }
}
