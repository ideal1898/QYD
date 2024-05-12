using Newtonsoft.Json;
using StackExchange.Redis;

namespace PigRunner.WebApi.Commons.Helpers
{
    /// <summary>
    /// redis 帮助类（哨兵模式）
    /// </summary>
    public class RedisHelper
    {
        /// <summary>
        /// 懒加载
        /// </summary>
        private static readonly Lazy<RedisHelper> single = new Lazy<RedisHelper>(() => new RedisHelper());

        private ConnectionMultiplexer? RedisConnection;

        private IDatabase Db { get; set; }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static RedisHelper GetInstance()
        {
            if (single.Value.RedisConnection == null || !single.Value.RedisConnection.IsConnected)
            {
                single.Value.Conntect();
            }
            return single.Value;
        }

        /// <summary>
        /// 连接reids
        /// </summary>
        private void Conntect()
        {
            var sentinelOption = new ConfigurationOptions();
            sentinelOption.TieBreaker = "";
            var endPoints = ConfigHelper.GetSections("Redis:endPoints");
            foreach (var point in endPoints)
            {
                sentinelOption.EndPoints.Add(point);
            }
            sentinelOption.CommandMap = CommandMap.Sentinel;
            sentinelOption.AbortOnConnectFail = false;
            var sentinelConnection = ConnectionMultiplexer.Connect(sentinelOption);

            //连接服务器
            var redisServiceOptions = new ConfigurationOptions();
            redisServiceOptions.ServiceName = ConfigHelper.GetSection("Redis:serviceName");
            redisServiceOptions.Password = ConfigHelper.GetSection("Redis:pwd");
            redisServiceOptions.AbortOnConnectFail = true;
            RedisConnection = sentinelConnection.GetSentinelMasterConnection(redisServiceOptions);
            Db = RedisConnection.GetDatabase();
        }

        #region Key/Value

        /// <summary>
        /// 设置key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">过期时间（秒，0则不过期）</param>
        /// <returns></returns>
        public bool SetValue(string key, string value, int timeout = 0)
        {
            TimeSpan? expire = timeout > 0 ? new TimeSpan(0, 0, timeout) : null;
            return Db.StringSet(key, value, expire);
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            var value = Db.StringGet(key);
            if (value == RedisValue.Null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(string key)
        {
            return Db.KeyDelete(key);
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return Db.KeyExists(key);
        }

        /// <summary>
        /// 事务批量删除key
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns></returns>
        public bool DeleteKeyTrans(IEnumerable<string> keyList)
        {
            var trans = Db.CreateTransaction();
            foreach (var item in keyList)
            {
                trans.AddCondition(Condition.KeyExists(item));
            }

            foreach (var item in keyList)
            {
                trans.KeyDeleteAsync(item);
            }

            return trans.Execute();
        }

        #endregion

        #region Hash

        /// <summary>
        /// 设置hash值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="timeout">过期时间（秒，0则不过期）</param>
        /// <returns></returns>
        public bool SetHash(string key, string field, string value, int timeout = 0)
        {
            if (!Db.HashSet(key, field, value))
            {
                return false;
            }
            if (timeout > 0)
            {
                return Db.KeyExpire(key, DateTime.Now.AddSeconds(timeout));
            }
            return true;
        }

        /// <summary>
        /// 获取hash值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GetHashValue(string key, string field)
        {
            var value = Db.HashGet(key, field);
            if (value == RedisValue.Null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteHash(string key, string field)
        {
            return Db.HashDelete(key, field);
        }

        /// <summary>
        /// 判断hash是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HashExists(string key, string field)
        {
            return Db.HashExists(key, field);
        }

        #endregion

        #region List

        /// <summary>
        /// 添加到集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">过期时间（秒，0则不过期）</param>
        /// <returns></returns>
        public bool PushList(string key, string value, int timeout = 0)
        {
            Db.ListRightPush(key, value);
            if (timeout > 0)
            {
                return Db.KeyExpire(key, DateTime.Now.AddSeconds(timeout));
            }
            return true;
        }

        /// <summary>
        /// 批量添加到集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <param name="timeout">过期时间（秒，0则不过期）</param>
        /// <returns></returns>
        public bool BatchPushList(string key, List<string> values, int timeout = 0)
        {
            Db.ListRightPush(key, values.Select(p => new RedisValue(p)).ToArray());
            if (timeout > 0)
            {
                return Db.KeyExpire(key, DateTime.Now.AddSeconds(timeout));
            }
            return true;
        }

        /// <summary>
        /// 批量添加到集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <param name="timeout">过期时间（秒，0则不过期）</param>
        /// <returns></returns>
        public bool BatchPushList<T>(string key, List<T> values, int timeout = 0)
        {
            Db.ListRightPush(key, values.Select(p => new RedisValue(JsonConvert.SerializeObject(p))).ToArray());
            if (timeout > 0)
            {
                return Db.KeyExpire(key, DateTime.Now.AddSeconds(timeout));
            }
            return true;
        }

        /// <summary>
        /// 获取集合中的数据量
        /// 获取集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<string>? GetList(string key)
        {
            var values = Db.ListRange(key);
            if(values == null || values.Length == 0)
            {
                return null;
            }

            return values.Select(a => a.ToString()).ToList();
        }

        /// <summary>
        /// 删除并返回集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<string> DeleteList(string key, int count)
        {
            var elements = Db.ListLeftPop(key, count);
            return elements.Select(a => a.ToString()).ToList();
        }

        /// <summary>
        /// 集合数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long GetListLength(string key)
        {
            return Db.ListLength(key);
        }

        #endregion

        #region Set

        /// <summary>
        /// 获取集合中的数据量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long GetSetLength(string key)
        {
            return Db.SetLength(key);
        }

        #endregion

        #region Other

        /// <summary>
        /// 原子性递增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public long StringIncrement(string key, int timeout = 0)
        {
            var num = Db.StringIncrement(key);
            if (timeout > 0)
            {
                Db.KeyExpire(key, DateTime.Now.AddSeconds(timeout));
            }
            return num;         
        }

        /// <summary>
        /// 是否被锁（并发量小的时候可用）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool IsLock(string key, int timeout = 0)
        {
            TimeSpan? expire = timeout > 0 ? new TimeSpan(0, 0, timeout) : null;
            return !Db.StringSet(key, 1, expire, false, When.NotExists);
        }

        /// <summary>
        /// 分布式加锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool LockTake(string key, string value, int timeout = 60)
        {
            TimeSpan expire = timeout > 0 ? new TimeSpan(0, 0, timeout) : new TimeSpan(0, 0, 60);
            return Db.LockTake(key, value, expire);
        }

        /// <summary>
        /// 分布式解锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LockRelease(string key, string value)
        {
            return Db.LockRelease(key, value);
        }

        #endregion
    }
}
