using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class WhInitLineService :IWhInitLineService
    {
        private readonly IMapper mapper;
        private WhInitLineRepository WhInitLineRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_WhInitLineRepository"></param>
        public WhInitLineService(IMapper _mapper, WhInitLineRepository _WhInitLineRepository)
        {
            this.mapper = _mapper;
            this.WhInitLineRepository = _WhInitLineRepository;
        }
        
        public ResponseBody QueryWhInitLine(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<WhInitLine> ldatas= WhInitLineRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            WhInitLineView[] list = mapper.Map<WhInitLineView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertWhInitLine(WhInitLineView view)
        {
            WhInitLine ldatas = mapper.Map<WhInitLine>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return WhInitLineRepository.InsertOrUpdate(ldatas);


        }

    }
    
}