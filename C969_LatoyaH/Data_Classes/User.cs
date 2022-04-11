using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public  class User
    {

        
        public   int UserId { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        public  byte Active { get; set; }
        public  DateTime CreateDate { get; set; }
        public  string CreatedBy { get; set; }
        public  DateTime LastUpdate { get; set; }
        public  string LastUpdateBy { get; set; }

        public User(int userId, string userName, string password, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
             UserId = userId;
            UserName = userName;
            Password = password;
            Active = (byte)active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;


        }





        

    }
}
