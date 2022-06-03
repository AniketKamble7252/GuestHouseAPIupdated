using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{

    
    public class CheckInOutRoomTrans
    {
        [Key]
        public int Reqnom { get; set; }

        public string CheckinTime { get; set; }

        public string? CheckoutTime { get; set; } = string.Empty;

        public string RoomNo { get; set; }


    }
}
