namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lockercollectionpoint")]
    public partial class lockercollectionpoint
    {
        [Key]
        public int lockerid { get; set; }

        [StringLength(10)]
        public string lockername { get; set; }

        [StringLength(50)]
        public string lockersize { get; set; }

        public int cpid { get; set; }

        public int status { get; set; }

        public virtual collectionpoint collectionpoint { get; set; }
    }
}
