using AutoMapper;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;
        private readonly IMapper mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            this.branchRepository = branchRepository;
            this.mapper = mapper;
        }

        public async Task<List<ReadBranchDTO>> GetAll()
        {
            var BranchListFromDB = await branchRepository.GetAll();
            return mapper.Map<List<ReadBranchDTO>>(BranchListFromDB);
        }

        public async Task<ReadBranchDTO?> GetById(int id)
        {
            var BranchFromDB = await branchRepository.GetByID(id);
            return mapper.Map<ReadBranchDTO>(BranchFromDB);
        }
        public async Task<ReadBranchDTO> AddBranch(WriteBranchDTO writeBranchDTO)
        {
            var BranchToAdd = mapper.Map<Branch>(writeBranchDTO);

            await branchRepository.Add(BranchToAdd);
            branchRepository.SaveChange();
            return mapper.Map<ReadBranchDTO>(BranchToAdd);
        }

        public async Task<ReadBranchDTO> DeleteBranch(int id)
        {            
            var BranchFromDB = await branchRepository.GetByID(id);
            if (BranchFromDB == null)
            {
                return null;
            }
            
                BranchFromDB.Status = false;
                branchRepository.Update(BranchFromDB);
                branchRepository.SaveChange();            

            return mapper.Map<ReadBranchDTO>(BranchFromDB);

        }

        public async Task<ReadBranchDTO> UpdateBranch(int id, UpdateBranchDTO updateBranchDTO)
        {
            var BranchToEdit = await branchRepository.GetByID(id);
            if (BranchToEdit == null)
            {
                return null;
            }

            BranchToEdit.Name = updateBranchDTO.Name;
            BranchToEdit.Phone1 = updateBranchDTO.tel1;
            BranchToEdit.Phone2= updateBranchDTO.tel2;
            BranchToEdit.Mobile1= updateBranchDTO.phone1;
            BranchToEdit.Mobile2= updateBranchDTO.phone2;
            BranchToEdit.ManagerId= updateBranchDTO.ManagerId;
            BranchToEdit.Fax= updateBranchDTO.Fax;
            BranchToEdit.Status = true;

            branchRepository.Update(BranchToEdit);

            branchRepository.SaveChange();

            return mapper.Map<ReadBranchDTO>(BranchToEdit);
        }


    }
}
