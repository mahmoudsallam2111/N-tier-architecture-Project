using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Repository.CentralRepository
{
    public interface ICentralRepository:IGenericRepository<Central>
    {
        Task<Central?> GetBYNameAsync(string Name);
        Task<List<Central>> getAllCentralwithGovernarate();
        Task<Central?> GetcentralByIdWithGovernarate(int id);
       
    }
}
