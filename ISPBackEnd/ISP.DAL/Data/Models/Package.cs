using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public class Package
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;

        public double Price { get; set; }
        public double purchasePrice { get; set; }
       
        public string Note { get; set; } = string.Empty;


        public bool IsActive { get; set; } = true;


        [ForeignKey("Provider")]
        public int ProviderId { get; set; }

       
        public Provider? Provider { get; set; }

        public  ICollection<Client> Clients { get; set; } = new HashSet<Client>();


    }
}



