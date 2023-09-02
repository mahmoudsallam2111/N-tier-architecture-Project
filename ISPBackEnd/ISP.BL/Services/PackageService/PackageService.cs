using AutoMapper;
using ISP.DAL;
using ISP.DAL.Repository.BranchRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class PackageService : IPackageService
    {
        private readonly IPackageReposatory PackageRepository;
        private readonly IMapper mapper;
        public PackageService(IPackageReposatory packageReposatory, IMapper mapper)
        {
            this.PackageRepository = packageReposatory;
            this.mapper = mapper;
        }

        public async Task<ReadPackageDTO> AddPackage(WritePackageDTO writePackageDTO)
        {
            var PackageToAdd = mapper.Map<Package>(writePackageDTO);
            await PackageRepository.Add(PackageToAdd);
            PackageRepository.SaveChange();
            return mapper.Map<ReadPackageDTO>(PackageToAdd);
        }

        public async Task<ReadPackageDTO> DeletePackage(int id)
        {
            var PackageFromDB = await PackageRepository.GetByID(id);
            if (PackageFromDB == null)
            {
                return null;
            }
            if(PackageFromDB.IsActive==true)
            {
                PackageFromDB.IsActive = false;
                PackageRepository.Update(PackageFromDB);
            }
          //  PackageRepository.Delete(PackageFromDB);
            PackageRepository.SaveChange();
            return mapper.Map<ReadPackageDTO>(PackageFromDB);

        }

        public async Task<List<ReadPackageDTO>> GetAll()
        {
          var PackageListFromDb= await PackageRepository.GetAll();
          return mapper.Map<List<ReadPackageDTO>>(PackageListFromDb);
        }

        public async Task<ReadPackageDTO?> GetById(int id)
        {
            var PackageFromDB = await PackageRepository.GetByID(id);
            return mapper.Map<ReadPackageDTO>(PackageFromDB);
        }

        public async Task<ReadPackageDTO> UpdatePackage(int id, UpdatePackageDTO updatePackageDTO)
        {
            var PackageToEdit = await PackageRepository.GetByID(id);
            if (PackageToEdit == null)
            {
                return null;
            }

            PackageToEdit.Name = updatePackageDTO.Name;
            PackageToEdit.Note= updatePackageDTO.Note;
            PackageToEdit.Price= updatePackageDTO.Price;
            PackageToEdit.Type= updatePackageDTO.Type;
            PackageToEdit.ProviderId= updatePackageDTO.ProviderId;
            PackageRepository.Update(PackageToEdit);

            PackageRepository.SaveChange();

            return mapper.Map<ReadPackageDTO>(PackageToEdit);
        }



      

    }
}
