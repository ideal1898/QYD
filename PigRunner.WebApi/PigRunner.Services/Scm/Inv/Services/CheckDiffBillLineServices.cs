using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class CheckDiffBillLineService :ICheckDiffBillLineService
    {
        private readonly IMapper mapper;
        private CheckDiffBillLineRepository CheckDiffBillLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_CheckDiffBillLineRepository"></param>
        public CheckDiffBillLineService(IMapper _mapper, CheckDiffBillLineRepository _CheckDiffBillLineRepository)
        {
            this.mapper = _mapper;
            this.CheckDiffBillLineRepository = _CheckDiffBillLineRepository;
        }
        
        public ResponseBody QueryCheckDiffBillLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<CheckDiffBillLine> ldatas= CheckDiffBillLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            CheckDiffBillLineView[] list = mapper.Map<CheckDiffBillLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertCheckDiffBillLine(CheckDiffBillLineView view)
        {
            CheckDiffBillLine ldatas = mapper.Map<CheckDiffBillLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return CheckDiffBillLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}