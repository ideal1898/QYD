using PigRunner.DTO.Scm.Inv;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Scm.Inv;
using AutoMapper;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Scm.Inv;
using PigRunner.Services.Scm.Inv.IServices;

namespace Services.Scm.Inv.Services
{

    public class WhInitService :IWhInitService
    {
        private readonly IMapper mapper;
        private WhInitRepository WhInitRepository;
        
        
        /// <summary>
        /// 服务注册
        /// </summary>
        
        /// <param name="_mapper"></param>
        /// <param name="_WhInitRepository"></param>
        public WhInitService(IMapper _mapper, WhInitRepository _WhInitRepository)
        {
            this.mapper = _mapper;
            this.WhInitRepository = _WhInitRepository;
        }
        
        public ResponseBody QueryWhInit(int current, int size)
        {
            ResponseBody body = new ResponseBody();

            int total = 0;

            List<WhInit> ldatas= WhInitRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            WhInitView[] list = mapper.Map<WhInitView[]>(ldatas);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            
            return body;
        }
        public bool InsertWhInit(WhInitView view)
        {
            WhInit ldatas = mapper.Map<WhInit>(view);

            //store.ID = IdGeneratorHelper.GetNextId();
            return WhInitRepository.InsertOrUpdate(ldatas);


        }

    }
    
}