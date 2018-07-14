namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("disbursement")]
    public partial class disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public disbursement()
        {
            disbursementdetails = new HashSet<disbursementdetail>();
        }

        [Key]
        public int disid { get; set; }

        public int reqid { get; set; }

        public int ackby { get; set; }

        public virtual requisition requisition { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<disbursementdetail> disbursementdetails { get; set; }
    }
}
