using Yitter.IdGenerator;

namespace PigRunner.Public.Helpers
{
    /// <summary>
    /// ID 生成器
    /// </summary>
    public static class IdGeneratorHelper
    {
        /// <summary>
        /// 获取全局Id
        /// </summary>
        /// <returns></returns>
        public static long GetNextId()
        {
            var idGeneratorOptions = new IdGeneratorOptions(1) { WorkerIdBitLength = 6 };
            // 保存参数（务必调用，否则参数设置不生效）：  
            YitIdHelper.SetIdGenerator(idGeneratorOptions);
            // 以上过程只需全局一次，且应在生成ID之前完成。  

            return YitIdHelper.NextId();
        }
    }
}
