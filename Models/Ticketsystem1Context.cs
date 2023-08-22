using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webtest.Models;

public partial class Ticketsystem1Context : DbContext
{
    public Ticketsystem1Context()
    {
    }

    public Ticketsystem1Context(DbContextOptions<Ticketsystem1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<MessageStatus> MessageStatuses { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    public virtual DbSet<Queue> Queues { get; set; }

    public virtual DbSet<QueueLabel> QueueLabels { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleDetail> RoleDetails { get; set; }

    public virtual DbSet<Thread> Threads { get; set; }

    public virtual DbSet<ThreadMessage> ThreadMessages { get; set; }

    public virtual DbSet<ThreadStatus> ThreadStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9D93I3G;database=TICKETSYSTEM1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC0784D648DB");

            entity.ToTable("AuditLog");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Details).IsUnicode(false);
            entity.Property(e => e.EndResults).IsUnicode(false);
            entity.Property(e => e.Overwritten).IsUnicode(false);
            entity.Property(e => e.PrimaryKey)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Summary)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MessageStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MessageS__3214EC07A01A8A99");

            entity.ToTable("MessageStatus");

            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07B22059B9");

            entity.ToTable("PermissionType");

            entity.Property(e => e.Permission)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Queue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Queues__3214EC07A1F04CDD");

            entity.Property(e => e.QueueName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<QueueLabel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QueueLab__3214EC07252269F4");

            entity.Property(e => e.LabelName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Queue).WithMany(p => p.QueueLabels)
                .HasForeignKey(d => d.QueueId)
                .HasConstraintName("FK_ThreadLabels_QueueId_Queues");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07323EE5F7");

            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleDeta__3214EC07FDCB975D");

            entity.ToTable("RoleDetail");

            entity.HasOne(d => d.PermissionTypeNavigation).WithMany(p => p.RoleDetails).HasForeignKey(d => d.PermissionType);

            entity.HasOne(d => d.QueuePermissionNavigation).WithMany(p => p.RoleDetails)
                .HasForeignKey(d => d.QueuePermission)
                .HasConstraintName("FK_RoleDetail_Queues_Queues");

            entity.HasOne(d => d.Roles).WithMany(p => p.RoleDetails)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK_RoleDetail_RolesId_Roles");
        });

        modelBuilder.Entity<Thread>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Threads__3214EC074AC75E73");

            entity.Property(e => e.DateOfCreation).HasColumnType("datetime");
            entity.Property(e => e.Resolution).IsUnicode(false);
            entity.Property(e => e.SoftDeleteDate).HasColumnType("datetime");
            entity.Property(e => e.SoftDeleteReason).IsUnicode(false);
            entity.Property(e => e.Summary).IsUnicode(false);

            entity.HasOne(d => d.AssigneeNavigation).WithMany(p => p.ThreadAssigneeNavigations).HasForeignKey(d => d.Assignee);

            entity.HasOne(d => d.Queue).WithMany(p => p.Threads).HasForeignKey(d => d.QueueId);

            entity.HasOne(d => d.ThreadStatusNavigation).WithMany(p => p.Threads).HasForeignKey(d => d.ThreadStatus);

            entity.HasOne(d => d.User).WithMany(p => p.ThreadUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Threads_Roles_Users");
        });

        modelBuilder.Entity<ThreadMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThreadMe__3214EC0780318AF0");

            entity.Property(e => e.DateOfCreation).HasColumnType("datetime");
            entity.Property(e => e.SoftDeleteDate).HasColumnType("datetime");
            entity.Property(e => e.SoftDeleteReason).IsUnicode(false);

            entity.HasOne(d => d.MessageStatusNavigation).WithMany(p => p.ThreadMessages).HasForeignKey(d => d.MessageStatus);

            entity.HasOne(d => d.Thread).WithMany(p => p.ThreadMessages)
                .HasForeignKey(d => d.ThreadId)
                .HasConstraintName("FK_ThreadMessages_ThreadId_Threads");

            entity.HasOne(d => d.User).WithMany(p => p.ThreadMessages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ThreadMessages_UserId_Threads");
        });

        modelBuilder.Entity<ThreadStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThreadSt__3214EC070AE2B4E7");

            entity.ToTable("ThreadStatus");

            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0782C79EBB");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pm).HasColumnName("PM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
