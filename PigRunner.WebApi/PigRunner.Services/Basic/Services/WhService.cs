using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Services
{

    public class WhService : IWhService
    {
        /// <summary>
        /// 备  注:仓库
        ///</summary>


        private WhRepository repository;
        
        /// <summary>
        /// 服务
        /// </summary>
        /// <param  name="_lotMasterRepository"></param>
        
        public WhService(WhRepository _repository)
        {
            this.repository = _repository;
        }
        
        
        
        /// <summary>
        /// 增删改查
        /// </summary>
        /// <param  name="request"></param>
        /// <returns></returns>

        
       public PubResponse ActionWh(WhVo request)
       {
           PubResponse response = new PubResponse();
           try
           {
                ///<summar>
                ///新增/修改
                /// </summar>
               if (request.OptType == 0 || request.OptType == 1)
               {
                    if (string.IsNullOrEmpty(request.Code))
                    {
                        throw new Exception("0编码不能为空");
                    }
                    Wh Head = repository.GetFirst(q => q.Code == request.Code);
                    if (Head == null)
                        {
                            Head = Wh.Create();
                            Head.Code = request.Code;
                            Head.Name = request.Name;
                            Head.Supplier = request.Supplier;
                            Head.IsEffective = request.IsEffective;
                            Head.Address = request.Address;
                            Head.Area = request.Area;
                            Head.Volume = request.Volume;
                            Head.IsEffective = request.IsEffective;
                            response.id = Head.ID;

                            
                        }
                    bool isSuccess = repository.InsertOrUpdate(Head);
                    if (!isSuccess)
                    {
                        throw new Exception("0仓库新增/修改失败");
                    }
                }
               
               else if (request.OptType == 2)
               {
                    if (string.IsNullOrEmpty(request.Code))
                    {
                        throw new Exception("2编码不能为空");
                        Wh Head = repository.GetFirst(q => q.Code == request.Code);
                        if (Head == null)
                        {
                            throw new Exception(string.Format("2编码为[0]不存在", request.Code));
                        }
                        else 
                        {
                            bool isSuccess = repository.Delete(Head);

                            if (!isSuccess)
                            {
                                throw new Exception("2删除失败！");
                            }
                        }
                    }                  
               }
               else if (request.OptType == 3)
               {
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Wh Head = repository.GetFirst(q => q.Code == request.Code);
                        if (Head == null)
                        {
                            throw new Exception(string.Format("编码【[0]】不存在", request.Code));
                        }
                        else
                        {
                            List<Wh> list = new List<Wh>();
                            list.Add(Head);

                            response.data = JArray.FromObject(list);
                        }
                    }
                    else 
                    {
                        var lst = repository.Context.Queryable<Wh>().ToList();
                        response.data =JArray.FromObject(lst);
                        //Console.WriteLine(response.data);
                    }
                   
               }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";

           }
            
           catch (Exception ex)
           {
               response.msg = ex.Message;
           }
           return response;
       }
           
       }

    }
    
