using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    public class RoomAllocation
    {   [Key]
        public int reqnom { get; set; }

        public string? RoomNo { get; set; }
    }
}
