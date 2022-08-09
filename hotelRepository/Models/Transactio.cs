using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Transactio
    {
        public Transactio()
        {
            Reports = new HashSet<Report>();
        }

        public int TransactionId { get; set; }
        public string TransactionName { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ReservationId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? HotelCode { get; set; }

        public virtual CustInfo Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Hotel HotelCodeNavigation { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
