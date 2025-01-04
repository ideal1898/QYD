using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class TransferLineService :ITransferLineService
    {
        private readonly IMapper mapper;
        private TransferLineRepository TransferLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_TransferLineRepository"></param>
        public TransferLineService(IMapper _mapper, TransferLineRepository _TransferLineRepository)
        {
            this.mapper = _mapper;
            this.TransferLineRepository = _TransferLineRepository;
        }
        
        public ResponseBody QueryTransferLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<TransferLine> ldatas= TransferLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            TransferLineView[] list = mapper.Map<TransferLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertTransferLine(TransferLineView view)
        {
            TransferLine ldatas = mapper.Map<TransferLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return TransferLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}