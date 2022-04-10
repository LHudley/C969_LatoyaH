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
      
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }

        public string LastUpdateBy { get; set; }
       
        
      
        private static int count = 0;
        //private object customerId;
        //private object type;
        //private object start;
        //private object end;
        //private DateTime now1;
        //private string userName1;
        //private DateTime now2;
        //private string userName2;

        public Appointment(int appointmentId, int customerId, int userId, string type, DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate,string lastUpdateBy)  
           
        {
            AppointmentId = appointmentId;
            if (appointmentId > count)
            {
                count = appointmentId;
                
            }
            CustomerId = customerId;
            UserId = userId;
            
            Type = type;
            Start = start;
            End = end;
            CreateDate = createDate;

            CreatedBy = createdBy;
            LastUpdate = lastUpdate;

            LastUpdateBy = lastUpdateBy;
           

            
           
        }

       

       

        public Appointment(int customerId, int userId,  string type,  DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            count++;
            
            CustomerId = customerId;
            UserId = userId;
           
            Type = type;
            Start = start;
            End = end;
            CreateDate = createDate;

            CreatedBy = createdBy;
            LastUpdate = lastUpdate;

            LastUpdateBy = lastUpdateBy;

        }

      

       
        

    }
}
