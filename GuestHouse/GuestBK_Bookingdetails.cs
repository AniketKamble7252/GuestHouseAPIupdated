using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestHouse
{

    [Keyless]
    public class GuestBK_Bookingdetails
    {
        public string? Location { get; set; }


        public string? Guest { get; set; }
        public int NoOfGuest { get; set; }

        
     
        
        public string? ReqForTkt { get; set; }
        public string? ReqForName { get; set; }
        public string? ReqForEmail { get; set; }
       public string? ReqForGender { get; set; }

        public string? ReqForContactNo { get; set; }

        public string? BookingFromDate { get; set; }

        public string? BookingToDate { get; set; }

        public string? ArrivalTime { get; set; }

        public string? DepartureTime { get; set; }

        public string? ChargesApplied { get; set; }

        public string? ReqRemark { get; set; }

        public int? Breakfast { get; set; }

        public int? Lunch { get; set; }

        public int? Dinner { get; set; }
        public string? ReqByTkt { get; set; }

        public string? ReqByName { get; set; }

        public string? ReqByEmail { get; set; }

        public string? SBG { get; set; }

        public string? MSTGRDCD { get; set; }

        public string? DEPTNM { get; set; }

        public string? age { get; set; }
    }
}
