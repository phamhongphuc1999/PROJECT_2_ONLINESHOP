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

        public int? IdProduct { get; set; }

        public int Amount { get; set; }

        public int? Money { get; set; }
    }
}
