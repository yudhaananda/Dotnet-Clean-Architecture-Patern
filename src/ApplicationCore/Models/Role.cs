using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Role : BaseModel<Role>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }

        public override void Edit(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
