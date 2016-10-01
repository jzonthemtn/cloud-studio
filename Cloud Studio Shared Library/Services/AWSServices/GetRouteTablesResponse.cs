using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting the route tables.
    /// </summary>
    public class GetRouteTablesResponse : AbstractResponse {

        public IList<RouteTable> RouteTables { get; set; }

    }

}
