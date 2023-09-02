


namespace ISP.BL
{
    public interface IClientservice
    {
        Task<List<ReadClientDTO>> GetAll();
        Task<ReadClientDTO?> GetById(string SSn);

        Task<ReadClientDTO> AddClient(WriteClientDTO writeClientDTO);

        Task<ReadClientDTO> UpdateClient(string SSn, UpdateClientDTO updateClientDTO);

        Task<ReadClientDTO> DeleteClient(string SSn);

     


    }
}
