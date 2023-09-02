
namespace ISP.BL
{
    public interface IProviderService
    {
        Task<List<ReadProviderDTO>> GetAll();
        Task<ReadProviderDTO?> GetById(int id);

        ReadProviderwithoffer_govDTO? GetProviderswithoffer_package(int id);

        Task<ReadProviderDTO> Insert(WriteProviderDTO writeProviderDTO);

        Task<ReadProviderDTO> Edit(int id, UpdateProviderDTO updateProviderDTO);

        Task<ReadProviderDTO> Remove(int id);
    }
}
