using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class RoomInformation
    {
        public int RoomId { get; set; }
        public int? NumberOfRooms { get; set; }
        public string RoomType { get; set; }
        public decimal? Price { get; set; }
    }
}
