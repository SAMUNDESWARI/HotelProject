using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class RoomInformation
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public bool? Ac { get; set; }
        public string ClassName { get; set; }
    }
}
