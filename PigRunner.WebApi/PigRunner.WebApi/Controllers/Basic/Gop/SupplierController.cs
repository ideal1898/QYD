﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.WebApi.Controllers.Basic.Gop
{
      /// <summary>
      /// 供应商
      /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public SupplierController(ISupplierService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionSupplier([FromBody] SupplierView request)
        {
            return services.ActionSupplier(request);
        }

        /// <summary>
        /// 上传供应商
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadSupplier([FromBody] IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadSupplier(stream);
                }
            }
            catch (Exception ex)
            {
                response.code = 400;
                response.msg = ex.Message;
            }
            return response;
        }
    }
}
