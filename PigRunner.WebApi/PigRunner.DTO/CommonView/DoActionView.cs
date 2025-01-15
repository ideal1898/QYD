using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.CommonView
{
    /// <summary>
    /// 公共业务处理：提交，审核，弃审，关闭
    /// </summary>
    public class DoActionView
    {
        public long id { get; set; }
        public long SysVersion { get; set; }
    }
}
