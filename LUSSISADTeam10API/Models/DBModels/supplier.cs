namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("supplier")]
    public partial class supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier()
        {
            purchaseorders = new HashSet<purchaseorder>();
            supplieritems = new HashSet<supplieritem>();
        }

        [Key]
        public int supid { get; set; }

        [Required]
        [StringLength(100)]
        public string supname { get; set; }

        [StringLength(50)]
        public string supemail { get; set; }

        public int? supphone { get; set; }

        [StringLength(50)]
        public string contactname { get; set; }

        [StringLength(50)]
        public string gstregno { get; set; }

        public int active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchaseorder> purchaseorders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supplieritem> supplieritems { get; set; }
    }
}
