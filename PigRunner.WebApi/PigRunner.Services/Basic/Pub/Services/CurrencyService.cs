using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using SqlSugar;
using System.Diagnostics;

namespace PigRunner.Services.Basic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private CurrencyRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public CurrencyService(CurrencyRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 币种
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionCurrency(EnumView request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                //预留后续有新增，修改接口操作
                if (string.IsNullOrEmpty(request.optType))
                    throw new Exception("操作类型不能为空！");
                if (request.optType == "QueryCurrency")
                {
                    List<EnumView> list = new List<EnumView>();
                    if (!string.IsNullOrEmpty(request.value))
                    {
                        Currency item = repository.GetFirst(q => q.ID.ToString() == request.value);
                        if (item == null)
                            throw new Exception(string.Format("ID为【{0}】的币种不存在！", request.value));
                        EnumView dto = new EnumView();
                        dto.value = item.ID.ToString();
                        dto.label = item.Name;
                        list.Add(dto);
                    }
                    else
                    {
                        var lst = repository.Context.Queryable<Currency>().ToList();
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

        public PubResponse QueryAllCurrency()
        {
            PubResponse response = new PubResponse();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                int total = 0;
                var docs = repository.Context.Queryable<Currency>()
                    .OrderBy(item => item.ID, OrderByType.Asc).Select(item => new {value=item.ID,label=item.Name });        
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"请购明细查询完成，共计{total}条记录，耗时：{total}";
                response.data = JArray.FromObject(docs.ToArray());
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }
    }
}
