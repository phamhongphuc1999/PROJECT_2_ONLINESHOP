namespace MODELS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detail")]
    public partial class Detail
    {
        public int Id { get; set; }

        public int IdInvoice { get; set; }

        public int Amount { get; set; }

        [StringLength(250)]
        public string IdProduct { get; set; }

        [StringLength(250)]
        public string NameProduct { get; set; }

        [StringLength(250)]
        public string IdPackage { get; set; }

        public int? ImportPrice { get; set; }

        public int? ExportPrice { get; set; }

        public int? Money { get; set; }

        public DateTime? DaySell { get; set; }
    }
}
