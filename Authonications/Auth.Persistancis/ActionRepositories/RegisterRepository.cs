using Auth.Core.Models;
using Auth.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Persistancis.ActionRepositories
{
    public class RegisterRepository
    {
        private MainRepository _MainRepository = new MainRepository();
        public decimal AlreadyExsitUserName(Registers _Registers)
        {
            string query = "Select Count(*)from Registers where UserName='" + _Registers.UserName + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal AlreadyExsitEmail(Registers _Registers)
        {
            string query = "Select Count(*)from Registers where Email='" + _Registers.Email + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Register(Registers _Registers)
        {
            string query = "Insert Into Registers(UserName,Password,Name,Email) Values ('" + _Registers.UserName + "','" + _Registers.Password + "','" + _Registers.Name + "','"+_Registers.Email+"')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public decimal Login(Registers _Registers)
        {
            string query = "Select Count(*)from Registers where UserName='" + _Registers.UserName + "' And Password='"+_Registers.Password+"'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
    }
}
