using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Resturant_Faves_Api_Lab.Models;

public partial class RestaurantFavesAppDbContext : DbContext
{
    public RestaurantFavesAppDbContext()
    {
    }

    public RestaurantFavesAppDbContext(DbContextOptions<RestaurantFavesAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=RestaurantFavesAppDb; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F06C058AF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.OrderAgain).HasColumnName("orderAgain");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Restaurant)
                .HasMaxLength(255)
                .HasColumnName("restaurant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
