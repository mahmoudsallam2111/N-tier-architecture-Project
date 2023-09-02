using AutoMapper;
using ISP.DAL;

namespace ISP.BL;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository providerRepository;
    private readonly IMapper mapper;

    public ProviderService(IProviderRepository providerRepository , IMapper mapper)
    {
        this.providerRepository = providerRepository;
        this.mapper = mapper;
    }

    public async Task<List<ReadProviderDTO>> GetAll()
    {
        var ProviderListFromDB = await providerRepository.GetAll();
        return mapper.Map<List<ReadProviderDTO>>(ProviderListFromDB);
    }

    public async Task<ReadProviderDTO?> GetById(int id)
    {
        var ProviderFromDB = await providerRepository.GetByID(id);
        return mapper.Map<ReadProviderDTO>(ProviderFromDB);
    }

                    

    public async Task<ReadProviderDTO> Insert(WriteProviderDTO writeProviderDTO)
    {
        var ProviderToAdd = mapper.Map<Provider>(writeProviderDTO);
        await providerRepository.Add(ProviderToAdd);
        providerRepository.SaveChange();
        return mapper.Map<ReadProviderDTO>(ProviderToAdd);
    }

    public async Task<ReadProviderDTO> Edit(int id, UpdateProviderDTO updateProviderDTO)
    {

        var ProviderToEdit = await providerRepository.GetByID(id);
        if (ProviderToEdit == null)
        {
            return null;
        }

        ProviderToEdit.Name = updateProviderDTO.Name;
        ProviderToEdit.IsActive = true;

        providerRepository.Update(ProviderToEdit);

        providerRepository.SaveChange();

        return mapper.Map<ReadProviderDTO>(ProviderToEdit);

    }


    public async Task<ReadProviderDTO> Remove(int id)
    {
        
        var providerFromDB = await providerRepository.GetByID(id);
        if (providerFromDB == null)
        {
            return null;
        }
       
            providerFromDB.IsActive = false;           
            providerRepository.Update(providerFromDB);
            providerRepository.SaveChange();
        
        return mapper.Map<ReadProviderDTO>(providerFromDB);

    }

    public ReadProviderwithoffer_govDTO? GetProviderswithoffer_package(int id)
    {
        var providerfromdb = providerRepository.GetProviderswithoffer_package(id);
        return mapper.Map<ReadProviderwithoffer_govDTO>(providerfromdb);
    }
}
