using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{ 
    [Keyless]
    public class GetRBookingTime
    {
        
        public string RoomNo { get; set; } 

        public string ArrivalTime { get; set; }
      
        public string DepartureTime { get; set; }

        //public string? Location { get; set; }

        //public string? Date { get; set; }
        


    }
}
