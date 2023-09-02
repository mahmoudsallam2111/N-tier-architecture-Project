using ISP.BL.Dtos.Shared;
using ISP.DAL;
using ISP.DAL.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Services.SharedService
{
    public class Sharedservice : Ishardservice
    {
        private readonly IClientRepository clientRepository;
        private readonly IUserRepository userRepository;

        public Sharedservice(IClientRepository clientRepository ,  IUserRepository userRepository)
        {
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;
        }
        public SharedDTO countsystemuser()
        {
            var clientnum = clientRepository.ClientCount();
            var empnum = userRepository.EmployeeCount();

            return new SharedDTO
            {
                CountClient = clientnum,
                CountEmployee = empnum,
            };
        }
    }
}
