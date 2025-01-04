using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class WhbinAdjustLineService :IWhbinAdjustLineService
    {
        private readonly IMapper mapper;
        private WhbinAdjustLineRepository WhbinAdjustLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_WhbinAdjustLineRepository"></param>
        public WhbinAdjustLineService(IMapper _mapper, WhbinAdjustLineRepository _WhbinAdjustLineRepository)
        {
            this.mapper = _mapper;
            this.WhbinAdjustLineRepository = _WhbinAdjustLineRepository;
        }
        
        public ResponseBody QueryWhbinAdjustLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<WhbinAdjustLine> ldatas= WhbinAdjustLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            WhbinAdjustLineView[] list = mapper.Map<WhbinAdjustLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertWhbinAdjustLine(WhbinAdjustLineView view)
        {
            WhbinAdjustLine ldatas = mapper.Map<WhbinAdjustLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return WhbinAdjustLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}