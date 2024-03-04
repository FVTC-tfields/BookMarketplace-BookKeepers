using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL;

public partial class BookKeepersEntities : DbContext
{
    public BookKeepersEntities()
    {
    }

    public BookKeepersEntities(DbContextOptions<BookKeepersEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblCustomer> tblCustomers { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    public virtual DbSet<tblAuthor> tblAuthors { get; set; }

    public virtual DbSet<tblBook> tblBooks { get; set; }

    public virtual DbSet<tblComment> tblComments { get; set; }

    public virtual DbSet<tblCondition> tblConditions { get; set; }

    public virtual DbSet<tblOrder> tblOrders { get; set; }

    public virtual DbSet<tblOrderItem> tblOrderItems { get; set; }

    public virtual DbSet<tblPost> tblPosts { get; set; }

    public virtual DbSet<tblPublisher> tblPublishers { get; set; }

    public virtual DbSet<tblShoppingCart> tblShoppingCarts { get; set; }

    public virtual DbSet<tblSubject> tblSubjects { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=bookmarketplace.database.windows.net;Initial Catalog=bookmarketplace;User ID=bookmarket;Password=!Testing*1;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<tblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblCusto_3214EC0765FF02F8");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ZIP)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblUser_3214EC07842B73ED");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(28)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblAuthor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblAutho_3214EC072FFEDCBD");

            entity.ToTable("tblAuthor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblUser_3214EC0789CA8A54");

            entity.ToTable("tblBook");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ISBN)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblCondi_3214EC071D9E4499");

            entity.ToTable("tblCondition");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblComme_3214EC07CB5DDAB4");

            entity.ToTable("tblComment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblOrder_3214EC07300C83EF");

            entity.ToTable("tblOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShipDate)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblOrder_3214EC079EB95C6F");

            entity.ToTable("tblOrderItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblPost_3214EC07C0AE4863");

            entity.ToTable("tblPost");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblPublisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblPubl_3214EC074F249E35");

            entity.ToTable("tblPublisher");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblShopp_3214EC07AABE9548");

            entity.ToTable("tblShoppingCart");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblSubje_3214EC07A7E49C12");

            entity.ToTable("tblSubject");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
