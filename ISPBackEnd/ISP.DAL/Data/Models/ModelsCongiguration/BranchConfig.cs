using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Data.Models.ModelsCongiguration
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            //entity
            //     .HasAlternateKey(e => e.Phone1);
            //entity
            // .HasAlternateKey(e => e.Phone2);
            //entity
            //.HasAlternateKey(e => e.Mobile1);
            //entity
            //.HasAlternateKey(e => e.Mobile2);


            entity.HasIndex(o => new { o.Mobile1, o.Mobile2 })
            .IsUnique();

            entity.HasIndex(o => new { o.Phone1, o.Phone2 })
            .IsUnique();

        }



    }
}
