
using ISP.BL.Dtos.Offer;

namespace ISP.BL.Services.OfferService
{
    public interface IOfferService
    {
        Task<List<ReadOfferDto>> GetAll();
        Task<ReadOfferDto?> GetById(int id);

        Task<ReadOfferDto> Insert(WriteOfferDto writeOfferDto);

        Task<ReadOfferDto> Edit(int id, UpdataOfferDto updataOfferDto);

        Task<ReadOfferDto> Delete(int id);
    }
}
