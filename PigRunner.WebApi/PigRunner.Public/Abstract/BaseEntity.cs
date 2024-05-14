using PigRunner.Public.Helpers;
using SqlSugar;
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
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public long id { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? createdDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string? createdBy { get; set; }
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
