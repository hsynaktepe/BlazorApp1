using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public String FirstName { get; set; } = String.Empty;
        [MaxLength(50)]
        public String LastName { get; set; } = String.Empty;
        [MaxLength(50)]
        public String EmailAdress { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public bool IsActive { get; set; } 

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

    }
}
