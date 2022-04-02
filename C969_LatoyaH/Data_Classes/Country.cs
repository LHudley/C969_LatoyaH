using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        private static int count = 0;

        public Country(int countryId, string countryName, string createdBy, string lastUpdateBy,
            DateTime createDate, DateTime lastUpdate)
        {
            CountryId = countryId;
            CountryName = countryName;
            CreatedBy = createdBy;
            LastUpdateBy = lastUpdateBy;
            CreateDate = createDate;
            LastUpdate = lastUpdate;

            if (countryId > count)
            {
                count = countryId;
                count++;
            }
        }

        public Country()
        {
        }
    }
}
