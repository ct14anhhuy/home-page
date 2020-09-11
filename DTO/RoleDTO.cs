using System.Collections.Generic;

namespace DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserLoginDTO> UserLogins { get; set; }
    }
}