using System.ComponentModel.DataAnnotations;

namespace GuestHouse
{
    public class User_Details
    {
        [Key]
        public string? TKTNO { get; set; }
        public string? NAME { get; set; }

        public string? EMAIL { get; set; }

        public string? SBG { get; set; }

        public string? MSTGRDCD { get; set; }
         
        public string? DEPTNM { get; set; }

        //public string ReqByTkt { get; set; }

        //public string ReqByName { get; set; }

        //public string ReqByEmail { get; set; }

        //public string SBG { get; set; }

        //public string MSTGRDCD { get; set; }

        //public string DEPTINM { get; set; }


    }
}
