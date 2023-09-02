using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Data.Models.ModelsCongiguration
{
    public class ClientConfig:IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {


            
           entity.HasIndex(o => new { o.Mobile1, o.Mobile2 })
           .IsUnique();

            entity.HasIndex(c => c.Phone)
               .IsUnique();

        }
    }
}
