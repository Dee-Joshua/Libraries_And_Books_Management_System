﻿using LABMS.Domain.entities;
using LABMS.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Common
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AmazonBooks> AmazonBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Books_At_Library> Books_At_Libraries { get; set; }
        public DbSet<Books_By_Author> Books_By_Authors { get; set; }
        public DbSet<Books_By_Category> Books_By_Categories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRequest> MemberRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books_By_Author>().HasKey(x => new { x.AuthorId });
            modelBuilder.Entity<Books_By_Author>().HasKey(x => new { x.Isbn });
            modelBuilder.Entity<Books_By_Category>().HasKey(x => new { x.CategoryId });
            modelBuilder.Entity<Books_By_Category>().HasKey(x => new { x.Isbn });
            modelBuilder.Entity<Books_At_Library>().HasKey(x => new { x.LibraryId });
            modelBuilder.Entity<Books_At_Library>().HasKey(x => new { x.Isbn });

            //Database seeding 
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new AmazonBooksConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new Books_At_LibraryConfiguration());
            modelBuilder.ApplyConfiguration(new Books_By_AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BooksConfiguration());
            modelBuilder.ApplyConfiguration(new LibrariesConfiguration());
            modelBuilder.ApplyConfiguration(new MemberRequestsConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
        }
    }
}
