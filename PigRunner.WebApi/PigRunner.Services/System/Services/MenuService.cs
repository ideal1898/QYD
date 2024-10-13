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
                string jsonFilePath = "D:/Wordfolder/Personal/PlatForm/WebServer/menudata.json";
                string jsonString = File.ReadAllText(jsonFilePath);
                rtn.Success = true;
                rtn.Data = jsonString;
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
            }
            

            

            return rtn;
        }

    }
}
