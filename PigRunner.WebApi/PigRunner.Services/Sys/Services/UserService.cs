using PigRunner.Entitys.Sys;
using PigRunner.Repository.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Sys
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserService : IUserService
    {
        private UserRepository _repository;
        public UserService(UserRepository repository) {
        this._repository = repository;
        }

        public SysUser GetSysUser(string username, string pwd)
        {
            return _repository.GetSysUser(username,pwd);
        }

        public void Save(SysUser sysUser)
        {
            _repository.Save(sysUser);
        }
    }
}
