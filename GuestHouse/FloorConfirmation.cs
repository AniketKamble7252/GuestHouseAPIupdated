using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    public class FloorConfirmation
    {
        
        public string Floor { get; set; }

        [Key]
        public string? ROOMS { get; set; }
       
    }
}
