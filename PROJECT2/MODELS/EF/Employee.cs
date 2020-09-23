namespace MODELS.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Birthday { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Position { get; set; }

        [StringLength(100)]
        public string Node { get; set; }
    }
}
