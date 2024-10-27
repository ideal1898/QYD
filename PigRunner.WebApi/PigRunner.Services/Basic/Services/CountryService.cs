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
    /// 国家
    /// </summary>
    public class CountryService : ICountryService
    {
        private CountryRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public CountryService(CountryRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 国家地区增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionCountry(CountryVo request)
        {
            PubResponse response = new PubResponse();

            try
            {
               

                if (request.OptType == 0|| request.OptType == 1)
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    Country head = repository.GetFirst(q => q.Code == request.Code);
                    if (head == null)
                        head = Country.Create();
                    head.Code = request.Code;
                    head.Name = request.Name;
                    head.CountryFormat = request.CountryFormat;
                    head.Currency = request.Currency;
                    head.Language = request.Language;
                    head.NameFormat = request.NameFormat;
                    head.TimeZone = request.TimeZone;
                    response.id = head.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("国家地区新增/修改操作失败！");
                }
                else if (request.OptType == 2)
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    Country head = repository.GetFirst(q => q.Code == request.Code);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));

                    bool isSuccess = repository.Delete(head);
                    if (!isSuccess)
                        throw new Exception("删除失败！");
                }
                else if (request.OptType == 3)
                {
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Country head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));
                        response.data = head;

                    }
                    //else
                    //    var list = repository.GetList(q=>!string.IsNullOrEmpty(q.Code)).FindAll;
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
