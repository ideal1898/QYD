using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class TransferFormService :ITransferFormService
    {
        private readonly IMapper mapper;
        private TransferFormRepository TransferFormRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_TransferFormRepository"></param>
        public TransferFormService(IMapper _mapper, TransferFormRepository _TransferFormRepository)
        {
            this.mapper = _mapper;
            this.TransferFormRepository = _TransferFormRepository;
        }
        
        public ResponseBody QueryTransferForm(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<TransferForm> ldatas= TransferFormRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            TransferFormView[] list = mapper.Map<TransferFormView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertTransferForm(TransferFormView view)
        {
            TransferForm ldatas = mapper.Map<TransferForm>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return TransferFormRepository.InsertOrUpdate(ldatas);


        }

    }
    
}