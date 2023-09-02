using AutoMapper;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    //[AutoMap(typeof(Branch))]
    public class ReadBranchDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        public string Phone1 { get; set; } = string.Empty;

        public string Phone2 { get; set; } = string.Empty;

        public string tel1 { get; set; } = string.Empty;
        public string tel2 { get; set; } = string.Empty;

        public int? Fax { get; set; }

       
        public  string? ManagerName { get; set; }

        public ReadGovernarateDTO Governorate { get; set; }

    }
}
