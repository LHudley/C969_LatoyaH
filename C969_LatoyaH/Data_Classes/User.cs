using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class User
    {
       
            public static  int UserId { get; set; }
            public static string UserName { get; set; }
            public static string Password { get; set; }
            public static string CreatedBy { get; set; }
            public static string LastUpdateBy { get; set; }
            public static DateTime CreateDate { get; set; }
            public static DateTime LastUpdate { get; set; }
            public static byte Active { get; set; }
            
      
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
