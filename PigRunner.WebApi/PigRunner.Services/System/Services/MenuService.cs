using PigRunner.DTO.Basic;
using PigRunner.DTO.System;
using PigRunner.Entitys.System;
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
        }
    }
}
