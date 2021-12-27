using NguyenMinhDung.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NguyenMinhDung.DAO.Customer
{
    public class CustomerDAO : DBConnection
    {
        public List<CustomerDTO> ReadCustomer()
        {
            SqlConnection connect = CreateConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("getAllCustomers", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<CustomerDTO> lstCus = new List<CustomerDTO>();
            while (reader.Read())
            {
                CustomerDTO cus = new CustomerDTO();
                cus.MaKh = reader["makhachhang"].ToString();
                cus.Name = reader["tenkhachhang"].ToString();
                cus.Phone = reader["sodienthoai"].ToString();
                cus.Owe = decimal.Parse(reader["sotienno"].ToString());
                lstCus.Add(cus);
            }
            connect.Close();
            return lstCus;
        }
        public void DeleteCustomer(CustomerDTO cus)
        {
            SqlConnection connect = CreateConnection();
            connect.Open();

            SqlCommand cmd = new SqlCommand("deleteCustomer @makh", connect);
            
            cmd.Parameters.Add(new SqlParameter("@makh", cus.MaKh));
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        public void AddCustomer(CustomerDTO cus)
        {
            SqlConnection connect = CreateConnection();
            connect.Open();
           
            SqlCommand cmd = new SqlCommand("addCustomer @makh,@name,@sodienthoai,@sotienno", connect);
           
            cmd.Parameters.Add(new SqlParameter("@makh", cus.MaKh));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Phone));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Owe));

            cmd.ExecuteNonQuery();
            connect.Close();
        }
        public void RecordCustomer(CustomerDTO cus)
        {
            SqlConnection connect = CreateConnection();
            connect.Open();

            SqlCommand cmd = new SqlCommand("editCustomer @makh,@name,@sodienthoai,@sotienno", connect);
           
            cmd.Parameters.Add(new SqlParameter("@makh", cus.MaKh));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Phone));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Owe));
            //abc
            //abc2
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
