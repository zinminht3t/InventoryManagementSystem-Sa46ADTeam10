namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("purchaseorder")]
    public partial class purchaseorder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchaseorder()
        {
            purchaseorderdetails = new HashSet<purchaseorderdetail>();
        }

        [Key]
        public int poid { get; set; }

        public int purchasedby { get; set; }

        public int supid { get; set; }

        [Column(TypeName = "date")]
        public DateTime? podate { get; set; }

        public int status { get; set; }

        public virtual supplier supplier { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchaseorderdetail> purchaseorderdetails { get; set; }
    }
}
