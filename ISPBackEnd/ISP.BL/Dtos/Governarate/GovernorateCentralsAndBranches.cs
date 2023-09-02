using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Dtos.Governarate
{
    public class GovernorateCentralsAndBranches
    {
       public IEnumerable<ReadBranchDTO> Branches { get; set; } 
        public IEnumerable<ReadCentralDTO> Centrals { get; set; }    
    }
}
