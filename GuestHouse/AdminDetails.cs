using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    public class AdminDetails
    {
        [Key]

        public string? LName { get; set; }

        public string? Admin1nm { get; set; }

        public string? AdminID1 { get; set; }

        public string? Admin1email { get; set; }

        public string? Admin1Mobile { get; set; }

        public string? AdminID2 { get; set; }
        public string? Admin2nm { get; set; }
        public string? Admin2email { get; set; }
        public string? Admin2Mobile { get; set; }

        public string? Address { get; set; }


    }
}


   
