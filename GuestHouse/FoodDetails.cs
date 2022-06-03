using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    
    public class FoodDetails
    {
        [Key]
        public string? LOCATION { get; set; }
        public string? ReqByTkt { get; set; }
        public string? ReqForTkt { get; set; }
        public string? bookingdate { get; set; }
        public int Reqnom { get; set; }
        public string? Floor { get; set; }
        public int? Breakfast { get; set; }
        public int? Lunch { get; set; }
        public int? Dinner { get; set; }
        public string? Status_food { get; set; }
    }
}
