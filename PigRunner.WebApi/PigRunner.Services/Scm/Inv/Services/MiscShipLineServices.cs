using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class MiscShipLineService :IMiscShipLineService
    {
        private readonly IMapper mapper;
        private MiscShipLineRepository MiscShipLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_MiscShipLineRepository"></param>
        public MiscShipLineService(IMapper _mapper, MiscShipLineRepository _MiscShipLineRepository)
        {
            this.mapper = _mapper;
            this.MiscShipLineRepository = _MiscShipLineRepository;
        }
        
        public ResponseBody QueryMiscShipLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<MiscShipLine> ldatas= MiscShipLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            MiscShipLineView[] list = mapper.Map<MiscShipLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertMiscShipLine(MiscShipLineView view)
        {
            MiscShipLine ldatas = mapper.Map<MiscShipLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return MiscShipLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}