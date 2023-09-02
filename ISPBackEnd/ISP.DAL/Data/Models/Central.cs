using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP.DAL
{
    public class Central
    {

        public int Id { get; set; }

        [StringLength(50)]        
        public string Name { get; set; }  = string.Empty;
        public bool Status { get; set; } = true;

        [ForeignKey("Governarate")]
        public int GovernorateCode { get; set; }
        public Governorate? Governorate { get; set; }

        public ICollection<Provider> Providers { get; set; } = new HashSet<Provider>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}