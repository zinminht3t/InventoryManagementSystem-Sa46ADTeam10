namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adjustmentdetail")]
    public partial class adjustmentdetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int adjid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int itemid { get; set; }

        public int? adjustedqty { get; set; }

        [MaxLength(255)]
        public byte[] reason { get; set; }

        public virtual adjustment adjustment { get; set; }

        public virtual item item { get; set; }
    }
}
