using System;
using System.Collections.Generic;
using Chempionat23Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Chempionat23Api.Context;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accauntant> Accauntants { get; set; }

    public virtual DbSet<Compani> Companis { get; set; }

    public virtual DbSet<Divice> Divices { get; set; }

    public virtual DbSet<Histori> Historis { get; set; }

    public virtual DbSet<Laborant> Laborants { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicesaccaun> Servicesaccauns { get; set; }

    public virtual DbSet<Serviceslab> Serviceslabs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host = 89.110.53.87; Password = 492492; Database = postgres; Username = postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Accauntant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accauntant_pkey");

            entity.ToTable("accauntant", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Servicesaccauntid).HasColumnName("servicesaccauntid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Servicesaccaunt).WithMany(p => p.Accauntants)
                .HasForeignKey(d => d.Servicesaccauntid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accauntant_servicesaccauntid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Accauntants)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accauntant_userid_fkey");
        });

        modelBuilder.Entity<Compani>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compani_pkey");

            entity.ToTable("compani", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .HasColumnName("adres");
            entity.Property(e => e.Bick).HasColumnName("bick");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Namecompani)
                .HasMaxLength(100)
                .HasColumnName("namecompani");
            entity.Property(e => e.Pc).HasColumnName("pc");
        });

        modelBuilder.Entity<Divice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("divices_pkey");

            entity.ToTable("divices", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Namedivices)
                .HasMaxLength(100)
                .HasColumnName("namedivices");
        });

        modelBuilder.Entity<Histori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("histori_pkey");

            entity.ToTable("histori", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connectuser).HasColumnName("connectuser");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Datahistori)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datahistori");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Historis)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("histori_userid_fkey");
        });

        modelBuilder.Entity<Laborant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("laborant_pkey");

            entity.ToTable("laborant", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Serviceslabid).HasColumnName("serviceslabid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Serviceslab).WithMany(p => p.Laborants)
                .HasForeignKey(d => d.Serviceslabid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("laborant_serviceslabid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Laborants)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("laborant_userid_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datacreate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datacreate");
            entity.Property(e => e.Datadivicestart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadivicestart");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Scoreid).HasColumnName("scoreid");
            entity.Property(e => e.Servicesid).HasColumnName("servicesid");
            entity.Property(e => e.Statusorder)
                .HasDefaultValue(false)
                .HasColumnName("statusorder");
            entity.Property(e => e.Statusservice)
                .HasDefaultValue(false)
                .HasColumnName("statusservice");
            entity.Property(e => e.Timecompletion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timecompletion");
            entity.Property(e => e.Timeworckdivise).HasColumnName("timeworckdivise");
            entity.Property(e => e.Worcer).HasColumnName("worcer");

            entity.HasOne(d => d.Device).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Deviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_deviceid_fkey");

            entity.HasOne(d => d.Score).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Scoreid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_scoreid_fkey");

            entity.HasOne(d => d.Services).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Servicesid)
                .HasConstraintName("orders_servicesid_fkey");

            entity.HasOne(d => d.WorcerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Worcer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_worcer_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Namerole)
                .HasMaxLength(100)
                .HasColumnName("namerole");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("score_pkey");

            entity.ToTable("score", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accauntentid).HasColumnName("accauntentid");
            entity.Property(e => e.Companiid).HasColumnName("companiid");
            entity.Property(e => e.Costscore)
                .HasPrecision(10, 2)
                .HasColumnName("costscore");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");

            entity.HasOne(d => d.Accauntent).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Accauntentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("score_accauntentid_fkey");

            entity.HasOne(d => d.Compani).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Companiid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("score_companiid_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Averagedeviation).HasColumnName("averagedeviation");
            entity.Property(e => e.Costsevices)
                .HasPrecision(10, 2)
                .HasColumnName("costsevices");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Nameservices)
                .HasMaxLength(100)
                .HasColumnName("nameservices");
            entity.Property(e => e.Periodexecut).HasColumnName("periodexecut");
        });

        modelBuilder.Entity<Servicesaccaun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicesaccaun_pkey");

            entity.ToTable("servicesaccaun", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Nameservices)
                .HasMaxLength(100)
                .HasColumnName("nameservices");
        });

        modelBuilder.Entity<Serviceslab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("serviceslab_pkey");

            entity.ToTable("serviceslab", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Nameservices)
                .HasMaxLength(100)
                .HasColumnName("nameservices");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "Chempionat23");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthday");
            entity.Property(e => e.Companiid).HasColumnName("companiid");
            entity.Property(e => e.Datadrop)
                .HasDefaultValueSql("'9999-01-01 00:00:00'::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datadrop");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("fio");
            entity.Property(e => e.Ip)
                .HasMaxLength(100)
                .HasColumnName("ip");
            entity.Property(e => e.Lastenter)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastenter");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Npasport).HasColumnName("npasport");
            entity.Property(e => e.Passworduser)
                .HasMaxLength(100)
                .HasColumnName("passworduser");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.Roleuser).HasColumnName("roleuser");
            entity.Property(e => e.Spasport).HasColumnName("spasport");

            entity.HasOne(d => d.Compani).WithMany(p => p.Users)
                .HasForeignKey(d => d.Companiid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_companiid_fkey");

            entity.HasOne(d => d.RoleuserNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleuser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roleuser_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
