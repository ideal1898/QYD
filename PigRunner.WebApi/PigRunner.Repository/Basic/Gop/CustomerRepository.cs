using PigRunner.Entitys.Basic;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.Basic.Gop
{
    /// <summary>
    /// 客户存储
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>, IScopedService
    {
    }
}
