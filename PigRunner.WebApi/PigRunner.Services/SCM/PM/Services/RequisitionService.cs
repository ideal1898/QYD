using AutoMapper;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.SCM.PM;
using PigRunner.Services.SCM.PM.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.PM.Services
{
    /// <summary>
    /// 请购单服务
    /// </summary>
    public class RequisitionService:IRequisitionService
    {
        private RequisitionRepository repository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public RequisitionService(RequisitionRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        public ResponseBusBody Approve(RequisitionView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBody BatchApprove(List<DoActionView> views)
        {
            throw new NotImplementedException();
        }

        public ResponseBody BatchSubmit(List<DoActionView> views)
        {
            throw new NotImplementedException();
        }

        public ResponseBody BatchUnApprove(List<DoActionView> views)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody Delete(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public ResponseBody QueryAllByPage(PageView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody QueryDocById(long id)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody Save(RequisitionView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody Submit(RequisitionView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody UnApprove(RequisitionView view)
        {
            throw new NotImplementedException();
        }
    }
}
