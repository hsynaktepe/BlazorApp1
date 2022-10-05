using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class OrderItemsDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int OrderId { get; set; }
        public String Description { get; set; }
        public String CreatedUserFullName { get; set; }
        public String OrderName { get; set; }
    }
}
