using Newtonsoft.Json.Linq;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.System;
using PigRunner.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
{
    public class MenuService : IMenuService
    {
        private MenuRepository menuRepository;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_menuRepository"></param>
        public MenuService(MenuRepository _menuRepository)
        {
            menuRepository = _menuRepository;
        }
        public bool Save(SysMenu sysMenu)
        {
            SysMenu s= SysMenu.Create();

            return menuRepository.Save(s);
        }
        public PubResponse GetMenu()
        {
            PubResponse rtn = new PubResponse();
            try
            {
                string jsonFilePath = "E:/DevTools/WebServer/menudata.json";
                var json = File.ReadAllText(jsonFilePath);
                rtn.success = true;
                rtn.code = 200;
                rtn.data = JArray.Parse(json);
            }
            catch (Exception ex)
            {
                rtn.msg = ex.Message;
            }
            return rtn;
        }
    }
}
