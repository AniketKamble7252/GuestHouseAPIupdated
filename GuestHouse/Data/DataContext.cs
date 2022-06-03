using Microsoft.EntityFrameworkCore;

namespace GuestHouse.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<GuestBK_Bookingdetails> guestBK_Bookingdetails { get;set;}
        public object GuestBK_Bookingdetails { get; internal set; }
        public DbSet<AdminDetails> AdminDetails { get;set;}

        public DbSet<User_Details> User_Details { get;set;}

        public DbSet<Fetch_CancellationDetails> Fetch_CancellationDetails { get; set; }   

        public DbSet<Status> Statuses { get; set; }

        public DbSet<PendingRequest> PendingRequests { get; set; }  

        public DbSet<ApprovedRequest> ApprovedRequests { get; set; }
        
        public DbSet<RequestConfirmation> RequestConfirmation { get; set; }

        public DbSet<RoomAllocation> RoomAllocation { get; set; }

        public DbSet<FloorConfirmation> FloorConfirmation { get; set; } 

        public DbSet<GetRBookingTime> GetRBookingTime { get; set; }

        public DbSet<FoodDetails> FoodDetails { get; set; }



        public DbSet<GetReqNom> GetReqNom { get; set; }

        public DbSet<CheckInOutRoomTrans> CheckInOutRoomTrans { get; set; }
    }
}
