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
    /// 采购退货申请单服务
    /// </summary>
    public class RtnRequestService:IRtnRequestService
    {
        private ReturnRequisitionRepository repository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public RtnRequestService(ReturnRequisitionRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        public ResponseBusBody Approve(ReturnRequisitionView view)
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

        public ResponseBusBody Save(ReturnRequisitionView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody Submit(ReturnRequisitionView view)
        {
            throw new NotImplementedException();
        }

        public ResponseBusBody UnApprove(ReturnRequisitionView view)
        {
            throw new NotImplementedException();
        }
    }
}
