using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.AppCode.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(UserDetails user);
        Task<bool> ValidateTokenAsync(string token);
    }
}
