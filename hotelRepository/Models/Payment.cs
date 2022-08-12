using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Transactios = new HashSet<Transactio>();
        }

        public int PaymentId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual CustInfo Customer { get; set; }
        public virtual ICollection<Transactio> Transactios { get; set; }
    }
}
