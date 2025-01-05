using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic.Gop;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.Services.Basic.Gop.Services
{
    public class ProjectService : IProjectService
    {
        private ProjectRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public ProjectService(ProjectRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 项目增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionProject(ProjectView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddProject") || request.OptType.Equals("UpdateProject"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    Project head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddProject"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的项目已存在，不能再新增！", request.Code));
                        else
                            head = Project.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的项目不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    Project oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的项目已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Description = request.Description;

                    head.Status = request.Status;

                    DateTime AcceptDate = DateTime.MinValue;
                    if (!string.IsNullOrEmpty(request.AcceptDate))
                        DateTime.TryParse(request.AcceptDate, out AcceptDate);

                    DateTime QAExpireDate = DateTime.MinValue;
                    if (!string.IsNullOrEmpty(request.QAExpireDate))
                        DateTime.TryParse(request.QAExpireDate, out QAExpireDate);
                    if (AcceptDate != DateTime.MinValue)
                        head.AcceptDate = AcceptDate;
                    if (QAExpireDate != DateTime.MinValue)
                        head.QAExpireDate = QAExpireDate;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("项目新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelProject"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Project head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的项目不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Project head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的项目不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryProject"))
                {
                    int total = 0;
                    List<ProjectView> list = new List<ProjectView>();
                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);

                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);

                    var lst = repository.AsQueryable().Where(sql).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            ProjectView dto = SetValue(item);
                            dto.LineNum = lineNum;
                            list.Add(dto);
                            lineNum += 1;
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

        private ProjectView SetValue(Project item)
        {
            ProjectView dto = new ProjectView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Description = item.Description;
            dto.ID = item.ID;
            dto.Status = item.Status;
            if (dto.Status == 1)
                dto.StatusName = "立项";
            else if (dto.Status == 2)
                dto.StatusName = "进行中";
            else if (dto.Status == 3)
                dto.StatusName = "暂停";
            else if (dto.Status == 4)
                dto.StatusName = "验收";
            if (item.QAExpireDate != DateTime.MinValue)
                dto.QAExpireDate = item.QAExpireDate.ToString("yyyy-MM-dd");
            if (item.AcceptDate != DateTime.MinValue)
                dto.AcceptDate = item.AcceptDate.ToString("yyyy-MM-dd");

            return dto;
        }

        public PubResponse UploadProject(MemoryStream stream)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    if (package.Workbook == null || package.Workbook.Worksheets == null || package.Workbook.Worksheets.Count <= 0)
                        throw new Exception("Excel内容不能为空！");
                    var lst = package.Workbook.Worksheets.Cast<ExcelWorksheet>().Where(q => q.Dimension != null).ToList();
                    if (lst == null || lst.Count <= 0)
                        throw new Exception("Excel的sheet内容不能为空！");
                    List<Project> lstCtry = new List<Project>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！", worksheet.Name));
                        if (columnCount < 5)
                            throw new Exception(string.Format("Sheet[{0}]数据列不能为空！", worksheet.Name));

                        for (int row = 2; row <= rowCount; row++)
                        {

                            //第1列：编码
                            string Code = string.Empty;
                            if (worksheet.GetValue(row, 1) != null)
                                Code = worksheet.GetValue(row, 1).ToString();
                            //第2列：名称
                            string Name = string.Empty;
                            if (worksheet.GetValue(row, 2) != null)
                                Name = worksheet.GetValue(row, 2).ToString();

                            //第3列：描述
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                Remark = worksheet.GetValue(row, 3).ToString();


                            //第4列：状态
                            int RoundWay = 0;
                            if (worksheet.GetValue(row, 4) != null)
                            {
                                string RtName = worksheet.GetValue(row, 4).ToString();
                                if (RtName.Equals("立项"))
                                    RoundWay = 1;
                                else if (RtName.Equals("进行中"))
                                    RoundWay = 2;
                                else if (RtName.Equals("暂停"))
                                    RoundWay = 3;
                                else if (RtName.Equals("验收"))
                                    RoundWay = 4;
                            }
                            //第5列：验收日期
                            DateTime AcceptDate = DateTime.MinValue;
                            if (worksheet.GetValue(row, 5) != null)
                                DateTime.TryParse(worksheet.GetValue(row, 5).ToString(), out AcceptDate);

                            //第6列：验收日期
                            DateTime QAExpireDate = DateTime.MinValue;
                            if (worksheet.GetValue(row, 6) != null)
                                DateTime.TryParse(worksheet.GetValue(row, 6).ToString(), out QAExpireDate);

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Project head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的项目已存在！", Code));
                            head = Project.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.Description = Remark;
                            head.Status = RoundWay;
                            if (AcceptDate != DateTime.MinValue)
                                head.AcceptDate = AcceptDate;
                            if (QAExpireDate != DateTime.MinValue)
                                head.QAExpireDate = QAExpireDate;
                            lstCtry.Add(head);
                        }
                    }
                    int rtn = repository.Context.Insertable(lstCtry).ExecuteCommand();
                    if (rtn != lstCtry.Count)
                        throw new Exception("写入数据失败！");
                }
                response.code = 200;
                response.success = true;
                response.msg = "导入成功！";
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
