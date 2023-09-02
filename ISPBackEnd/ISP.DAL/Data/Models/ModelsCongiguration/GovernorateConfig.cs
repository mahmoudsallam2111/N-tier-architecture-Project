using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Data.Models.ModelsCongiguration
{
    public class GovernorateConfig : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> entity)
        {
            entity.HasAlternateKey(e => e.Name);
            entity.HasData(new { Code = 66, Name = "cairo" , Status = true });
        }
    }
}
