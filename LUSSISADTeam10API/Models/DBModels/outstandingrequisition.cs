namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("outstandingrequisition")]
    public partial class outstandingrequisition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public outstandingrequisition()
        {
            outstandingrequisitiondetails = new HashSet<outstandingrequisitiondetail>();
        }

        [Key]
        public int outreqid { get; set; }

        public int itemid { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<outstandingrequisitiondetail> outstandingrequisitiondetails { get; set; }
    }
}
