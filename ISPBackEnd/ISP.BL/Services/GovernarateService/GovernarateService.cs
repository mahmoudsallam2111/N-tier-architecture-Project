using AutoMapper;
using ISP.BL.Dtos.Governarate;
using ISP.DAL;
namespace ISP.BL
{
    public class GovernarateService : IGovernarateService
    {
        private readonly IGovernorateRepository governarateRepository;
        private readonly IMapper mapper;

        public GovernarateService(IGovernorateRepository governarateRepository , IMapper mapper)
        {
            this.governarateRepository = governarateRepository;
            this.mapper = mapper;
        }

        public  async Task<List<ReadGovernarateDTO>> GetAll()
        {
            var GovernarateListFromDB = await governarateRepository.GetAll();
            return mapper.Map<List<ReadGovernarateDTO>>(GovernarateListFromDB);
        }

        public async Task<ReadGovernarateDTO?> GetById(int Code)
        {
            var GovernarateFromDB = await governarateRepository.GetByID(Code);
            return mapper.Map<ReadGovernarateDTO>(GovernarateFromDB);
        }
        public async Task<GovernorateCentralsAndBranches> GetCentralsAndBranches(int Code)
        {
            var BranchAndCentral = await governarateRepository.GetCentralsAndBranches(Code);
            return mapper.Map<GovernorateCentralsAndBranches>(BranchAndCentral);
        }
        public async Task<ReadGovernarateDTO> AddGovernarate(WriteGovernarateDTO writeGovernarateDTO)
        {
            var GovernarateToAdd = mapper.Map<Governorate>(writeGovernarateDTO);
            await governarateRepository.Add(GovernarateToAdd);
            governarateRepository.SaveChange();
            return mapper.Map<ReadGovernarateDTO>(GovernarateToAdd);
        }

        public async Task<ReadGovernarateDTO> UpdateGovernarate(int Code, UpdateGovernarateDTO updateGovernarateDTO)
        {
            var GovernarateToEdit = await governarateRepository.GetByID(Code);
            if (GovernarateToEdit == null)
            {
                return null;
            }


            var updatedGovernarate = new Governorate
            {
                Code = updateGovernarateDTO.Code,
                Name = updateGovernarateDTO.Name,
                Status = true
            };

            // Save changes
            try
            {
                governarateRepository.Delete(GovernarateToEdit);
               await governarateRepository.Add(updatedGovernarate);
                governarateRepository.SaveChange();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception("Failed to update governarate.", ex);
            }

            // Return the updated entity
            return mapper.Map<ReadGovernarateDTO>(updatedGovernarate);
        }
        public async Task<ReadGovernarateDTO> DeleteGovernarate(int code)
        {
           
            var GovernarateFromDB = await governarateRepository.GetByID(code);
            if (GovernarateFromDB == null)
            {
                return null;
            }
            
                GovernarateFromDB.Status = false;
                governarateRepository.Update(GovernarateFromDB);
                governarateRepository.SaveChange();             
           
            return mapper.Map<ReadGovernarateDTO>(GovernarateFromDB);
        }

       
    }
}
