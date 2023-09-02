using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public interface IGovernorateRepository:IGenericRepository<Governorate>
    {
        public void Delete(Governorate governarate);
        public Task<Governorate> GetCentralsAndBranches(int Code);
    }
}
