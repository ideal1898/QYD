using PigRunner.Entitys.Basic;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.Basic
{
    /// <summary>
    /// 国家
    /// </summary>
    public class CountryRepository : BaseRepository<Country>, IScopedService
    {
    }
}
