using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class MiscShipService :IMiscShipService
    {
        private readonly IMapper mapper;
        private MiscShipRepository MiscShipRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_MiscShipRepository"></param>
        public MiscShipService(IMapper _mapper, MiscShipRepository _MiscShipRepository)
        {
            this.mapper = _mapper;
            this.MiscShipRepository = _MiscShipRepository;
        }
        
        public ResponseBody QueryMiscShip(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<MiscShip> ldatas= MiscShipRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            MiscShipView[] list = mapper.Map<MiscShipView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertMiscShip(MiscShipView view)
        {
            MiscShip ldatas = mapper.Map<MiscShip>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return MiscShipRepository.InsertOrUpdate(ldatas);


        }

    }
    
}