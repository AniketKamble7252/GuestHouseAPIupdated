using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    [Keyless]

    public class RequestConfirmation
    {
        public string? SBG { get; set; }
        public string? BAND { get; set; }
        public int? Reqnom { get; set; }
        public string? ReqByTkt { get; set; }
        public string? ReqForGender { get; set; }
        public string? BookingFromDate { get; set; }
        public string? ArrivalTime { get; set; }
        public string? BookingToDate { get; set; }
        public string? DepartureTime { get; set; }
        public string? ReqForTkt { get; set; }
        public string? RoomNo { get; set; }
        public string? ReqForName { get; set; }

        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }



    }
}
