using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository
{
    /// <summary>
    /// 集成数据仓库
    /// </summary>
     public class BaseRepository<T> : SimpleClient<T> where T : class, new()
    //public class BaseRepository<T> : SqlSugarClient<T> where T : class, new()
    {
        /// <summary>
        /// 构造函数注册连接
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(ISqlSugarClient? context = null) : base(context)
        {
            Context = DbScoped.SugarScope;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTran()
        {
            AsTenant().BeginTran();
            
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTran()
        {
            AsTenant().CommitTran();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTran()
        {
            AsTenant().RollbackTran();
        }
    }
}
