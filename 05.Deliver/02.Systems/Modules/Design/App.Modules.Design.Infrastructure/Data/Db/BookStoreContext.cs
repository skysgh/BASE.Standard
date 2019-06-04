//using System;
//using System.Collections.Generic;
//using System.Text;
//using App.Modules.Design.Shared.Models.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace App.Modules.Design.Infrastructure.Initialization.Data.Db
//{
//    internal class BookStoreContext : DbContext
//    {
//        public BookStoreContext(DbContextOptions<BookStoreContext> options)
//          : base(options)
//        {
//        }


//        public DbSet<Book> Books { get; set; }
//        public DbSet<Press> Presses { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseInMemoryDatabase("BookLists");

//            base.OnConfiguring(optionsBuilder);
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
//        }
//    }
//}
