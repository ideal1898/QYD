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
    /// <summary>
    /// 姓名格式服务
    /// </summary>
    public class NameFormatService : INameFormatService
    {
        private NameFormatRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public NameFormatService(NameFormatRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 姓名格式
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionNameFormat(EnumView request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                //预留后续有新增，修改接口操作
                if (string.IsNullOrEmpty(request.optType))
                    throw new Exception("操作类型不能为空！");
                if (request.optType == "QueryNameFormat")
                {
                    List<EnumView> list = new List<EnumView>();
                    if (!string.IsNullOrEmpty(request.value))
                    {
                        NameFormat item = repository.GetFirst(q => q.ID.ToString() == request.value);
                        if (item == null)
                            throw new Exception(string.Format("ID为【{0}】的姓名格式不存在！", request.value));
                        EnumView dto = new EnumView();
                        dto.value = item.ID.ToString();
                        dto.label = item.Name;
                        list.Add(dto);
                    }
                    else
                    {
                        var lst = repository.Context.Queryable<NameFormat>().ToList();
                        foreach (var item in lst)
                        {
                            EnumView dto = new EnumView();
                            dto.value = item.ID.ToString();
                            dto.label = item.Name;
                            list.Add(dto);
                        }
                    }
                    response.data = JArray.FromObject(list);
                }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }
    }
}
