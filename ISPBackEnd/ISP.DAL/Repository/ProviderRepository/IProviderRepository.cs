
namespace ISP.DAL
{
    public interface IProviderRepository:IGenericRepository<Provider>
    {
       Provider? GetProviderswithoffer_package(int id);
    }
}
