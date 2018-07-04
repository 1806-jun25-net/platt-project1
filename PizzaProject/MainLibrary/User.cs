using System;

namespace MainLibrary
{
    public class User
    {
        public string firstName { get; set; } = "Bob";
        public string lastName { get; set; } = "Ross";
        Location defaultLocation = new Location();
        public string RecentOrderLocation { get; set; } = "Main Store";



       public DateTime timeOfOrder = new DateTime();



        
    }
}
