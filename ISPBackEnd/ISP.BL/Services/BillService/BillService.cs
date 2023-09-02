using AutoMapper;
using ISP.BL.Dtos.Bill;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public BillService(IBillRepository billRepository  , IClientRepository clientRepository,  IMapper mapper)
        {
            this.billRepository = billRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public int BillGenerationSP()
        {
            
            return billRepository.BillGenerationSP();

        }

        public IEnumerable<ReadBillDTO> getClientBills(string Ssid, bool condition)
        {
            var bill_list_fromdb = billRepository.getClientBills(Ssid , condition);

            return mapper.Map<List<ReadBillDTO>>(bill_list_fromdb);
        }

        public  async Task<ReadBillDTO?> GetNextMonthBill(int Nmonth, string ClientId)
        {
            var client = await clientRepository.GetByID(ClientId);

            if (client is null)
            {
                throw new Exception();
            }
            var billfromdb =  billRepository.GetNextMonthBill(Nmonth, ClientId);

            billfromdb.Client = client;
           
            return mapper.Map<ReadBillDTO>(billfromdb);
        }

        public IEnumerable<ReadBillwithClientDTO> GetNopaid_bilist()
        {
            var billfromdb = billRepository.GetNopaid_bilist();
            return mapper.Map<List<ReadBillwithClientDTO>>(billfromdb);
        }

        public void paidBill(int id)
        {
            billRepository.paidBill(id);
        }
    }
}
