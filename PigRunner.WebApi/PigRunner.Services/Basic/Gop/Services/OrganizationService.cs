using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Helpers;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;

namespace PigRunner.Services.Basic.Services
{
     /// <summary>
     /// 国家
     /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private OrganizationRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public OrganizationService(OrganizationRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 组织增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionOrganization(OrganizationView request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (request.OptType.Equals("AddOrganization") || request.OptType.Equals("UpdateOrganization"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    Organization head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddOrganization"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的组织已存在，不能再新增！", request.Code));
                        else
                        {
                            head = Organization.Create();
                            head.ID = IdGeneratorHelper.GetNextId();
                        }
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的组织不存在，请检查！", request.ID));
                    }
                    head.Code = request.Code;
                    head.Name = request.Name;
                    head.Shortname = request.Shortname;
                    head.DefaultLanguage = request.DefaultLanguage;
                    head.IsEffective = request.IsEffective;
                    head.CCBL = request.CCBL;
                    head.Contacts = request.Contacts;
                    head.Location = request.Location;
                    head.RegisterAddress = request.RegisterAddress;

                    response.id = head.ID;

                    response.id = head.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("组织新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelOrganization"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Organization head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的组织不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Organization head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的组织不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryOrganization"))
                {
                    int total = 0;
                    List<OrganizationView> list = new List<OrganizationView>();
                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);

                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);

                    var lst = repository.AsQueryable().Where(sql).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 10;
                        foreach (var item in lst)
                        {
                            OrganizationView dto = SetValue(item);
                            dto.LineNum = lineNum;
                            list.Add(dto);
                            lineNum += 10;
                        }
                    }
                    response.data = JArray.FromObject(list);
                    response.total = total;
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

        private OrganizationView SetValue(Organization item)
        {
            OrganizationView dto = new OrganizationView();
            dto.OptType = "UpdateOrganization";
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.ID = item.ID;
            dto.DefaultLanguage = item.DefaultLanguage;
            var lg = repository.Context.Queryable<Language>().Where(q => q.ID == dto.DefaultLanguage)?.First();
            if (lg != null)
                dto.DefaultLanguageName = lg.Name;
            dto.IsEffective = item.IsEffective;
            dto.Location= item.Location;
            dto.RegisterAddress= item.RegisterAddress;
            dto.CCBL=item.CCBL;
            dto.Contacts=item.Contacts;
            dto.Shortname=item.Shortname;

            return dto;
        }

    }
}
