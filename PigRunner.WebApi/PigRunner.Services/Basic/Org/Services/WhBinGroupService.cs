using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Services
{

    public class WhBinGroupService : IWhBinGroupService
    {
        /// <summary>
        /// 备  注:库区
        ///</summary>


        private WhBinGroupRepository repository;
        
        /// <summary>
        /// 服务
        /// </summary>
        /// <param  name="_lotMasterRepository"></param>
        
        public WhBinGroupService(WhBinGroupRepository _repository)
        {
            this.repository = _repository;
        }
        
        
        
        /// <summary>
        /// 增删改查
        /// </summary>
        /// <param  name="request"></param>
        /// <returns></returns>

        
       public PubResponse ActionWhBinGroup(WhBinGroupVo request)
       {
           PubResponse response = new PubResponse();
           try
           {
                ///<summar>
                ///新增/修改
                /// </summar>
               if (request.OptType == 0 || request.OptType == 1)
               {
                   
               }
               else if (request.OptType == 2)
               {
                   
               }
               else if (request.OptType == 3)
               {
                   
               }
           }
           catch (Exception ex)
           {
               response.msg = ex.Message;
           }
           return response;
       }
           
       }

    }
    
