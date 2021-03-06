namespace MODELS.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Statistic")]
    public partial class Statistic
    {
        [StringLength(200)]
        public string NameProduct { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Amount { get; set; }
    }
}
