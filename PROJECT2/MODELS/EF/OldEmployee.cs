namespace MODELS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OldEmployee")]
    public partial class OldEmployee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Position { get; set; }

        public DateTime? DayOff { get; set; }

        [StringLength(100)]
        public string Node { get; set; }
    }
}
