namespace MODELS.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OldEmployee")]
    public partial class OldEmployee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Birthday { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Position { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DayOff { get; set; }

        [StringLength(100)]
        public string Node { get; set; }
    }
}
