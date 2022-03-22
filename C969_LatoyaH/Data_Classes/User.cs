using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class User
    {
       
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string CreatedBy { get; set; }
            public string LastUpdateBy { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime LastUpdate { get; set; }
            public byte Active { get; set; }
            
      
            public User(int userId, string username, string password, string createdBy, string lastUpdateBy, DateTime createDate, DateTime lastUpdate, int active)
            {
                UserId = userId;
                UserName = username;
                Password = password;
                CreatedBy = createdBy;
                LastUpdateBy = lastUpdateBy;
                CreateDate = createDate;
                LastUpdate = lastUpdate;
                Active = (byte)active;
            }

        //static public List<User> Users = new List<User>();
    }
}
