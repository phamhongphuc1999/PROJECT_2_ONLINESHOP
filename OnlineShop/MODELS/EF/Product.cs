namespace MODELS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string IdPackage { get; set; }

        [StringLength(200)]
        public string NameProduct { get; set; }

        public int ImportPrice { get; set; }

        public int Profix { get; set; }

        public int Guarantee { get; set; }

        public int Amount { get; set; }

        public int Sale { get; set; }
    }
}
