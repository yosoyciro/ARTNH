using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Ref
{
    public class RefAgenteCausante
    {
        public virtual int Interno { get; set; }
        public virtual int Codigo { get; set; }
        //public virtual string AgenteCausante { get; set; }
        public virtual string AgenteTipo { get; set; }       
    }
}
