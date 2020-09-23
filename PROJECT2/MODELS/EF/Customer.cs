namespace MODELS.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Node { get; set; }

        public bool? Status { get; set; }
    }
}
