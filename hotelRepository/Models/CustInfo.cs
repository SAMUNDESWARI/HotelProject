using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class CustInfo
    {
        public CustInfo()
        {
            Payments = new HashSet<Payment>();
            Reservations = new HashSet<Reservation>();
            Transactios = new HashSet<Transactio>();
        }

        public int CustomerId { get; set; }
        public string Custfname { get; set; }
        public string Custlname { get; set; }
        public string Address { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Transactio> Transactios { get; set; }
    }
}
