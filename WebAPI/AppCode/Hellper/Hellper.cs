using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.AppCode.Hellper
{
    public class Hellpers: IHellper
    {
        public async Task<T> ExecuteProcAsync<T>(string Procname, object param)
        {
            using (SqlConnection conn = new SqlConnection(Config.DBCon))
            {
                return (T)Convert.ChangeType(conn.ExecuteAsync(Procname, param, commandType: CommandType.Text).Result, typeof(T));
            }
        }
        public async Task<T> ExecuteProcAsyncLst<T>(string Procname, object param)
        {
            using (SqlConnection conn = new SqlConnection(Config.DBCon))
            {
                return (T)Convert.ChangeType(conn.QueryFirstAsync(Procname, param, commandType: CommandType.StoredProcedure).Result, typeof(T));
            }
        }
        public async Task<T> GetAsync<T>(string Procname, object param)
        {
            using (SqlConnection conn = new SqlConnection(Config.DBCon))
            {
                var res = conn.QueryAsync<T>(Procname, param, commandType: CommandType.StoredProcedure).Result;
                return res.FirstOrDefault();
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string Procname, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(Config.DBCon))
            {
                var res = conn.QueryAsync<T>(Procname, param, commandType: CommandType.Text).Result;
                return res;
            }
        }
    }
}
