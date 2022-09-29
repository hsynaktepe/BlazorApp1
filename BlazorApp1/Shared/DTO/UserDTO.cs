using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public String FirstName { get; set; }
        [MaxLength(50)]
        public String LastName { get; set; }
        [MaxLength(50)]
        public String EmailAdress { get; set; }
        public String Password { get; set; }
        public bool IsActive { get; set; }
        public String FullName => $"{FirstName} {LastName}";
    }
}
