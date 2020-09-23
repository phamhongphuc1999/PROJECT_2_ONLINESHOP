using System;
using System.ComponentModel.DataAnnotations;

namespace MODELS.EF
{
    public class Search
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime start { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime end { get; set; }
    }
}
