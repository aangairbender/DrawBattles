using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Network
{
    public class Response
    {
        public long Rid { get; private set; }      

        public Dictionary<string, object> Data { get; private set; }

        public Response(long rid, Dictionary<string, object> data)
        {
            Rid = rid;
            Data = data;
        }
    }
}
