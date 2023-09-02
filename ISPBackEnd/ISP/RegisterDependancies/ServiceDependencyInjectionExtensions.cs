using ISP.BL.Services.OfferService;
using ISP.BL.Services.RoleService;
using ISP.BL;
using ISP.BL.Services.UserPermissionsService;
using Microsoft.AspNetCore.Authorization;
using ISP.BL.Permission;
using ISP.BL.Services.SharedService;

namespace ISP.API.RedisterDependancies
{
    public static class ServiceDependencyInjectionExtensions
    {


        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IGovernarateService, GovernarateService>();
            services.AddScoped<ICentalService, CentalService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IPackageService, PackageService>();          
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IClientservice, ClientService>();
            services.AddScoped<IBillService , BillService>();
            services.AddScoped<Ishardservice , Sharedservice>();

            

            services.AddScoped<IUserService, UserService>();            
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();


        }

       

    }
}
