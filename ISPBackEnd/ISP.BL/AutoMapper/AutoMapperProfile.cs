using AutoMapper;

using ISP.BL.Dtos.Bill;

using ISP.BL.Dtos.ClientOffer;

using ISP.BL.Dtos.Governarate;
using ISP.BL.Dtos.Offer;
using ISP.BL.Dtos.Role;
using ISP.BL.Dtos.Users;
using ISP.DAL;

namespace ISP.BL
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Branch
            //Branch
            CreateMap<Branch , WriteBranchDTO>()
                .ForMember(u => u.tel1, s => s.MapFrom(src => src.Phone1))
                .ForMember(u => u.tel2, s => s.MapFrom(src => src.Phone2))
                .ForMember(u => u.phone1, s => s.MapFrom(src => src.Mobile1))
                .ForMember(u => u.phone2, s => s.MapFrom(src => src.Mobile2))
               .ForMember(u => u.GovernorateCode, s => s.MapFrom(src => src.GovernorateCode)).
                ReverseMap();

            CreateMap<Branch , UpdateBranchDTO>()
                  .ForMember(u => u.tel1, s => s.MapFrom(src => src.Phone1))
                .ForMember(u => u.tel2, s => s.MapFrom(src => src.Phone2))

                .ForMember(u => u.phone1, s => s.MapFrom(src => src.Mobile1))
                .ForMember(u => u.phone2, s => s.MapFrom(src => src.Mobile2)).ReverseMap();

            CreateMap<Branch, ReadBranchDTO>()
                .ForMember(u => u.tel1, s => s.MapFrom(src => src.Phone1))
                .ForMember(u => u.tel2, s => s.MapFrom(src => src.Phone2))
                .ForMember(u => u.Phone1, s => s.MapFrom(src => src.Mobile1))
                .ForMember(u => u.Phone2, s => s.MapFrom(src => src.Mobile2))
                .ForMember(u => u.Governorate, s => s.MapFrom(src => src.Governorate))
                .ReverseMap();




            #endregion

            #region Goernorate
            //Governarate
            CreateMap<Governorate , ReadGovernarateDTO>().ReverseMap();
            CreateMap<Governorate , WriteGovernarateDTO>().ReverseMap();
            CreateMap<Governorate , UpdateGovernarateDTO>().ReverseMap();
            CreateMap<Governorate,GovernorateCentralsAndBranches>().ReverseMap();
            #endregion

            #region Central
            //Central
            CreateMap<Central , ReadCentralDTO>().ReverseMap();
            CreateMap<Central , WriteCentralDTO>().ReverseMap();
            CreateMap<Central , UpdateCentralDTO>().ReverseMap();
            CreateMap<Central , ReadCentralWithGovernarateDTO>().ReverseMap();



            #endregion



            #region Provider
            //Provider
            CreateMap<Provider , ReadProviderDTO>().ReverseMap();
            CreateMap<Provider , WriteProviderDTO>().ReverseMap();
            CreateMap<Provider, ReadProviderwithoffer_govDTO>().ReverseMap();
           

            #endregion

            #region Offer
            //Offer
            CreateMap<Offer, UpdataOfferDto>()

                .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(o => o.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
                .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
                .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
                .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
                .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
                .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
                .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
                .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
                .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
                .ReverseMap();

            CreateMap<Offer, WriteOfferDto>()
               .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(o => o.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
               .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
               .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
               .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
               .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
               .ForMember(o => o.FreeRouter, opt => opt.MapFrom(src => src.HasRouter))
               .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
               .ReverseMap();

            CreateMap<Offer, ReadOfferDto>()
               .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
               .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
               .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
               .ForMember(o => o.FreeRouter, opt => opt.MapFrom(src => src.HasRouter))
               .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
               .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
                 .ReverseMap();





            #endregion


            #region ClientOffer
            CreateMap<ClientOffers, ReadClientOfferDTO>().ReverseMap();
                
            #endregion

            #region Client
            //client
            CreateMap<Client, ReadClientDTO>()
                .ForMember(c => c.SSID, cmt => cmt.MapFrom(src => src.SSn))
                .ForMember(c => c.Name, cmt => cmt.MapFrom(src => src.Name))
                .ForMember(c => c.Tel, cmt => cmt.MapFrom(src => src.Phone))
                
                .ForMember(c => c.Address, cmt => cmt.MapFrom(src => src.Address))
                .ForMember(c => c.Email, cmt => cmt.MapFrom(src => src.Email))
            
                .ForMember(c => c.Phone, cmt => cmt.MapFrom(src => src.Mobile1))
                .ForMember(c => c.UserName, cmt => cmt.MapFrom(src => src.userName))
                .ForMember(c => c.Password, cmt => cmt.MapFrom(src => src.Password))
                .ForMember(c => c.Governorate, cmt => cmt.MapFrom(src => src.Governarate))
                .ForMember(c => c.Slot, cmt => cmt.MapFrom(src => src.Slotnum))
                .ForMember(c => c.Block, cmt => cmt.MapFrom(src => src.Blocknum))
                .ForMember(c => c.OperationOrderNumber, cmt => cmt.MapFrom(src => src.OrderWorkNumber))
                .ForMember(c => c.PackageIp, cmt => cmt.MapFrom(src => src.IpPackage))

                .ReverseMap();

  

            CreateMap<Client, UpdateClientDTO>()
              .ForMember(c => c.SSID, cmt => cmt.MapFrom(src => src.SSn))
              .ForMember(c => c.PackageId, cmt => cmt.MapFrom(src => src.PackageId))
              .ReverseMap();

            CreateMap<Client, WriteClientDTO>()
            .ForMember(c => c.SSID, cmt => cmt.MapFrom(src => src.SSn))
            .ForMember(c => c.name, cmt => cmt.MapFrom(src => src.Name))
            .ForMember(c => c.tel, cmt => cmt.MapFrom(src => src.Phone))
            .ForMember(c => c.governorateCode, cmt => cmt.MapFrom(src => src.GovernarateCode))
            .ForMember(c => c.address, cmt => cmt.MapFrom(src => src.Address))
            .ForMember(c => c.email, cmt => cmt.MapFrom(src => src.Email))
            .ForMember(c => c.providerId, cmt => cmt.MapFrom(src => src.ProviderId))
            .ForMember(c => c.packageId, cmt => cmt.MapFrom(src => src.PackageId))
            .ForMember(c => c.branchId, cmt => cmt.MapFrom(src => src.BranchId))
           // .ForMember(c => c.OfferId, cmt => cmt.MapFrom(src => src.OfferId))
            .ForMember(c => c.centralId, cmt => cmt.MapFrom(src => src.CentralId))
            .ForMember(c => c.packageIp, cmt => cmt.MapFrom(src => src.IpPackage))
            .ForMember(c => c.routerSerial, cmt => cmt.MapFrom(src => src.RouterSerial))
            .ForMember(c => c.phone, cmt => cmt.MapFrom(src => src.Mobile1))
            .ForMember(c => c.orderNumber, cmt => cmt.MapFrom(src => src.OrderNumber))
            .ForMember(c => c.portSlot, cmt => cmt.MapFrom(src => src.PortSlot))
            .ForMember(c => c.slot, cmt => cmt.MapFrom(src => src.Slotnum))
            .ForMember(c => c.block, cmt => cmt.MapFrom(src => src.Blocknum))
            .ForMember(c => c.portBlock, cmt => cmt.MapFrom(src => src.PortBlock))
            .ForMember(c => c.userName, cmt => cmt.MapFrom(src => src.userName))
            .ForMember(c => c.password, cmt => cmt.MapFrom(src => src.Password))
            .ForMember(c => c.vci, cmt => cmt.MapFrom(src => src.VCI))
            .ForMember(c => c.vpi, cmt => cmt.MapFrom(src => src.VPI))
            .ForMember(c => c.operationOrderNumber, cmt => cmt.MapFrom(src => src.OrderWorkNumber))
            .ForMember(c => c.operationOrderDate, cmt => cmt.MapFrom(src => src.Orderworkdate))
            .ForMember(c => c.prePaid, cmt => cmt.MapFrom(src => src.PrePaid))
            .ForMember(c => c.installationFee, cmt => cmt.MapFrom(src => src.installationFee))
            .ForMember(c => c.contractFee, cmt => cmt.MapFrom(src => src.ContractFee))
            .ReverseMap();
            #endregion


            #region Package
            //Package
            CreateMap<Package, ReadPackageDTO>().ReverseMap();
            CreateMap<Package, WritePackageDTO>().ReverseMap();
            CreateMap<Package, UpdatePackageDTO>().ReverseMap();

            #endregion




        
            #region Role  


            //Role
            CreateMap<Role, ReadRoleDto>().ReverseMap();
            CreateMap<Role, WriteRoleDto>().ReverseMap();           
            #endregion

            #region Bill
            // bill
            CreateMap<Bill , ReadBillDTO>().ReverseMap();
            CreateMap<Bill , ReadBillwithClientDTO>().ReverseMap();
            #endregion

            #region User

            CreateMap<User, ReadUserDto>()
               
                .ForMember(u => u.Branch, s => s.MapFrom(src => src.Branch.Name))
                .ForMember(u => u.UserName, s => s.MapFrom(src => src.UserName))
                .ForMember(u => u.Email, s => s.MapFrom(src => src.Email))
                .ForMember(u => u.Status, s => s.MapFrom(src => src.Status))
                .ForMember(u => u.PhoneNumber, s => s.MapFrom(src => src.PhoneNumber))
                
                .ReverseMap();

            CreateMap<User, ReadManagerDto>().ReverseMap();
            #endregion

        }

    }
}
