using Microsoft.AspNetCore.Identity;

namespace ISP.DAL
{

    public class Role : IdentityRole
    {
        public bool Status { get; set; } = true;


    }


}
