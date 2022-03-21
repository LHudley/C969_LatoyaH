using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public byte Active { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public static int count = 0;

        public Customer(int customerId, string customerName, int addressId, int active, string createdBy, string lastUpdateBy,
            DateTime createDate, DateTime lastUpdate)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressId = addressId;
            Active = (byte)active;
            CreatedBy = createdBy;
            LastUpdateBy = lastUpdateBy;
            CreateDate = createDate;
            LastUpdate = lastUpdate;

            if (customerId > count)
            {
                count = customerId;
                count++;
            }
        }
    }
}
