using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class Suppliers
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public String Name { get; set; }
        public String WebURL { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}
