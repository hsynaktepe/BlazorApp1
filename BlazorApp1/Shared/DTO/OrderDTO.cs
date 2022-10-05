using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int SupplierId { get; set; }
        [MaxLength(50)]
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public String CreatedUserFullName { get; set; }
        public String SupplierName { get; set; }
    }
}
