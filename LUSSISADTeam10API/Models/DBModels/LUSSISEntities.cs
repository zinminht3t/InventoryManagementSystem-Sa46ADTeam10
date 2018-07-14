namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LUSSISEntities : DbContext
    {
        public LUSSISEntities()
            : base("name=LUSSISEntities")
        {
        }

        public virtual DbSet<adjustment> adjustments { get; set; }
        public virtual DbSet<adjustmentdetail> adjustmentdetails { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<collectionpoint> collectionpoints { get; set; }
        public virtual DbSet<delegation> delegations { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<departmentcollectionpoint> departmentcollectionpoints { get; set; }
        public virtual DbSet<disbursement> disbursements { get; set; }
        public virtual DbSet<disbursementdetail> disbursementdetails { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<lockercollectionpoint> lockercollectionpoints { get; set; }
        public virtual DbSet<outstandingrequisition> outstandingrequisitions { get; set; }
        public virtual DbSet<outstandingrequisitiondetail> outstandingrequisitiondetails { get; set; }
        public virtual DbSet<purchaseorder> purchaseorders { get; set; }
        public virtual DbSet<purchaseorderdetail> purchaseorderdetails { get; set; }
        public virtual DbSet<requisition> requisitions { get; set; }
        public virtual DbSet<requisitiondetail> requisitiondetails { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<supplieritem> supplieritems { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adjustment>()
                .HasMany(e => e.adjustmentdetails)
                .WithRequired(e => e.adjustment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.shelflocation)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.shelflevel)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.items)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<collectionpoint>()
                .Property(e => e.cpname)
                .IsUnicode(false);

            modelBuilder.Entity<collectionpoint>()
                .Property(e => e.cplocation)
                .IsUnicode(false);

            modelBuilder.Entity<collectionpoint>()
                .HasMany(e => e.departmentcollectionpoints)
                .WithRequired(e => e.collectionpoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<collectionpoint>()
                .HasMany(e => e.lockercollectionpoints)
                .WithRequired(e => e.collectionpoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<collectionpoint>()
                .HasMany(e => e.requisitions)
                .WithRequired(e => e.collectionpoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<department>()
                .Property(e => e.deptname)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.deptcontactname)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.deptemail)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.departmentcollectionpoints)
                .WithRequired(e => e.department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.requisitions)
                .WithRequired(e => e.department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.users)
                .WithRequired(e => e.department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<disbursement>()
                .HasMany(e => e.disbursementdetails)
                .WithRequired(e => e.disbursement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.uom)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.adjustmentdetails)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.disbursementdetails)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.inventories)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.purchaseorderdetails)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.requisitiondetails)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.supplieritems)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lockercollectionpoint>()
                .Property(e => e.lockername)
                .IsUnicode(false);

            modelBuilder.Entity<lockercollectionpoint>()
                .Property(e => e.lockersize)
                .IsUnicode(false);

            modelBuilder.Entity<outstandingrequisition>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<outstandingrequisition>()
                .HasMany(e => e.outstandingrequisitiondetails)
                .WithRequired(e => e.outstandingrequisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<purchaseorder>()
                .HasMany(e => e.purchaseorderdetails)
                .WithRequired(e => e.purchaseorder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<requisition>()
                .HasOptional(e => e.disbursement)
                .WithRequired(e => e.requisition);

            modelBuilder.Entity<requisition>()
                .HasMany(e => e.outstandingrequisitiondetails)
                .WithRequired(e => e.requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<requisition>()
                .HasMany(e => e.requisitiondetails)
                .WithRequired(e => e.requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.supname)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.supemail)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.contactname)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.gstregno)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.purchaseorders)
                .WithRequired(e => e.supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.supplieritems)
                .WithRequired(e => e.supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.adjustments)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.raisedby);

            modelBuilder.Entity<user>()
                .HasMany(e => e.adjustments1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.raisedto);

            modelBuilder.Entity<user>()
                .HasMany(e => e.delegations)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.userid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.delegations1)
                .WithRequired(e => e.user1)
                .HasForeignKey(e => e.assignedby)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.disbursements)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ackby)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.purchaseorders)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.purchasedby)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.requisitions)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.raisedby)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.requisitions1)
                .WithRequired(e => e.user1)
                .HasForeignKey(e => e.approvedby)
                .WillCascadeOnDelete(false);
        }
    }
}
