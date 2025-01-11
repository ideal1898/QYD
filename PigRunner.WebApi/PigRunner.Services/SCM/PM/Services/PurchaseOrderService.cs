using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.SCM.PM;
using PigRunner.Services.SCM.PM.IServices;
using SqlSugar;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.PM.Services
{
    /// <summary>
    /// 采购订单服务
    /// </summary>
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private PurchaseOrderRepository purchaseOrderRepository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public PurchaseOrderService(PurchaseOrderRepository _purchaseOrderRepository, WebSession _session, IMapper _mapper)
        {
            this.purchaseOrderRepository = _purchaseOrderRepository;
            this.session = _session;
            this.mapper = _mapper;
        }
        #region 业务操作
        public ResponseBusBody Save(PurchaseOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                PurchaseOrder purchaseOrder = null;
                if (view.id > 0)
                    purchaseOrder = purchaseOrderRepository.AsQueryable().Includes(item => item.Lines).Where(w => w.ID == view.id).First();

                purchaseOrder = mapper.Map<PurchaseOrder>(view);
                purchaseOrder.Lines.ForEach(item =>
                {
                    if (item.PurchaseOrder == 0)
                        item.PurchaseOrder = purchaseOrder.ID;
                });
                bool flag = false;
                if (view.id == 0)
                    flag = purchaseOrderRepository.Context.InsertNav(purchaseOrder).Include(item => item.Lines,
                            new InsertNavOptions() { OneToManyIfExistsNoInsert = true }).ExecuteCommand();
                else
                    flag = purchaseOrderRepository.Context.UpdateNav(purchaseOrder).Include(item => item.Lines, new UpdateNavOptions() { OneToManyInsertOrUpdate = true }).ExecuteCommand();

                //重新查询单据
                purchaseOrder = purchaseOrderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Supplier)
                    .Includes(item => item.Currency)
                    .Includes(item => item.Lines, line => line.Item).Where(item => item.ID == purchaseOrder.ID).First();
                //将实体转化成View
                var vo = mapper.Map<PurchaseOrderView>(purchaseOrder);
                stopwatch.Stop();
                response.code = flag ? 200 : 401;
                response.data = JObject.FromObject(vo);
                response.msg = $"采购订单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                response.code = 401;
                response.msg = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// 根据ID查询采购订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryItemById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var purchaseOrder = purchaseOrderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Supplier)
                    .Includes(item => item.Currency)
                    .Includes(item => item.Lines,line=>line.Item).Where(item => item.ID == id);
                var view = mapper.Map<PurchaseOrderView>(purchaseOrder.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购订单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 401;
                response.msg = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ResponseBusBody Delete(List<long> ids)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                purchaseOrderRepository.BeginTran();
                foreach (long id in ids)
                    purchaseOrderRepository.Context.DeleteNav<PurchaseOrder>(item => item.ID == id).Include(item => item.Lines).ExecuteCommand();

                purchaseOrderRepository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"成功删除：{ids.Count}条记录,执行耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                purchaseOrderRepository.RollbackTran();
                response.code = 401;
                response.msg = ex.Message;
            }

            return response;

        }
        #endregion

        #region 查询
        public ResponseBody QueryAllByPage(string Where, int PageSize, int Current, ref int Total)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
