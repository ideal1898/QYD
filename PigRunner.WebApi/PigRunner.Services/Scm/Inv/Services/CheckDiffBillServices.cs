using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;


namespace PigRunner.Services.Scm.Inv.Services
{

    public class CheckDiffBillService : ICheckDiffBillService
    {
        private readonly IMapper mapper;
        private CheckDiffBillRepository CheckDiffBillRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_CheckDiffBillRepository"></param>
        public CheckDiffBillService(IMapper _mapper, CheckDiffBillRepository _CheckDiffBillRepository)
        {
            this.mapper = _mapper;
            this.CheckDiffBillRepository = _CheckDiffBillRepository;
        }
        
        public ResponseBody QueryCheckDiffBill(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<CheckDiffBill> ldatas= CheckDiffBillRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            CheckDiffBillView[] list = mapper.Map<CheckDiffBillView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertCheckDiffBill(CheckDiffBillView view)
        {
            CheckDiffBill ldatas = mapper.Map<CheckDiffBill>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return CheckDiffBillRepository.InsertOrUpdate(ldatas);


        }

    }
    
}