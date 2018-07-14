namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adjustment")]
    public partial class adjustment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public adjustment()
        {
            adjustmentdetails = new HashSet<adjustmentdetail>();
        }

        [Key]
        public int adjid { get; set; }

        public int? raisedby { get; set; }

        public int? raisedto { get; set; }

        public int status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? issueddate { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adjustmentdetail> adjustmentdetails { get; set; }
    }
}
