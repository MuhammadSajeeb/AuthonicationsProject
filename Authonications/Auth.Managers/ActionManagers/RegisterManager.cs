using Auth.Core.Models;
using Auth.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Managers.ActionManagers
{
    public class RegisterManager
    {
        private RegisterRepository _RegisterRepository = new RegisterRepository();

        public decimal AlreadyExsitUserName(Registers _Registers)
        {
            return _RegisterRepository.AlreadyExsitEmail(_Registers);
        }
        public decimal AlreadyExsitEmail(Registers _Registers)
        {
            return _RegisterRepository.AlreadyExsitEmail(_Registers);
        }
        public int Register(Registers _Registers)
        {
            return _RegisterRepository.Register(_Registers);
        }
    }
}
