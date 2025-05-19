using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _19._05._25ContolW.Models;

public partial class CwdbContext : DbContext
{
    public CwdbContext()
    {
    }

    public CwdbContext(DbContextOptions<CwdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<StatusRequest> StatusRequests { get; set; }

    public virtual DbSet<TypeRequest> TypeRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=CWdb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Article);

            entity.ToTable("Request");

            entity.HasIndex(e => e.Article, "IX_Request_Article").IsUnique();

            entity.HasOne(d => d.StatusReqNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusReq)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TypeReqNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.TypeReq)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UserReqNavigation).WithMany(p => p.Requests).HasForeignKey(d => d.UserReq);
        });

        modelBuilder.Entity<StatusRequest>(entity =>
        {
            entity.HasKey(e => e.Status);

            entity.ToTable("StatusRequest");
        });

        modelBuilder.Entity<TypeRequest>(entity =>
        {
            entity.HasKey(e => e.Type);

            entity.ToTable("TypeRequest");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login);

            entity.ToTable("User");

            entity.Property(e => e.Fio).HasColumnName("FIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
