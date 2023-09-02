using ISP.BL.Dtos.Governarate;

namespace ISP.BL
{
    public interface IGovernarateService
    {
        Task<List<ReadGovernarateDTO>> GetAll();
        Task<ReadGovernarateDTO?> GetById(int Code);

        Task<ReadGovernarateDTO> AddGovernarate(WriteGovernarateDTO writeGovernarateDTO);

        Task<ReadGovernarateDTO> UpdateGovernarate(int Code, UpdateGovernarateDTO updateGovernarateDTO);

        Task<ReadGovernarateDTO> DeleteGovernarate(int code);
        Task<GovernorateCentralsAndBranches> GetCentralsAndBranches(int Code);


    }
}
