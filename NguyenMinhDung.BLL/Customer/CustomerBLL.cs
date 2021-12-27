
using NguyenMinhDung.DAO.Customer;
using NguyenMinhDung.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenMinhDung.BLL.Customer
{
   public class CustomerBLL
    {
        CustomerDAO dao = new CustomerDAO();
        public List<CustomerDTO> ReadCustomer()
        {
            List<CustomerDTO> lstCus = dao.ReadCustomer();
            return lstCus;
        }
        public void DeleteCustomer(CustomerDTO cus)
        {
            dao.DeleteCustomer(cus);
        }
        public void AddCustomer(CustomerDTO cus)
        {
            dao.AddCustomer(cus);
        }
        public void RecordCustomer(CustomerDTO cus)
        {
            dao.RecordCustomer(cus);
        }
    }
}
