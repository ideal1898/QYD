﻿using PigRunner.Public.Helpers;
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
        [SugarColumn(IsPrimaryKey = true, ColumnName = "ID")]
        public long ID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; }
       

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <returns></returns>
        public static T Create()
        {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo? idInfo = typeof(T).GetProperty("ID");
            idInfo?.SetValue(instance, IdGeneratorHelper.GetNextId());

            PropertyInfo? ctime = typeof(T).GetProperty("CreatedTime");
            ctime?.SetValue(instance, DateTime.Now);

            return instance;
        }
    }
}
