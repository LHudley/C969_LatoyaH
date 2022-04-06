using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1{ get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        private static int count = 0;

        public Address(int addressId, string address1, string address2, int cityId, string postalCode, string phone,
            string createdBy, string lastUpdateBy, DateTime createDate, DateTime lastUpdate)
        {
            AddressId = addressId;
            Address1 = address1;
            Address2 = address2;
            CityId = cityId;
            PostalCode = postalCode;
            Phone = phone;
            CreatedBy = createdBy;
            LastUpdateBy = lastUpdateBy;
            CreateDate = createDate;
            LastUpdate = lastUpdate;

            if (addressId > count)
            {
                count = addressId;
                count++;
            }
        }

        public Address()
        {
        }
    }
}
