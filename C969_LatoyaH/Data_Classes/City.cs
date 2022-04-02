using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        private static int count = 0;

        public City(int cityId, string cityName, int countryId, string createdBy, string lastUpdateBy,
            DateTime createDate, DateTime lastUpdate)
        {
            CityId = cityId;
            CityName = cityName;
            CountryId = countryId;
            CreatedBy = createdBy;
            LastUpdateBy = lastUpdateBy;
            CreateDate = createDate;
            LastUpdate = lastUpdate;

            if (cityId > count)
            {
                count = cityId;
                count++;
            }

        }

        public City()
        {
        }
    }
}
