using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    public class Fetch_CancellationDetails
    {
        
        public int? Reqnom { get; set; }

        public string? ReqByTkt { get; set; }
        [Key]
        public string? ReqForName { get; set; }
        
        public string? BookingFromDate { get; set; }

        public string? BookingToDate { get; set; }

        public string? RoomNo { get; set; }

        public string? ArrivalTime { get; set; }

        public string? DepartureTime { get; set; }

        public string? STATUS1 { get; set; }

    }
}

  
