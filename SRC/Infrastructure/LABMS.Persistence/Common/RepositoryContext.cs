using LABMS.Domain.entities;
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
    }
}
