namespace MODELS.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public int IdCustomer { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DaySell { get; set; }

        public bool Status { get; set; }
    }
}
