namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("delegation")]
    public partial class delegation
    {
        [Key]
        public int delid { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? enddate { get; set; }

        public int userid { get; set; }

        public int active { get; set; }

        public int assignedby { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
