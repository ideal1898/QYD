using PigRunner.Public.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Abstract
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity<T>
    {

        public static T Create()
        {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo? idInfo = typeof(T).GetProperty("Id");
            idInfo?.SetValue(instance, IdGeneratorHelper.GetNextId());

            PropertyInfo? ctime = typeof(T).GetProperty("CreatedTime");
            ctime?.SetValue(instance, DateTime.Now);

            return instance;
        }
    }
}
