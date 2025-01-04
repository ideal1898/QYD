using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class WhbinAdjustService :IWhbinAdjustService
    {
        private readonly IMapper mapper;
        private WhbinAdjustRepository WhbinAdjustRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_WhbinAdjustRepository"></param>
        public WhbinAdjustService(IMapper _mapper, WhbinAdjustRepository _WhbinAdjustRepository)
        {
            this.mapper = _mapper;
            this.WhbinAdjustRepository = _WhbinAdjustRepository;
        }
        
        public ResponseBody QueryWhbinAdjust(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<WhbinAdjust> ldatas= WhbinAdjustRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            WhbinAdjustView[] list = mapper.Map<WhbinAdjustView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertWhbinAdjust(WhbinAdjustView view)
        {
            WhbinAdjust ldatas = mapper.Map<WhbinAdjust>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return WhbinAdjustRepository.InsertOrUpdate(ldatas);


        }

    }
    
}