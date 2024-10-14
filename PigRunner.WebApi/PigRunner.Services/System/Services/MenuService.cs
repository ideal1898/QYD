<<<<<<< HEAD
﻿using PigRunner.DTO.Basic;
using PigRunner.DTO.System;
using PigRunner.Entitys.System;
=======
﻿using Newtonsoft.Json.Linq;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
>>>>>>> a149554f9ed18021995679a41f34d6e12be7a8fa
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
        public bool Save(MenuVo vo)
        {
            SysMenu sysMenu = null;
            if(vo.id==0)
               sysMenu = SysMenu.Create();
            else
                sysMenu=menuRepository.GetById(vo.id);

<<<<<<< HEAD
            sysMenu.Path = vo.path;// 
            sysMenu.Name =vo.name;// 组建名称
            sysMenu.Component = vo.component;//--组件
            sysMenu.Redirect = vo.redirect;//定向 
            sysMenu.IsActive = vo.isActive?1:0;//--生效
            sysMenu.Icon =vo.icon;//--图标
            sysMenu.Title = vo.title;// --标题
            sysMenu.IsLink = vo.isLink;// 外部连接
            sysMenu.IsHide = vo.isHide?1:0;//显示
            sysMenu.IsFull = vo.isFull?1:0;//全屏
            sysMenu.IsAffix =vo.isAffix?1:0;//固钉
            sysMenu.IsKeepAlive = vo.isKeepAlive?1:0;//--缓存
            sysMenu.Parent =vo.parent ;
            return menuRepository.InsertOrUpdate(sysMenu);
=======
            return menuRepository.Save(s);
>>>>>>> a149554f9ed18021995679a41f34d6e12be7a8fa
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
