using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CORE_DB.Models
{
    public partial class COREContext : DbContext
    {
        public COREContext()
        {
        }

        public COREContext(DbContextOptions<COREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItEmpDetail> ItEmpDetails { get; set; } = null!;

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
       //    if (!optionsBuilder.IsConfigured)
       //   {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=ELW5207\\SQLEXPRESS;Database=CORE;Trusted_Connection=True;");
            //}
         //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItEmpDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__IT_Emp_D__781228D9A6B2C168");

                entity.ToTable("IT_Emp_Details");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_id");

                entity.Property(e => e.Doj)
                    .HasColumnType("datetime")
                    .HasColumnName("DOJ");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeeSal).HasColumnName("Employee_Sal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
