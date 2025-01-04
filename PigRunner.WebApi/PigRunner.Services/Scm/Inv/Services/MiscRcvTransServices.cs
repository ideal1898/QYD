using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class MiscRcvTransService :IMiscRcvTransService
    {
        private readonly IMapper mapper;
        private MiscRcvTransRepository MiscRcvTransRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_MiscRcvTransRepository"></param>
        public MiscRcvTransService(IMapper _mapper, MiscRcvTransRepository _MiscRcvTransRepository)
        {
            this.mapper = _mapper;
            this.MiscRcvTransRepository = _MiscRcvTransRepository;
        }
        
        public ResponseBody QueryMiscRcvTrans(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<MiscRcvTrans> ldatas= MiscRcvTransRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            MiscRcvTransView[] list = mapper.Map<MiscRcvTransView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertMiscRcvTrans(MiscRcvTransView view)
        {
            MiscRcvTrans ldatas = mapper.Map<MiscRcvTrans>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return MiscRcvTransRepository.InsertOrUpdate(ldatas);


        }

    }
    
}