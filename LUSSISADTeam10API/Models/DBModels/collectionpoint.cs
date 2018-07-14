namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("collectionpoint")]
    public partial class collectionpoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public collectionpoint()
        {
            departmentcollectionpoints = new HashSet<departmentcollectionpoint>();
            lockercollectionpoints = new HashSet<lockercollectionpoint>();
            requisitions = new HashSet<requisition>();
        }

        [Key]
        public int cpid { get; set; }

        [StringLength(50)]
        public string cpname { get; set; }

        [StringLength(50)]
        public string cplocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departmentcollectionpoint> departmentcollectionpoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lockercollectionpoint> lockercollectionpoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requisition> requisitions { get; set; }
    }
}
