using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class TransferFormLineService :ITransferFormLineService
    {
        private readonly IMapper mapper;
        private TransferFormLineRepository TransferFormLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_TransferFormLineRepository"></param>
        public TransferFormLineService(IMapper _mapper, TransferFormLineRepository _TransferFormLineRepository)
        {
            this.mapper = _mapper;
            this.TransferFormLineRepository = _TransferFormLineRepository;
        }
        
        public ResponseBody QueryTransferFormLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<TransferFormLine> ldatas= TransferFormLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            TransferFormLineView[] list = mapper.Map<TransferFormLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertTransferFormLine(TransferFormLineView view)
        {
            TransferFormLine ldatas = mapper.Map<TransferFormLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return TransferFormLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}