using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;
using ISP.DAL.Repository.OfferRepository;
using ISP.DAL.Repository.RoleRepository;
using ISP.DAL;
using ISP.DAL.Repository.UserRepository;

namespace ISP.API.RedisterDependancies
{
    public static class RepositoryDependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            services.AddScoped<ICentralRepository, CentralRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IPackageReposatory, PackageReposatory>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBillRepository , BillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
