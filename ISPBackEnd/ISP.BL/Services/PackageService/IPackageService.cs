using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
  public interface IPackageService
    {
        Task<List<ReadPackageDTO>> GetAll();
        Task<ReadPackageDTO?> GetById(int id);

        Task<ReadPackageDTO> AddPackage(WritePackageDTO writePackageDTO);

        Task<ReadPackageDTO> UpdatePackage(int id, UpdatePackageDTO updatePackageDTO);

        Task<ReadPackageDTO> DeletePackage(int id);
    }
}
