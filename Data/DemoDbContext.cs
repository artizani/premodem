using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<LoanDetails> LoanDetails { get; set; }
        public virtual DbSet<Loans> Loans { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PremodemCustomerStore> PremodemCustomerStore { get; set; }
        public virtual DbSet<PremodemDeliveryrate> PremodemDeliveryrate { get; set; }
        public virtual DbSet<PremodemEnergy> PremodemEnergy { get; set; }
        public virtual DbSet<PremodemExpense> PremodemExpense { get; set; }
        public virtual DbSet<PremodemExpenseCategory> PremodemExpenseCategory { get; set; }
        public virtual DbSet<PremodemExpenseItem> PremodemExpenseItem { get; set; }
        public virtual DbSet<PremodemGenerator> PremodemGenerator { get; set; }
        public virtual DbSet<PremodemInvoiceDelivery> PremodemInvoiceDelivery { get; set; }
        public virtual DbSet<PremodemOrg> PremodemOrg { get; set; }
        public virtual DbSet<PremodemParts> PremodemParts { get; set; }
        public virtual DbSet<PremodemPeople> PremodemPeople { get; set; }
        public virtual DbSet<ProfileInfoes> ProfileInfoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.ProfileInfoId)
                    .HasName("IX_ProfileInfo_Id");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ProfileInfoId).HasColumnName("ProfileInfo_Id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.ProfileInfo)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.ProfileInfoId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.ProfileInfoes_ProfileInfo_Id");
            });

            modelBuilder.Entity<Assets>(entity =>
            {
                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<LoanDetails>(entity =>
            {
                entity.HasIndex(e => e.AssetId)
                    .HasName("IX_Asset_Id");

                entity.HasIndex(e => e.LoanId)
                    .HasName("IX_LoanId");

                entity.Property(e => e.AssetId).HasColumnName("Asset_Id");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_dbo.LoanDetails_dbo.Assets_Asset_Id");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LoanDetails_dbo.Loans_LoanId");
            });

            modelBuilder.Entity<Loans>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Loans)
                    .HasForeignKey<Loans>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Loans_dbo.ProfileInfoes_Id");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PremodemCustomerStore>(entity =>
            {
                entity.ToTable("premodem.customer.store");

                entity.HasIndex(e => e.StoreCode)
                    .HasName("premodem.customer.store_storeCode_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StoreCode).HasColumnName("storeCode");

                entity.Property(e => e.StoreName)
                    .HasColumnName("storeName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PremodemDeliveryrate>(entity =>
            {
                entity.ToTable("premodem.deliveryrate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.PremodemDeliveryrate)
                    .HasForeignKey(d => d.Supplier)
                    .HasConstraintName("Fk_premodem.deliveryrate_premodem.org");
            });

            modelBuilder.Entity<PremodemEnergy>(entity =>
            {
                entity.ToTable("premodem.energy");

                entity.HasIndex(e => e.Id)
                    .HasName("premodem.energy_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExpenseId).HasColumnName("expenseId");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.PremodemEnergy)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("Fk_premodem.energy_premodem.expense");
            });

            modelBuilder.Entity<PremodemExpense>(entity =>
            {
                entity.ToTable("premodem.expense");

                entity.HasIndex(e => e.Amount)
                    .HasName("Unq_premodem.expense_amount")
                    .IsUnique();

                entity.HasIndex(e => e.Item)
                    .HasName("Unq_premodem.expense_item")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Labour)
                    .HasColumnName("labour")
                    .HasColumnType("money");

                entity.Property(e => e.Paidfrom)
                    .HasColumnName("paidfrom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Personnel).HasColumnName("personnel");

                entity.Property(e => e.SettledDate).HasColumnName("settledDate");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.PremodemExpense)
                    .HasForeignKey<PremodemExpense>(d => d.Item)
                    .HasConstraintName("Fk_premodem.expense_premodem.expense.category");

                entity.HasOne(d => d.PersonnelNavigation)
                    .WithMany(p => p.PremodemExpense)
                    .HasForeignKey(d => d.Personnel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_premodem.expense_premodem.people");
            });

            modelBuilder.Entity<PremodemExpenseCategory>(entity =>
            {
                entity.ToTable("premodem.expense.category");

                entity.HasIndex(e => e.Id)
                    .HasName("premodem.expense.category_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EnergyId).HasColumnName("energyId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PartId).HasColumnName("partId");
            });

            modelBuilder.Entity<PremodemExpenseItem>(entity =>
            {
                entity.ToTable("premodem.expense.item");

                entity.HasIndex(e => e.Id)
                    .HasName("premodem.expense.item_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PremodemGenerator>(entity =>
            {
                entity.ToTable("premodem.generator");

                entity.HasIndex(e => e.Id)
                    .HasName("premodem.generator_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channel)
                    .HasColumnName("channel")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Counter)
                    .HasColumnName("counter")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Slacktime)
                    .HasColumnName("slacktime")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.PremodemGenerator)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("Fk_premodem.generator_premodem.people");
            });

            modelBuilder.Entity<PremodemInvoiceDelivery>(entity =>
            {
                entity.ToTable("premodem.invoice.delivery");

                entity.HasIndex(e => e.Storecode)
                    .HasName("Unq_premodem.invoice.delivery_storecode")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Grn).HasColumnName("grn");

                entity.Property(e => e.Invdate)
                    .HasColumnName("invdate")
                    .HasColumnType("date");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Storecode).HasColumnName("storecode");

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.PremodemInvoiceDelivery)
                    .HasForeignKey(d => d.Supplier)
                    .HasConstraintName("Fk_premodem.invoice.delivery_premodem.org");
            });

            modelBuilder.Entity<PremodemOrg>(entity =>
            {
                entity.ToTable("premodem.org");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accountnumber).HasColumnName("accountnumber");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Bank)
                    .HasColumnName("bank")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Orgname)
                    .HasColumnName("orgname")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PremodemParts>(entity =>
            {
                entity.ToTable("premodem.parts");

                entity.HasIndex(e => e.Id)
                    .HasName("premodem.parts_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Expenseid).HasColumnName("expenseid");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.PremodemParts)
                    .HasForeignKey(d => d.Expenseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_premodem.parts_premodem.expense");
            });

            modelBuilder.Entity<PremodemPeople>(entity =>
            {
                entity.ToTable("premodem.people");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Account).HasColumnName("account");

                entity.Property(e => e.Bank)
                    .HasColumnName("bank")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MobileFour).HasColumnName("mobile_four");

                entity.Property(e => e.MobileOne).HasColumnName("mobile_one");

                entity.Property(e => e.MobileThree).HasColumnName("mobile_three");

                entity.Property(e => e.MobileTwo).HasColumnName("mobile_two");

                entity.Property(e => e.OrgId).HasColumnName("orgId");

                entity.Property(e => e.Roles).HasColumnName("roles");
            });

            modelBuilder.Entity<ProfileInfoes>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            });
        }
    }
}
