
namespace ISP.BL
{
    public interface IBranchService
    {
        Task<List<ReadBranchDTO>> GetAll();
        Task<ReadBranchDTO?> GetById(int id);

        Task<ReadBranchDTO> AddBranch(WriteBranchDTO writeBranchDTO);

        Task<ReadBranchDTO> UpdateBranch(int id, UpdateBranchDTO updateBranchDTO);

        Task<ReadBranchDTO> DeleteBranch(int id);
    }
}
