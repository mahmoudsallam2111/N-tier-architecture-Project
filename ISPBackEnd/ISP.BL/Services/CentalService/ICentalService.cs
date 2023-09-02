using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public interface ICentalService
    {
        Task<List<ReadCentralDTO>> GetAll();
        Task<List<ReadCentralWithGovernarateDTO>> GetAllwithgov();
        Task<ReadCentralDTO?> GetById(int id);
        Task<ReadCentralDTO?> GetByName(string Name);

        Task<ReadCentralDTO> Insert(WriteCentralDTO writeCentralDTO);

        Task<ReadCentralDTO> Edit(int id, UpdateCentralDTO updateCentralDTO);

        Task<ReadCentralDTO> Delete(int id);
    }
}
