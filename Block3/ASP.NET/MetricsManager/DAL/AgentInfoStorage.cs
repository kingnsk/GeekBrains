using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class AgentInfoStorage
    {
        public List<AgentInfo> Values { get; set; }

        public AgentInfoStorage()
        {
            Values = new List<AgentInfo>();
        }
    }
}
