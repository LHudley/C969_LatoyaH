using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; } 
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        private static int count = 0;
        public Appointment(int appointmentId, int customerId, int userId, string title, string description, string location,
           string contact, string type, string url, string createdBy, string lastUpdateBy, DateTime start, DateTime end, 
           DateTime createDate, DateTime lastUpdate)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            UserId = userId;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            Url = url;
            CreatedBy = createdBy;
            LastUpdateBy = lastUpdateBy;
            Start = start;
            End = end;
            CreateDate = createDate;
            LastUpdate = lastUpdate;

            
            if (appointmentId > count)
            {
                count = appointmentId;
                count++;
            }
        }

       
    }
}
