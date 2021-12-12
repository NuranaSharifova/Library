using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.Model
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Booksale> Booksales { get; set; }
        public virtual DbSet<Booksinstock> Booksinstocks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reservedbook> Reservedbooks { get; set; }
        public virtual DbSet<Salesman> Salesmen { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Library; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMINS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("AUTHORS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LASTNAME");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOKS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Authorid).HasColumnName("AUTHORID");

                entity.Property(e => e.Continued)
                    .HasColumnName("CONTINUED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostPrice)
                    .HasColumnType("money")
                    .HasColumnName("COST_PRICE");

                entity.Property(e => e.Genreid).HasColumnName("GENREID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");

                entity.Property(e => e.Pages).HasColumnName("PAGES");

                entity.Property(e => e.Publisherid).HasColumnName("PUBLISHERID");

                entity.Property(e => e.PublishingDate).HasColumnName("PUBLISHING_DATE");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesPrice)
                    .HasColumnType("money")
                    .HasColumnName("SALES_PRICE");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Authorid)
                    .HasConstraintName("FK__BOOKS__AUTHORID__29572725");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Genreid)
                    .HasConstraintName("FK__BOOKS__GENREID__2A4B4B5E");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Publisherid)
                    .HasConstraintName("FK__BOOKS__PUBLISHER__2B3F6F97");
            });

            modelBuilder.Entity<Booksale>(entity =>
            {
                entity.ToTable("BOOKSALES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");

                entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");

                entity.Property(e => e.SalesDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SALES_DATE");

                entity.Property(e => e.SalesPrice)
                    .HasColumnType("money")
                    .HasColumnName("SALES_PRICE");

                entity.Property(e => e.Salesmanid).HasColumnName("SALESMANID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Booksales)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__BOOKSALES__BOOKI__4D94879B");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Booksales)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__BOOKSALES__CUSTO__4E88ABD4");

                entity.HasOne(d => d.Salesman)
                    .WithMany(p => p.Booksales)
                    .HasForeignKey(d => d.Salesmanid)
                    .HasConstraintName("FK__BOOKSALES__SALES__4F7CD00D");
            });

            modelBuilder.Entity<Booksinstock>(entity =>
            {
                entity.ToTable("BOOKSINSTOCK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");

                entity.Property(e => e.Stockid).HasColumnName("STOCKID");

                entity.Property(e => e.Stockpercent).HasColumnName("STOCKPERCENT");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Booksinstocks)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__BOOKSINST__BOOKI__59063A47");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Booksinstocks)
                    .HasForeignKey(d => d.Stockid)
                    .HasConstraintName("FK__BOOKSINST__STOCK__5812160E");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("GENRES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("PUBLISHERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Reservedbook>(entity =>
            {
                entity.ToTable("RESERVEDBOOKS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");

                entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reservedbooks)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__RESERVEDB__BOOKI__52593CB8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservedbooks)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__RESERVEDB__CUSTO__534D60F1");
            });

            modelBuilder.Entity<Salesman>(entity =>
            {
                entity.ToTable("SALESMAN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("STOCKS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
