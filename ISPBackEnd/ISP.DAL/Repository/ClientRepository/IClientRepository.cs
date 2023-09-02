using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public interface IClientRepository:IGenericRepository<Client>
    {
         Task<Client?> GetByID(string ssn);
        int ClientCount();
    }
}
