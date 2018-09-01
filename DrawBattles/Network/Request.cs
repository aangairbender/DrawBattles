using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Network
{
    public class Request
    {
        public long Rid { get; private set; }

        public string RequestType { get; private set; }

        public Dictionary<string, object> RequestParams { get; private set; }

        public Request(long rid, string requestType, Dictionary<string, object> requestParams)
        {
            Rid = rid;
            RequestType = requestType;
            RequestParams = requestParams;
        }
    }
}
