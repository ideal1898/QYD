using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class TransferService :ITransferService
    {
        private readonly IMapper mapper;
        private TransferRepository TransferRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_TransferRepository"></param>
        public TransferService(IMapper _mapper, TransferRepository _TransferRepository)
        {
            this.mapper = _mapper;
            this.TransferRepository = _TransferRepository;
        }
        
        public ResponseBody QueryTransfer(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<Transfer> ldatas= TransferRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            TransferView[] list = mapper.Map<TransferView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertTransfer(TransferView view)
        {
            Transfer ldatas = mapper.Map<Transfer>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return TransferRepository.InsertOrUpdate(ldatas);


        }

    }
    
}