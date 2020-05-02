namespace MODELS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public int IdCustomer { get; set; }

        public DateTime? DaySell { get; set; }
    }
}
