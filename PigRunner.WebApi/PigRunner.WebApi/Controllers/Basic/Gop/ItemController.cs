using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Services.Basic.IServices;


namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 料品服务
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemService itemService;
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="_itemService"></param>
        public ItemController(IItemService _itemService) { 
        this.itemService = _itemService;
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPost]
        public string Add([FromBody]ItemVo vo) {
            itemService.Add(vo);
            return "创建成功";
        }
    }
}
