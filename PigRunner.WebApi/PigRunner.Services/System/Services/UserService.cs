using PigRunner.Entitys.System;
using PigRunner.Repository.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
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
        public void Save(SysUser sysUser)
        {
            _repository.Save(sysUser);
        }
    }
}
