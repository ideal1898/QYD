using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class MiscRcvTransLineService :IMiscRcvTransLineService
    {
        private readonly IMapper mapper;
        private MiscRcvTransLineRepository MiscRcvTransLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_MiscRcvTransLineRepository"></param>
        public MiscRcvTransLineService(IMapper _mapper, MiscRcvTransLineRepository _MiscRcvTransLineRepository)
        {
            this.mapper = _mapper;
            this.MiscRcvTransLineRepository = _MiscRcvTransLineRepository;
        }
        
        public ResponseBody QueryMiscRcvTransLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<MiscRcvTransLine> ldatas= MiscRcvTransLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            MiscRcvTransLineView[] list = mapper.Map<MiscRcvTransLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertMiscRcvTransLine(MiscRcvTransLineView view)
        {
            MiscRcvTransLine ldatas = mapper.Map<MiscRcvTransLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return MiscRcvTransLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}