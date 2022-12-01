using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public partial class SmartEmploymentContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
	 IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		public SmartEmploymentContext(DbContextOptions<SmartEmploymentContext> dbContextOptions)
	   : base(dbContextOptions)
		{
			this.Database.EnsureCreated();
		}

		public SmartEmploymentContext()
		{
			// this.Database.EnsureDeleted(); 
			this.Database.EnsureCreated();
		}

		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Person> People { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<Company> Companies { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<UserRole> UserRoles { get; set; }
		public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }
		public virtual DbSet<Photo> Photos { get; set; }
		public virtual DbSet<Relationship> Relationships { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer("Server=DESKTOP-C76N1G2;Database=SmartEmployment;Trusted_Connection=True;MultipleActiveResultSets=true;");
			}
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

			modelBuilder.Entity<Employee>(entity =>
			{
				entity.ToTable("Employee");

				entity.Property(e => e.EmployeeCode)
					.IsRequired()
					.HasMaxLength(255)
					.HasDefaultValueSql("('1')");

				entity.Property(e => e.StartDate).HasColumnType("datetime")
					.HasDefaultValueSql("('01/01/2000')"); 

				entity.Property(e => e.LastReinstatementDate).HasColumnType("datetime");

				entity.Property(e => e.TerminationDate).HasColumnType("datetime");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();

				entity.HasOne(d => d.Person)
					.WithMany(p => p.Employees)
					.HasForeignKey(d => d.PersonId)
					.HasConstraintName("FK_Employee_Person");

				entity.HasOne(d => d.Company)
					.WithMany(p => p.Employees)
					.HasForeignKey(d => d.CompanyId)
					.HasConstraintName("FK_Employee_Company");
			});

			modelBuilder.Entity<Person>(entity =>
			{
				entity.ToTable("Person");

				entity.Property(e => e.BirthDate).HasColumnType("date");

				entity.Property(e => e.Email).HasMaxLength(255);

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.MiddleName).HasMaxLength(255);

				entity.Property(e => e.PreferredName).HasMaxLength(255);

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<Role>(entity =>
			{
				entity.ToTable("Role");

				/*
				entity.Property(e => e.Name)
					.HasMaxLength(255)
					.IsRequired()
					.IsFixedLength(true);
				*/

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<Company>(entity =>
			{
				entity.ToTable("Company");

				entity.Property(e => e.FinishedDate).HasColumnType("datetime");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.CompanyCode)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.StartDate).HasColumnType("datetime");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<CompanyAddress>(entity =>
			{
				entity.ToTable("CompanyAddress");

				entity.HasOne(d => d.Company)
					.WithMany(p => p.CompanyAddresses)
					.HasConstraintName("FK_CompanyAddress_Company");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<User>(entity =>
			{
				// entity.Property(e => e.Id).ValueGeneratedOnAdd();
				entity.ToTable("User");

				entity.Property(e => e.CurrentMfaDeviceToken).HasMaxLength(255);

				entity.Property(e => e.FinishedDate).HasColumnType("date");

				entity.Property(e => e.IsTemporaryPassword).HasColumnName("isTemporaryPassword");

				entity.Property(e => e.LastDeviceCodeUsed).HasMaxLength(255);

				entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

				entity.Property(e => e.PasswordAnswer).HasMaxLength(255);

				entity.Property(e => e.PasswordModificationDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("('1/1/2000')");

				entity.Property(e => e.PasswordQuestion).HasMaxLength(255);

				entity.Property(e => e.StartDate).HasColumnType("date");

				entity.Property(e => e.Token).HasMaxLength(255);

				/*
				entity.Property(e => e.UserName)
					.IsRequired()
					.HasMaxLength(255);
				*/

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();

				entity.HasOne(d => d.Employee)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.EmployeeId)
					.HasConstraintName("FK_Users_Employee")
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(d => d.Person)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.PersonId)
					.HasConstraintName("FK_Users_Person");

				entity.HasOne(d => d.Company)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.CompanyId)
					.HasConstraintName("FK_Users_Company");
			});

			modelBuilder.Entity<UserRole>(entity =>
			{
				entity.ToTable("UserRole");

				// entity.Property(e => e.Id).ValueGeneratedNever();
				// entity.HasKey(e => e.Id); 

				entity.Property(e => e.Version)
					.IsRowVersion()
					.IsConcurrencyToken();

				entity.Ignore(e => e.Id); 

				/*
				entity.HasOne(d => d.Role)
					.WithMany(p => p.UserRoles)
					.HasForeignKey(d => d.RoleId)
					.HasConstraintName("FK_UserRole_Role");

				entity.HasOne(d => d.User)
					.WithMany(p => p.UserRoles)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK_UserRole_Users");
				*/
			});

			modelBuilder.Entity<Timesheet>(entity =>
			{
				entity.ToTable("Timesheet");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<EmployeeTimesheetValue>(entity =>
			{
				entity.ToTable("EmployeeTimesheetValue");

				entity.Property(e => e.StartTime).HasColumnType("datetime");

				entity.Property(e => e.EndTime).HasColumnType("datetime");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();

				entity.HasOne(d => d.Timesheet)
					.WithMany(p => p.EmployeeTimesheetValues)
					.HasConstraintName("FK_EmployeeTimesheetValue_Timesheet");

				entity.HasOne(d => d.Employee)
					.WithMany(p => p.EmployeeTimesheetValues)
					.HasConstraintName("FK_EmployeeTimesheetValue_Employee");
			});

			modelBuilder.Entity<Relationship>(entity =>
			{
				entity.ToTable("Relationship");

				entity.Property(e => e.StartDate).HasColumnType("datetime");

				entity.Property(e => e.FinishedDate).HasColumnType("datetime");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();
			});

			modelBuilder.Entity<Schedule>(entity =>
			{
				entity.ToTable("Schedule");

				entity.Property(e => e.Comments)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Date).HasColumnType("date");

				entity.Property(e => e.Hours).HasColumnType("decimal(28, 8)");

				entity.Property(e => e.Version)
					.IsRequired()
					.IsRowVersion()
					.IsConcurrencyToken();

				entity.HasOne(d => d.Employee)
					.WithMany(p => p.Schedules)
					.HasForeignKey(d => d.EmployeeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Schedule_Employee");
			});

			OnModelCreatingPartial(modelBuilder);
		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
