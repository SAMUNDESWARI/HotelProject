using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Transactios = new HashSet<Transactio>();
        }

        public int ReservationId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public int? DateRange { get; set; }
        public int? HotelCode { get; set; }

        public virtual CustInfo Customer { get; set; }
        public virtual Hotel HotelCodeNavigation { get; set; }
        public virtual ICollection<Transactio> Transactios { get; set; }
    }
}
