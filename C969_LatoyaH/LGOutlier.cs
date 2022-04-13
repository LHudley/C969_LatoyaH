using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    class LGOutlier:ApplicationException
    {
        public LGOutlier() : base("Input error")
        {
        }public LGOutlier(string exemptionMessage) : base(exemptionMessage)
        {

        }
        public LGOutlier(string exemptionMessage, ApplicationException inner): base(exemptionMessage, inner)
        {

        }

       
    }
}
