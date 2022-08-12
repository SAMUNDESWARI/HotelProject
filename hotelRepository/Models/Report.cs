using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? TransactionId { get; set; }
        public string Information { get; set; }
        public DateTime? Date { get; set; }

        public virtual Transactio Transaction { get; set; }
    }
}
