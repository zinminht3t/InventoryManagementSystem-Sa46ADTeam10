namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventory")]
    public partial class inventory
    {
        [Key]
        public int invid { get; set; }

        public int itemid { get; set; }

        public int? stock { get; set; }

        public int? reorderlevel { get; set; }

        public int? reorderqty { get; set; }

        public virtual item item { get; set; }
    }
}
