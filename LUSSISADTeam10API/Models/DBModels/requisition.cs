namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("requisition")]
    public partial class requisition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public requisition()
        {
            outstandingrequisitiondetails = new HashSet<outstandingrequisitiondetail>();
            requisitiondetails = new HashSet<requisitiondetail>();
        }

        [Key]
        public int reqid { get; set; }

        public int raisedby { get; set; }

        public int approvedby { get; set; }

        public int deptid { get; set; }

        public int cpid { get; set; }

        public int status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reqdate { get; set; }

        public virtual collectionpoint collectionpoint { get; set; }

        public virtual department department { get; set; }

        public virtual disbursement disbursement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<outstandingrequisitiondetail> outstandingrequisitiondetails { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requisitiondetail> requisitiondetails { get; set; }
    }
}
