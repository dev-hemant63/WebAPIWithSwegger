using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.AppCode.Interface
{
    public interface IHellper
    {
        Task<T> ExecuteProcAsync<T>(string Procname, object param);
        Task<T> ExecuteProcAsyncLst<T>(string Procname, object param);
        Task<T> GetAsync<T>(string Procname, object param);
        Task<IEnumerable<T>> GetAllAsync<T>(string Procname, object param = null);
    }
}
