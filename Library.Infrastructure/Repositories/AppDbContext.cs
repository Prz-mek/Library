using Library.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
        public DbSet<BranchLibrary> BranchLibrary { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<LibraryCard> LibraryCard { get; set; }
        public DbSet<Reader> Reader { get; set; }
    }
}
