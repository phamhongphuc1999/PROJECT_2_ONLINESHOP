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
        public int Id { get; set; }

        [StringLength(200)]
        public string NameProduct { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int Amount { get; set; }

        public int ImportPrice { get; set; }

        public int ExportPrice { get; set; }

        public int Profix { get; set; }

        public int Guarantee { get; set; }

        public int Sale { get; set; }

        [StringLength(30)]
        public string Status { get; set; }
    }
}
