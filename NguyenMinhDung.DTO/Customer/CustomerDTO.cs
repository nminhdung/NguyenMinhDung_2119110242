using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenMinhDung.DTO.Customer
{
    public class CustomerDTO
    {
        public string MaKh { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Owe { get; set; }

        public string Category { get; set; }
      
    }
}
