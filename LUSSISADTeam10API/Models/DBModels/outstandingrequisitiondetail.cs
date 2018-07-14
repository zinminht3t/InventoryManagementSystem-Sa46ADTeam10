namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("outstandingrequisitiondetail")]
    public partial class outstandingrequisitiondetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int outreqid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reqid { get; set; }

        public int qty { get; set; }

        public virtual outstandingrequisition outstandingrequisition { get; set; }

        public virtual requisition requisition { get; set; }
    }
}
